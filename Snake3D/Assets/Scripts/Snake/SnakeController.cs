using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController
{
    SnakeModel model;

    SnakeManager snakeManger;

    public SnakeController(SnakeManager _snakeManger)
    {
        model = new SnakeModel();
        snakeManger = _snakeManger;
    }

    public void CreateSnake()
    {
        SnakeBlockController body = new SnakeBlockController(new Coordinate(3,4), null, snakeManger.snakeBlockPrefab, model);
        body.SetBlockMaterialTo(snakeManger.snakeBodyMaterial);

        model.snakeHead = new SnakeBlockController(new Coordinate(4,4), body, snakeManger.snakeBlockPrefab, model);
        model.snakeHead.SetBlockMaterialTo(snakeManger.snakeHeadMaterial);
        
        model.snakeDirection = Direction.Up;
    }

    public void ChangeDirection(Direction newDirection)
    {
        if(Mathf.Abs((float)newDirection) != Mathf.Abs((float)model.snakeDirection))
        {
            model.snakeDirection = newDirection;
        }
    }

    public void AdvanceOneStep()
    {
        int nxtBlockRow = 0;
        int nxtBlockColumn = 0;
        bool advanceSnake = false;
        int boardRowCount = snakeManger.GetMapManager().BoardRows;
        int boardColumnCount = snakeManger.GetMapManager().BoardColumns;
        switch(model.snakeDirection)
        {
            //checks if snake gous out of the board
            case Direction.Up:
            {
                if(model.snakeHead.GetCoordinates().row < boardRowCount-1)
                {
                    nxtBlockRow = model.snakeHead.GetCoordinates().row + 1;
                    advanceSnake = true;
                }
                else
                {
                    snakeManger.GetScoreManager().TriggerGameOver();
                }
                nxtBlockColumn = model.snakeHead.GetCoordinates().column;
                break;
            }
            case Direction.Down:
            {
                if(model.snakeHead.GetCoordinates().row > 0)
                {
                    nxtBlockRow = model.snakeHead.GetCoordinates().row - 1;
                    advanceSnake = true;
                }
                else
                {
                    snakeManger.GetScoreManager().TriggerGameOver();
                }
                nxtBlockColumn = model.snakeHead.GetCoordinates().column;
                break;
            }
            case Direction.Left:
            {
                if(model.snakeHead.GetCoordinates().column > 0)
                {
                    nxtBlockColumn = model.snakeHead.GetCoordinates().column - 1;
                    advanceSnake = true;
                }
                else
                {
                    snakeManger.GetScoreManager().TriggerGameOver();
                }
                nxtBlockRow = model.snakeHead.GetCoordinates().row;
                break;
            }
            case Direction.Right:
            {
                if(model.snakeHead.GetCoordinates().column < boardColumnCount-1)
                {
                    nxtBlockColumn = model.snakeHead.GetCoordinates().column + 1;
                    advanceSnake = true;
                }
                else
                {
                    snakeManger.GetScoreManager().TriggerGameOver();
                }
                nxtBlockRow = model.snakeHead.GetCoordinates().row;
                break;
            }
        }

        //Checks if snake head collides with its own body
        Coordinate newHeadCoardinate = new Coordinate(nxtBlockRow, nxtBlockColumn);
        if(CheckIfCoordinateOverlapsSnake(newHeadCoardinate))
        {
            snakeManger.GetScoreManager().TriggerGameOver();
            advanceSnake = false;
        }


        if (advanceSnake)
        {
            
            bool aboutToEatFood = false;
            if(snakeManger.GetFoodManager().GetCurrentFoodCoordinates() == newHeadCoardinate)
            {
                aboutToEatFood = true;
            }


            model.snakeHead.SetBlockMaterialTo(snakeManger.snakeBodyMaterial);
            model.snakeHead = new SnakeBlockController(new Coordinate(nxtBlockRow,nxtBlockColumn), model.snakeHead, snakeManger.snakeBlockPrefab, model);
            model.snakeHead.SetBlockMaterialTo(snakeManger.snakeHeadMaterial);

            if (aboutToEatFood)
            {
                snakeManger.GetScoreManager().AddUpScoreWithOffset(snakeManger.GetFoodManager().GetScoreForCurrentFoodParticle());
                snakeManger.GetFoodManager().ResetFoodParticleProperties();
            }
            else
            {
                //no need to remove the last block if snake eats the food 
                SnakeBlockController tempBlock = model.snakeHead;
                while(tempBlock.nextBlock.nextBlock != null)
                {
                    tempBlock = tempBlock.nextBlock;
                }
                tempBlock.nextBlock.RemoveBlock();
                tempBlock.nextBlock = null;
            }
        }

    }
    public bool CheckIfCoordinateOverlapsSnake(Coordinate _coordinate)
    {
        SnakeBlockController tempBlock = model.snakeHead;
        bool overlaps = false;
        while(tempBlock != null)
        {
            if (tempBlock.GetCoordinates() == _coordinate)
            {
                overlaps = true;
                break;
            }
            tempBlock = tempBlock.nextBlock;
        }
        return overlaps;
    }
}
