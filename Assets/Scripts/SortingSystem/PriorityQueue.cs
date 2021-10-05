using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue : MonoBehaviour
{

    private void Start()
    {
        /*테스트코드
        Priority_Queue<GridData> g = new Priority_Queue<GridData>();
        GridData g1 = new GridData();
        g1.f = 10;
        g.push(g1);
        GridData g2 = new GridData();
        g2.f = 23;
        g.push(g2);
        GridData g3 = new GridData();
        g3.f = 2;
        g.push(g3);
        GridData g4 = new GridData();
        g4.f = 4;
        g.push(g4);
        GridData g5 = new GridData();
        g5.f = 16;
        g.push(g5);
        print(g.count);
        for (int i = 0; i < 5; ++i)
            print(i.ToString()+":"+ g.pop().f.ToString());
        print(g.count);
        */
    }
}
 
public class Priority_Queue<T>
{
    List<GridData> nowList;

    public Priority_Queue()
    {
        nowList = new List<GridData>();
    }

    public void push(GridData data)
    {
        int count = nowList.Count;
        int index = -1;
        if (count < 1)
        {
            nowList.Add(data);
            return;
        }
        for (int i = count; --i > -1;)
            if (nowList[i] < data)
            {
                index = i + 1;
                break;
            }
        if (index.Equals(-1))
            index = 0;
        nowList.Insert(index, data);
    }

    public GridData pop()
    {
        GridData g = nowList[0];
        nowList.RemoveAt(0);
        return g;
    }

    public int count
    {
        get
        {
            return nowList.Count;
        }
    }
}
