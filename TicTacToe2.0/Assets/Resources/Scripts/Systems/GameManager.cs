using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _gameInstance;
    public static GameManager Instance { get { return _gameInstance; } }

    //Serialized fields
    [SerializeField]
    private List<GameObject> _bluePieces = new List<GameObject>(3);
    [SerializeField]
    private List<GameObject> _redPieces = new List<GameObject>(3);

    //Variables
    private GameMode _gameMode;
    private Turn _playerTurn;
    private PieceSelected _playerPiece;
    private bool _gameStarted = false;


    //Properties
    public GameMode Mode { get { return _gameMode; } set { _gameMode = value; } }
    public Turn PlayerTurn { get { return _playerTurn; } set { _playerTurn = value; } }
    public PieceSelected PlayerPiece { get { return _playerPiece; } set { _playerPiece = value;} }

    private void Awake()
    {
        InitializeInstance();
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

    public void InstatiatePiece()
    {
        
    }
}
