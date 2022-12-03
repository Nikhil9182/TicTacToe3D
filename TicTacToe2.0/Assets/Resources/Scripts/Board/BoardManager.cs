using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    //Serialized Fields
    [SerializeField]
    private List<GameObject> _playerAPieces = new List<GameObject>(3);
    [SerializeField]
    private List<GameObject> _playerBPieces = new List<GameObject>(3);
    [SerializeField]
    private Transform _pieceTransform;
    [SerializeField]
    int _widthOfBoard,_heightOfBoard;
    [SerializeField, Range(1, 2)]
    float _gapBetweenEachTiles = 1.3f;
    [SerializeField]
    Tile _tilePrefab;
    [SerializeField]
    bool _doCameraSwitchInGame = true;

    //Private Members

    List<Tile> _tiles = new List<Tile>();
    Transform _tilesParent;


    #region BuiltIn Methods

    private void OnEnable() => GameManager.Instance.PiecePlaceOnBaord += PlacePieceOnBoard;
    private void OnDisable() => GameManager.Instance.PiecePlaceOnBaord -= PlacePieceOnBoard;

    private void Start()
    {
        Initialize();
        GenerateBoard();
    }

    #endregion

    #region Custom Methods

    private void Initialize()
    {
        _tilesParent = gameObject.transform.GetChild(0);
        GameManager.Instance._offlineModeSwitchCamera = _doCameraSwitchInGame;
    }

    void GenerateBoard()
    {
        int index = 0;
        for (int i = 0; i < _widthOfBoard; i++)
        {
            for (int j = 0; j < _heightOfBoard; j++)
            {
                Tile newTile = Instantiate(_tilePrefab,
                new Vector3(j * _gapBetweenEachTiles - 1f, _tilesParent.position.y, i * _gapBetweenEachTiles - 1f),
                Quaternion.identity, _tilesParent);
                newTile.Initialize(index++, newTile.gameObject.transform.position, TileTaken.NONE);
                newTile.name = "Tile " + i + " " + j;
                _tiles.Add(newTile);
            }
        }
    }

    void PlacePieceOnBoard(int tileIndex)
    {
        if (!_tiles[tileIndex].IsValid())
        {
            return;
        }
        else
        {
            GameObject newPiece;
            if(GameManager.Instance.PlayerTurn == Turn.PLAYER_A_TURN)
            {
                newPiece = Instantiate(_playerAPieces[(int)GameManager.Instance.PlayerPiece], _tiles[tileIndex].Position, Quaternion.identity, _pieceTransform);
                _tiles[tileIndex].TileTaken = TileTaken.PLAYER_A_TAKEN;
            }
            else
            {
                newPiece = Instantiate(_playerBPieces[(int)GameManager.Instance.PlayerPiece], _tiles[tileIndex].Position, Quaternion.identity, _pieceTransform);
                _tiles[tileIndex].TileTaken = TileTaken.PLAYER_B_TAKEN;
            }
            if (CheckWinner())
            {
                GameManager.Instance.SwitchTurn();
            }
        }
    }

    bool CheckWinner()
    {
        //winner check algorithm
        return true;
    }

    #endregion
}
