using System;
using UnityEngine;
using Zenject;

public class GamePlayInputPresenter : IInitializable, IDisposable, IFixedTickable
{
    #region Data

    readonly HUDController  _HudController;
    readonly InputVariables _InputVars;
    readonly PlayerDistanceMeasure _PlayerDistanceMeasure;

    private bool _IsInputDown;
    private Vector3 m_InputDownPosNormalized;
    private Vector3 m_LastInputPosNormalized;
    private Vector2 m_DeltaDrag;
    private Vector2 m_Drag;

    public Vector2 DeltaDrag => m_DeltaDrag;
    public Vector2 Drag => m_Drag;

    public bool IsInputDown => _IsInputDown;

    #endregion Data

    public GamePlayInputPresenter(HUDController _HudController,
        InputVariables _InputVars,
        PlayerDistanceMeasure _PlayerDistanceMeasure)
    {
        this._HudController = _HudController;
        this._InputVars = _InputVars;
        this._PlayerDistanceMeasure = _PlayerDistanceMeasure;
    }
    public void Initialize()
    {
        _HudController.OnInputDown  += OnInputDown;
        _HudController.OnInputUp    += OnInputUp;
    }

    public void Dispose()
    {
        _HudController.OnInputDown  -= OnInputDown;
        _HudController.OnInputUp    -= OnInputUp;
    }

    public void OnInputDown(Vector2 _mousePosition)
    {
        _IsInputDown = true;
        m_InputDownPosNormalized = m_LastInputPosNormalized = _mousePosition;
        
    }

    public void OnInputUp()
    {
        _IsInputDown = false;
    }

    public void FixedTick()
    {

        if (_IsInputDown)
        {
            SetInput(Input.mousePosition);
        }
        _HudController.DistanceText.text = _PlayerDistanceMeasure.DistanceCovered + "m";
    }

    public void SetInput(Vector3 _MousePos)
    {
        m_Drag = (_MousePos - m_InputDownPosNormalized) * _InputVars.DragSensitivity;
        m_DeltaDrag = (_MousePos - m_LastInputPosNormalized) * _InputVars.DragSensitivity;

        m_LastInputPosNormalized = _MousePos;
    }

    
}
