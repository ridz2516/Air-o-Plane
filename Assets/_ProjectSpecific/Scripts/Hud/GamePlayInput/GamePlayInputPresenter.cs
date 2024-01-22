using System;
using UnityEngine;
using Zenject;

public class GamePlayInputPresenter : IInitializable, IDisposable, IFixedTickable
{
    #region Data

    readonly HUDController  _HudController;
    readonly InputVariables _InputVars;
    //readonly IMovementControl _PlaneStateMoving;

    private bool _IsInputDown;
    private Vector3 m_InputDownPosNormalized;
    private Vector3 m_LastInputPosNormalized;
    private Vector2 m_DeltaDrag;
    private Vector2 m_Drag;

    public Vector2 DeltaDrag => m_DeltaDrag;
    public Vector2 Drag => m_Drag;

    public bool IsInputDown => _IsInputDown;

    #endregion Data

    public GamePlayInputPresenter(HUDController _HudController, InputVariables _InputVars)
    {
        this._HudController = _HudController;
        this._InputVars = _InputVars;
        //this._PlaneStateMoving = _PlaneStateMoving;
    }
    public void Initialize()
    {
        _HudController.OnInputDown += OnInputDown;
        _HudController.OnInputUp += OnInputUp;
    }

    public void Dispose()
    {
        _HudController.OnInputDown -= OnInputDown;
        _HudController.OnInputUp -= OnInputUp;
    }

    private void OnInputDown(Vector2 _mousePosition)
    {
        _IsInputDown = true;
        m_InputDownPosNormalized = m_LastInputPosNormalized = Input.mousePosition;
        
    }

    private void OnInputUp()
    {
        _IsInputDown = false;
    }
    //Runs like FixedUpdate
    public void FixedTick()
    {
       
        //_PlaneStateMoving.IsInputDown = _IsInputDown;

        if (_IsInputDown)
        {
            m_Drag = (Input.mousePosition - m_InputDownPosNormalized) * _InputVars.DragSensitivity;
            m_DeltaDrag = (Input.mousePosition - m_LastInputPosNormalized) * _InputVars.DragSensitivity;

            m_LastInputPosNormalized = Input.mousePosition;
           // _PlaneStateMoving.Rotate(m_DeltaDrag);
        }
        else
        {
            //_PlaneStateMoving.ResetRotation();
        }
    }

    
}
