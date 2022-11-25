using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    #region Tile Private Members
    private int _index;
    private Vector3 _position;
    private Material _material;
    private TileTaken _tileTaken;
    private TilePiece _currentTilePiece;
    #endregion

    #region Tile Properties
    public int Index { get { return _index; } }
    public Vector3 Position { get { return _position;} set { _position = value; } }
    public TileTaken TileTaken { get { return _tileTaken; } set { _tileTaken = value; } }
    #endregion

    public void Initialize(int tileIndex, Vector3 tilePosition, TileTaken tileTaken)
    {
        _index = tileIndex;
        _position = tilePosition;
        _tileTaken = tileTaken;
        _material = GetComponent<MeshRenderer>().material;
    }
}
