using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
{
    private static T instance = null;
    public static T Instance {get{return instance;}} 
    protected virtual void Awake()
    {
        if(instance == null || instance != this){
            instance = (T)this;
        }
        else{
            Debug.LogError("careful.....Duplicate instance is being created");
            Destroy(this);
        }
    }

    public MapManager GetMapManager()
    {
        return GameObject.FindObjectOfType<MapManager>();
    }

    public FoodManager GetFoodManager()
    {
        return GameObject.FindObjectOfType<FoodManager>();
    }

    public ScoreManager GetScoreManager()
    {
        return GameObject.FindObjectOfType<ScoreManager>();
    }

    public SnakeManager GetSnakeManager()
    {
        return GameObject.FindObjectOfType<SnakeManager>();
    }
}
