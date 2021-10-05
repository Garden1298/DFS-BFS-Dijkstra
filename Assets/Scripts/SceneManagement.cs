using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneManagement : MonoBehaviour
{

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ToDFS()
    {
        SceneManager.LoadScene("DFS");
    }

    public void ToBFS()
    {
        SceneManager.LoadScene("BFS");
    }

    public void ToDijkstra()
    {
        SceneManager.LoadScene("Dijkstra");
    }
}
