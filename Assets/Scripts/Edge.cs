using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    public Node _leftNode;
    public Node _rightNode;

    public int _pathLength;

    public void SetLeft(Node node)
    {
        _leftNode = node;
        _leftNode.AddEdge(this);
    }

    public Node GetLeft()
    {
        return _leftNode;
    }

    public void SetRight(Node node)
    {
        _rightNode = node;
        _rightNode.AddEdge(this);
    }

    public Node GetRight()
    {
        return _rightNode;
    }
}
