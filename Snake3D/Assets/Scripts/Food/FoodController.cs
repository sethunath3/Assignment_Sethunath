using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController
{
    private FoodManager foodManager;
    private FoodView foodparticleview;
    private FoodModel foodParticleModel;
    private Dictionary<Color, int> foodData = new Dictionary<Color, int>();
    public FoodController(FoodManager _foodManager)
    {
        foodManager = _foodManager;
        PopulatefoodDataFromFile(_foodManager.foodDataFile);
        foodParticleModel = new FoodModel();
        foodparticleview = GameObject.Instantiate<FoodView>(foodManager.foodParticlePrefab, UtilityFunctions.GetTransformsForCoordinatesOnBoardPlane(new Coordinate(8,8),0.6f), Quaternion.identity);
        foodParticleModel.SetFoodProperties(new Coordinate(8, 8), Color.red, foodData[Color.red]);
        foodparticleview.GetComponent<Renderer>().material.color = Color.red;
    }

    public void PopulatefoodDataFromFile(TextAsset foodDataFile)
    {
        //Temporery Value assigning. needs to be redone from a text file
        foodData.Add(Color.red, 15);
        foodData.Add(Color.blue, 20); 
    }

    public void ResetFoodParticleProperties()
    {
        List<Color> colourList = new List<Color>(foodData.Keys);
        System.Random rand = new System.Random();
        Color randomColor = colourList[rand.Next(0,colourList.Count)];

        if (foodParticleModel.foodColor == randomColor)
        {
            foodManager.GetScoreManager().IncrementStreak();
        }
        else
        {
            foodManager.GetScoreManager().ResetStreak();
        }
        //Generating a random position for food particle
        Coordinate newFoodCoordinate = GetRandomCoordinateOutsideSnake();
        foodParticleModel.SetFoodProperties(new Coordinate((int)newFoodCoordinate.row, (int)newFoodCoordinate.column), randomColor, foodData[randomColor]);
        foodparticleview.transform.position = UtilityFunctions.GetTransformsForCoordinatesOnBoardPlane(newFoodCoordinate,0.6f);
        foodparticleview.GetComponent<Renderer>().material.color = randomColor;
    }

    private Coordinate GetRandomCoordinateOutsideSnake()
    {
        bool overlaps = true;
        int rowCount = foodManager.GetMapManager().BoardRows;
        int columnCount = foodManager.GetMapManager().BoardColumns;
        Coordinate coordinate;
        do
        {
            coordinate = new Coordinate(Random.Range(0, rowCount), Random.Range(0, columnCount));
            overlaps = foodManager.GetSnakeManager().CheckIfCoordinateOverlapsSnake(coordinate);
        } while (overlaps);
        return coordinate;
    }
    public Coordinate GetCurrentFoodCoordinates()
    {
        return foodParticleModel.foodCoordinate;
    }

    public int GetScoreForCurrentFoodParticle()
    {
        return foodParticleModel.points;
    }
}
