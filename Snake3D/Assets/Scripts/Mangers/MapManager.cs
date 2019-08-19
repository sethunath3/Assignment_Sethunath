using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : GenericMonoSingleton<MapManager>
{
    public int BoardRows = 10;
    public int BoardColumns = 10;
    public float TileGap = 0.1f;
    public float TileWidth = 1;
    public TileView TilePrefab;
    void Start()
    {
        BoardController controller = new BoardController(this);
        controller.GenerateBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
