using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodView : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(1, 3, 2, Space.Self);
    }
}
