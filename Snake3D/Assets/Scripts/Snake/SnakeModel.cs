using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {Right = 1, Left =-1, Up = 2, Down = -2};


public class SnakeModel {
    public Direction snakeDirection;
    public SnakeBlockController snakeHead;
}
