using Moq;
using NUnit.Framework;
using UnityEngine;

public class InputTest
{
    [Test]
    public void OnInputDown_ShouldSetIsInputDownToTrue()
    {
        // Arrange
        var hudControllerMock = new Mock<HUDController>();
        var inputVarsMock = new Mock<InputVariables>();

        var gamePlayInputPresenter = new GamePlayInputPresenter(hudControllerMock.Object, inputVarsMock.Object);

        // Act
        gamePlayInputPresenter.OnInputDown(Vector2.zero);

        // Assert
        Assert.IsTrue(gamePlayInputPresenter.IsInputDown);

    }

    [Test]
    public void OnInputUp_ShouldSetIsInputDownToFalse()
    {
        var hudControllerMock = new Mock<HUDController>();
        var inputVarsMock = new Mock<InputVariables>();

        var gamePlayInputPresenter = new GamePlayInputPresenter(hudControllerMock.Object, inputVarsMock.Object);

        gamePlayInputPresenter.OnInputUp();

        Assert.IsFalse(gamePlayInputPresenter.IsInputDown);
    }

    [Test]
    [TestCase(0, 1)]
    [TestCase(1, 0)]
    [TestCase(3, 4)]
    public void FixedTick_WhenInputIsDown_ShouldSetDragAndDeltaDrag(float _X, float _Y)
    {
        var hudControllerMock = new Mock<HUDController>();
        var inputVarsMock = new Mock<InputVariables>();

        var gamePlayInputPresenter = new GamePlayInputPresenter(hudControllerMock.Object, inputVarsMock.Object);
        gamePlayInputPresenter.OnInputDown(Vector2.zero);

        gamePlayInputPresenter.SetInput(new Vector2(_X,_Y));

        Assert.AreNotEqual(Vector2.zero, gamePlayInputPresenter.Drag);
        Assert.AreNotEqual(Vector2.zero, gamePlayInputPresenter.DeltaDrag);
    }

    [Test]
    public void FixedTick_WhenInputIsNotDown_ShouldSetZeroDragAndDeltaDrag()
    {
        var hudControllerMock = new Mock<HUDController>();
        var inputVarsMock = new Mock<InputVariables>();

        var gamePlayInputPresenter = new GamePlayInputPresenter(hudControllerMock.Object, inputVarsMock.Object);
        gamePlayInputPresenter.OnInputUp();

        gamePlayInputPresenter.FixedTick();

        Assert.AreEqual(Vector2.zero, gamePlayInputPresenter.Drag);
        Assert.AreEqual(Vector2.zero, gamePlayInputPresenter.DeltaDrag);
    }


}
