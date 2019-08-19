using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : GenericMonoSingleton<FoodManager>
{
    private FoodController foodController;
    
    public FoodView foodParticlePrefab;
    public TextAsset foodDataFile;

    void Start()
    {
        foodController = new FoodController(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Coordinate GetCurrentFoodCoordinates()
    {
        return foodController.GetCurrentFoodCoordinates();
    }

    public void ResetFoodParticleProperties()
    {
        foodController.ResetFoodParticleProperties();
    }

    public int GetScoreForCurrentFoodParticle()
    {
        return foodController.GetScoreForCurrentFoodParticle();
    } 
}
