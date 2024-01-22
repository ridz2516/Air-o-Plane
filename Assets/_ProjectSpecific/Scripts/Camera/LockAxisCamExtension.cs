using Cinemachine;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("")] // Hide in menu
public class LockAxisCamExtension : CinemachineExtension
{
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if(stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.y = 0;
            state.RawPosition = pos;
        }
    }
}
