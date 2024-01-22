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
    public void FixedTick_WhenInputIsDown_ShouldSetDragAndDeltaDrag()
    {
        var hudControllerMock = new Mock<HUDController>();
        var inputVarsMock = new Mock<InputVariables>();

        var gamePlayInputPresenter = new GamePlayInputPresenter(hudControllerMock.Object, inputVarsMock.Object);
        gamePlayInputPresenter.OnInputDown(Vector2.zero);

        gamePlayInputPresenter.SetInput(Vector2.up);

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
