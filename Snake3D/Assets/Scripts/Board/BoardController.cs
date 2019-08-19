using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController
{
    BoardModel model;
    MapManager mapManger;

    public BoardController(MapManager _mapManger)
    {
        model = new BoardModel();
        mapManger = _mapManger;
        setModelValues();
    }

    private void setModelValues()
    {
        model.boardRows = mapManger.BoardRows;
        model.boardColumns = mapManger.BoardColumns;
        model.tileGap = mapManger.TileGap;
        model.tileWidth = mapManger.TileWidth;
    }

    public void GenerateBoard()
    {
        for(int rowIterator=0; rowIterator<model.boardRows; rowIterator++)
        {
            for(int columnIterator= 0; columnIterator<model.boardColumns; columnIterator++)
            {
                Vector3 tilePosition = new Vector3((rowIterator * model.tileWidth)+(rowIterator*model.tileGap), 0, (columnIterator * model.tileWidth)+(columnIterator*model.tileGap));
                GameObject.Instantiate<TileView>(mapManger.TilePrefab, tilePosition, Quaternion.identity);
            }
        }
    }
}
