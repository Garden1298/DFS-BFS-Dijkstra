using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DFS : MonoBehaviour
{
    public Graph graph;

    private List<Node> _nodePath;

    public Text t_node_path;

    public void Start()
    {
        _nodePath = new List<Node>();

        graph = GameObject.Find("DFS").GetComponent<Graph>();

        Travel();
    }

    public void Travel()
    {
        DFS_AI(graph._nodeList[0]);
    }

    public void DFS_AI(Node node)
    {
        if (node.GetConfirm() == true)
        {
            return;
        }

        node.SetConfirm(true);

        node.WriteConsole();

        _nodePath.Add(node);

        if (node._edges.Count != 0)
        {
            for (int i = 0; i < node._edges.Count; i++)
            {
                if (!node._edges[i].GetRight().GetConfirm())
                {
                    DFS_AI(node._edges[i].GetRight());
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
