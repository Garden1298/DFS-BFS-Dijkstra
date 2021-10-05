using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dijkstra_2 : MonoBehaviour
{
    private int _number = 6; // 정점의 개수
    private int INF = 1000000000; // 무한대 표현 

    private int[,] _array;//그래프 정보
    public bool[] _visited = new bool[6];//노드 방문 여부 체크
    public int[] _distance = new int[6];//최단 거리 저장
    public int[] path = new int[6];//길찾기

    public List<int> list = new List<int>();

    public Text t_node_path;
    public InputField f_inputfield_end;

    private void Start()
    {
        _array = new int[6, 6]
        {
            {0, 2, 5, 1, INF, INF},
            {2, 0, 3, 2, INF, INF},
            {5, 3, 0, 3, 1, 5},
            {1, 2, 3, 0, 1, INF},
            {INF, INF, 1, 1, 0, 2},
            {INF, INF, 5, INF, 2, 0}
        };
    }

    //가장 최소 거리를 가지는 정점 반환
    //방문하지 않은 노드 중
    int GetSmallIndex()
    {
        int min = INF;
        int index = 0;

        for(int i = 0; i < _number; i++)
        {
            //방문하지 않았고,
            //현재 최솟값보다 작은 거리가 존재한다면
            //최솟값 갱신
            if(_distance[i] < min && !_visited[i])
            {
                min = _distance[i];
                index = i;//최소 비용의 위치 기억
            }
        }
        return index;
    }

    public void Dijkstra(int start)
    {
        for(int i =0;i<_number;i++)
        {
            //시작점에서 출발했을 때, 모든 경로까지의 비용 담아줌
            _distance[i] = _array[start,i];
        }
        _visited[start] = true;

        for(int i =0;i<_number-2;i++)
        {
            int current = GetSmallIndex();
            _visited[current] = true;

            for(int j =0;j<_number;j++)
            {
                if(!_visited[j])
                {
                    if(_distance[current]+_array[current,j]<_distance[j])
                    {
                        _distance[j] = _distance[current] + _array[current, j];
                        path[j] = current;
                    }
                }
            }
        }
    }

    public void Path(int start, int end)
    {

        Dijkstra(start);
        
        list.Add(end);

        int target_node = end;

        while(target_node != start)
        {
            target_node = path[target_node];
            list.Add(target_node);
        }

        list.Reverse();


        for (int i = 0; i < list.Count; i++)
        {
            t_node_path.text += (list[i] + 1).ToString() + '\n';
        }

        t_node_path.text += "---------------\n";
    }

    public int GetPath(int num)
    {
        return list[num]+1;
    }

    public void startButton()
    {
        int start = 0;
        int end = int.Parse(f_inputfield_end.text) - 1;

        if(end>6)
        {
            t_node_path.text += "다시 입력해주세요\n";
        }

        Path(start, end);
    }

    public void ClearButton()
    {
        t_node_path.text = "\n";
    }
}
