using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using System;

public class UIOfflineController : MonoBehaviour
{
    //Serialized Fields
    [SerializeField]
    private Button[] _playerABtn = new Button[3];
    [SerializeField]
    private Button[] _playerBBtn = new Button[3];

    private void Start()
    {
        InitializeVariables();
    }

    private void InitializeVariables()
    {
        UISwitch();
    }

    private void OnEnable() => GameManager.Instance.UIPlayerSwitcher += UISwitch;
    private void OnDisable() => GameManager.Instance.UIPlayerSwitcher -= UISwitch;

    public void PieceSelect(int index)
    {
        GameManager.Instance.PlayerPiece = (Piece)index;
        Debug.Log(GameManager.Instance.PlayerPiece);
    }

    private void UISwitch()
    {
        if(GameManager.Instance.PlayerTurn == Turn.PLAYER_A_TURN)
        {
            foreach (var btn in _playerABtn)
                btn.interactable = true;
            foreach (var btn in _playerBBtn)
                btn.interactable = false;
        }
        else
        {
            foreach (var btn in _playerABtn)
                btn.interactable = false;
            foreach (var btn in _playerBBtn)
                btn.interactable = true;
        }
    }
}
