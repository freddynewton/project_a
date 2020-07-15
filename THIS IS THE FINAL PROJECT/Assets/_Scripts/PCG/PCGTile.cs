using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PCGTile : MonoBehaviour
{
    public TileBase floorRuleTile;

    [Header("Background")]
    public TileBase backgroundTile;
    public BoundsInt bounds;
}
