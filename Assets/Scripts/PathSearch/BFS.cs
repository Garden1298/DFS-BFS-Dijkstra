using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class BFS : MonoBehaviour
{
    public Graph graph;

    private List<Node> _nodePath;
    private Queue<Node> _visitedQueue;

    public Text t_node_path;

    public void Start()
    {
        _nodePath = new List<Node>();

        _visitedQueue = new Queue<Node>();

        graph = GameObject.Find("BFS").GetComponent<Graph>();

        Travel();
    }

    public void Travel()
    {
        BFS_AI(graph._nodeList[0]);
    }

    public void BFS_AI(Node node)
    {
        node.SetConfirm(true);
        _visitedQueue.Enqueue(node);

        while(_visitedQueue.Count != 0)
        {
            Node nextNode = _visitedQueue.Dequeue();

            nextNode.WriteConsole();

            _nodePath.Add(nextNode);

            for(int i = 0; i < nextNode._edges.Count;i++)
            {
                Edge adjacentNode = nextNode._edges[i];

                if(!adjacentNode.GetRight().GetConfirm())
                {
                    adjacentNode.GetRight().SetConfirm(true);
                    _visitedQueue.Enqueue(adjacentNode.GetRight());
                }
            }
        }
    }

    public void ColorPath()
    {

        for (int i = 0; i < _nodePath.Count; i++)
        {
            t_node_path.text += _nodePath[i].ToString() + "\n";
        }

        _nodePath[0].ChangeColor(_nodePath[0]);
        StartCoroutine(ChangeNode2());
    }


    IEnumerator ChangeNode2()
    {
        yield return new WaitForSeconds(1f);
        _nodePath[1].ChangeColor(_nodePath[1]);
        StartCoroutine(ChangeNode3());
    }

    IEnumerator ChangeNode3()
    {
        yield return new WaitForSeconds(1f);
        _nodePath[2].ChangeColor(_nodePath[2]);
        StartCoroutine(ChangeNode4());
    }

    IEnumerator ChangeNode4()
    {
        yield return new WaitForSeconds(1f);
        _nodePath[3].ChangeColor(_nodePath[3]);
        StartCoroutine(ChangeNode5());
    }

    IEnumerator ChangeNode5()
    {
        yield return new WaitForSeconds(1f);
        _nodePath[4].ChangeColor(_nodePath[4]);
        StartCoroutine(ChangeNode6());
    }

    IEnumerator ChangeNode6()
    {
        yield return new WaitForSeconds(1f);
        _nodePath[5].ChangeColor(_nodePath[5]);
    }
}
