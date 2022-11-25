using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    //Serialized Fields

    [SerializeField]
    int _widthOfBoard,_heightOfBoard;
    [SerializeField, Range(1, 2)]
    float _gapBetweenEachTiles = 1.3f;
    [SerializeField]
    Tile _tilePrefab;

    //Private Members

    List<Tile> _tiles = new List<Tile>();
    Transform _tilesParent;

    //Events
    //public delegate void CheckWinner();
    //public static event CheckWinner CameraInput;


    #region BuiltIn Methods

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
    }

    void GenerateBoard()
    {
        int index = 0;
        for (int i = 0; i < _widthOfBoard; i++)
        {
            for (int j = 0; j < _heightOfBoard; j++)
            {
                Tile newTile = Instantiate(_tilePrefab, 
                new Vector3(j * _gapBetweenEachTiles, _tilesParent.position.y, i * _gapBetweenEachTiles), 
                Quaternion.identity, _tilesParent);
                newTile.Initialize(index++, newTile.gameObject.transform.position, TileTaken.NONE);
                newTile.name = "Tile " + i + " " +j; 
                _tiles.Add(newTile);
            }
        }
        _tilesParent.position = new Vector3(_tilesParent.position.x - 1f, _tilesParent.position.y, _tilesParent.position.z - 1f);
    }

    #endregion
}
