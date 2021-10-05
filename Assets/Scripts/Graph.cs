using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
   public List<Node> _nodeList;

    public void Awake()
    {
        for (int i =0; i<_nodeList.Count; i++)
        {
            _nodeList[i].SetNodeNum(i+1);
        }
    }

    public void AddNode(Node node)
    {
        _nodeList.Add(node);
    }

    public Node GetNode(int nodenum)
    {
        return _nodeList[nodenum];
    }
}
