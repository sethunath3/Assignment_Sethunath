using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBlockView : MonoBehaviour
{
    private void OnDestroy() {
        Debug.Log("Kill block");
    }
}
