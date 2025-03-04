using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    NONE = 0,
    STRAIGHT_SOUTH_NORTH = 1,
    STRAIGHT_WEST_EAST = 2,
    CORNER_NORTH_WEST = 3,
    CORNER_NORTH_EAST = 4,
    CORNER_SOUTH_WEST = 5,
    CORNER_SOUTH_EAST = 6,
    EDGE_WEST = 7,
    EDGE_EAST = 8,
    EDGE_NORTH = 9,
    EDGE_SOUTH = 10,
}

public class TileManager : MonoBehaviour
{
    public List<GameObject> CurrentActiveTileGameObjectList;

    void Start()
    {

    }

    void Update()
    {
        if(CurrentActiveTileGameObjectList.Count > 3)
        {
            Destroy(CurrentActiveTileGameObjectList[0]);
            CurrentActiveTileGameObjectList.RemoveAt(0);
        }
    }
}
