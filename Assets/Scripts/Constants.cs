using Unity.Burst.CompilerServices;
using UnityEngine;

public enum GameState
{
    NONE = 0,
    START = 1,
    CONTINUE = 2,
    END = 3
}

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

public enum LargeTileType
{
    NONE = 0,
    STRAIGHT_SOUTH_NORTH = 1,
    STRAIGHT_WEST_EAST = 2,
    CORNER_NORTH_WEST = 3,
    CORNER_NORTH_EAST = 4,
    CORNER_SOUTH_WEST = 5,
    CORNER_SOUTH_EAST = 6,
    SPLIT_WEST = 7,
    SPLIT_EAST = 8,
    SPLIT_NORTH = 9,
    SPLIT_SOUTH = 10,
}

public enum WinType
{
    NONE = 0,
    START_MENU = 1,
    GAME_END_MENU = 2,
}

public class Constants
{
    public const float TILE_WIDTH = 10;
    public const float PLAYER_SPEED = 10;
    public const float LIFE_TIME_AFTER_PLAYER_EXITS_TILE = 2;
}
