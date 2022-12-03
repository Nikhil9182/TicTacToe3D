using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _playerA_Cam, _playerB_Cam;

    private void OnEnable() => GameManager.Instance.CameraSwitcher += SwitchCamera;
    private void OnDisable() => GameManager.Instance.CameraSwitcher -= SwitchCamera;

    private void SwitchCamera(Turn playerTurn)
    {
        if (playerTurn == Turn.PLAYER_A_TURN)
        {
            _playerA_Cam.Priority = 1;
            _playerB_Cam.Priority = 0;
        }
        else
        {
            _playerA_Cam.Priority = 0;
            _playerB_Cam.Priority = 1;
        }
    }

}
