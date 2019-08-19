using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodModel
{
    public Coordinate foodCoordinate;
    public int points = 1;
    public Color foodColor = Color.red;

    public void SetFoodProperties(Coordinate _foodCoordinate, Color _foodColor, int score)
    {
        foodCoordinate = _foodCoordinate;
        points = score;
        foodColor = _foodColor;
    }
}
