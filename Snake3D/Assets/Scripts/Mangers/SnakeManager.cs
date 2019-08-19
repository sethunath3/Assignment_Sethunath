using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : GenericMonoSingleton<SnakeManager>
{
    private SnakeController snakeController = null;
    private float snakeUpdatePeriod = 0.0f;

    //Public members
    public GameObject snakeBlockPrefab;
    public  Material snakeBodyMaterial;
    public  Material snakeHeadMaterial;

    public float snakeUpdateInterval = 1.0f;

    void Start()
    {
        snakeController = new SnakeController(this);
        snakeController.CreateSnake();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)){
            snakeController.ChangeDirection(Direction.Left);
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            snakeController.ChangeDirection(Direction.Right);
        }
        if (Input.GetKey(KeyCode.UpArrow)){
            snakeController.ChangeDirection(Direction.Up);
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            snakeController.ChangeDirection(Direction.Down);
        }
    }

    void FixedUpdate(){
        if (snakeUpdatePeriod > snakeUpdateInterval){
            if(snakeController!= null){
                snakeController.AdvanceOneStep();
            }
            snakeUpdatePeriod = 0;
        }
        snakeUpdatePeriod += UnityEngine.Time.deltaTime;
    }

    public bool CheckIfCoordinateOverlapsSnake(Coordinate coordinate)
    {
        return snakeController.CheckIfCoordinateOverlapsSnake(coordinate);
    }
}
