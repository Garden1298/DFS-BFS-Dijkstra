using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int _nodeNum;
    public bool _isConfirm = false;

    public List<Edge> _edges;

    public Renderer _nodeColor;

    public void Awake()
    {
        _nodeColor = gameObject.GetComponent<Renderer>();
    }

    public void SetNodeNum(int num)
    {
        _nodeNum = num;
    }

    public int GetNodeNum()
    {
        return _nodeNum;
    }

    public void AddEdge(Edge edge)
    {
        _edges.Add(edge);
    }

    public void SetConfirm(bool confirm)
    {
        _isConfirm = confirm;
    }

    public bool GetConfirm()
    {
        return _isConfirm;
    }

    public void WriteConsole()
    {
        Debug.Log("노드 "+_nodeNum+"번 확인");
    }

    public void ChangeColor(Node node)
    {
        node._nodeColor.material.color = Color.cyan;
        Debug.Log("노드 " + _nodeNum + "번 green");
    }

    public Vector3 GetNodeVector()
    {
        return gameObject.transform.position;
    }

}
