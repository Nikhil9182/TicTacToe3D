using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _gameInstance;
    public static GameManager Instance { get { return _gameInstance; } }

    //Variables
    private GameMode _gameMode;
    private Turn _playerTurn;
    private Piece _playerPiece;

    public bool _offlineModeSwitchCamera = true;


    //Properties
    public GameMode Mode { get { return _gameMode; } set { _gameMode = value; } }
    public Turn PlayerTurn { get { return _playerTurn; } set { _playerTurn = value; } }
    public Piece PlayerPiece { get { return _playerPiece; } set { _playerPiece = value;} }

    //Events
    public delegate void SpawnPiece(int tileIndex);
    public event SpawnPiece PiecePlaceOnBaord;

    public delegate void CameraSwitch(Turn playerTurn);
    public event CameraSwitch CameraSwitcher;

    public delegate void UIPlayerSwitch();
    public event UIPlayerSwitch UIPlayerSwitcher;


    private void Awake()
    {
        InitializeInstance();
    }

    private void Start()
    {
        InitializeVariables();
    }

    private void InitializeInstance()
    {
        if (_gameInstance != null && _gameInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _gameInstance = this;
    }

    private void InitializeVariables()
    {
        _playerTurn = Turn.PLAYER_A_TURN;
    }

    public void PlayTurn(GameObject tile)
    {
        if(_playerPiece != Piece.NONE)
        {
            PiecePlaceOnBaord(tile.gameObject.GetComponent<Tile>().Index);
        }
    }

    public void SwitchTurn()
    {
        _playerPiece = Piece.NONE;
        _playerTurn = (_playerTurn == Turn.PLAYER_A_TURN)? Turn.PLAYER_B_TURN : Turn.PLAYER_A_TURN;
        if(_offlineModeSwitchCamera) CameraSwitcher(_playerTurn);
        UIPlayerSwitcher();
    }
}
