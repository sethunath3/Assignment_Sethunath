using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityFunctions
{
    public static Vector3 GetTransformsForCoordinatesOnBoardPlane(Coordinate _cordinate, float YCoOrdinate)
    {
        MapManager mapmanger = GameObject.FindObjectOfType<MapManager>();
        return new Vector3((_cordinate.column * mapmanger.TileWidth)+(_cordinate.column*mapmanger.TileGap), YCoOrdinate, (_cordinate.row * mapmanger.TileWidth)+(_cordinate.row*mapmanger.TileGap));
    }
}
