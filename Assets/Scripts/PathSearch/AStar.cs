using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    private int Heuristic(int posX, int posY, int endX, int endY)
    {
        return (int)Mathf.Sqrt(Mathf.Pow(posX - endX, 2) + 
                    Mathf.Pow(posY - endY, 2));
    }
}
