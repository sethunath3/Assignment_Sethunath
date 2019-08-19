using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBlockController
{
    private GameObject block;
    private SnakeModel model;
    private Coordinate blockCoordinate;
    public SnakeBlockController nextBlock;

    public SnakeBlockController(Coordinate _blockCoordinate, SnakeBlockController _nextBlock, GameObject _blockPrefab, SnakeModel _model)
    {
        blockCoordinate = _blockCoordinate;
        nextBlock = _nextBlock;
        model = _model;
        block = GameObject.Instantiate(_blockPrefab, UtilityFunctions.GetTransformsForCoordinatesOnBoardPlane(blockCoordinate, 0.6f), Quaternion.identity);
    }

    public Coordinate GetCoordinates()
    {
        return blockCoordinate;
    }

    public void SetBlockMaterialTo(Material _material)
    {
        block.GetComponent<Renderer>().material = _material;
    }

    public void RemoveBlock()
    {
        GameObject.Destroy(block);
    }
}
