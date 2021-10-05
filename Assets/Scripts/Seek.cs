using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    public Graph g;
    public Dijkstra_2 d;

    //seek 할 오브젝트, 가장 가까운 노드!
    private Vector3 _target;

    private Rigidbody _rigidbody;

    private Vector3 _pickPos = Vector3.zero;

    //seek 할 오브젝트의 스피드
    private float _speed = 1.0f;

    //seek할 강도
    private float _seekStrength = 10.0f;

    private Vector3 _desiredVelocity = Vector3.zero;

    private Vector3 _currentVelocity = Vector3.zero;

    private List<Node> _nodePathList = new List<Node>(6);

    [SerializeField]
    private float _waypointRange = 1.3f;

    [SerializeField]
    private Vector3[] _waypoints;

    private int _currentPointIndex = 1;

    int closestNodeNum;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mouse_pos = Input.mousePosition;

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenToWorldPoint(mouse_pos), -Vector3.up, out hit, 1000))
            {
                _pickPos = hit.point;
            }

            d.Path(0, 2);
        }

        //_desiredVelocity = seek(g.GetNode(0).GetNodeVector());

        //현재 속도
        //Vector3 currentVelocity = _rigidbody.velocity;

        //조종힘
        //Vector3 seekForce = _desiredVelocity.normalized * _seekStrength;

        //새로운 속도
        //Vector3 newVelocity = (currentVelocity + seekForce).normalized * _speed;

        //_rigidbody.velocity = newVelocity;

        pathfollow();


        //if(Vector3.Distance(_target,transform.position)<1.3)
        //{
            //int pathNum = 0;

            //while (pathNum <= d.list.Count)
            //{
            //    for (int i = 0; i < g._nodeList.Count; i++)
            //    {
            //        if (d.GetPath(pathNum) == g._nodeList[i].GetNodeNum())
            //        {
            //            _nodePathList[pathNum] = g._nodeList[i];

            //            pathNum++;

            //            Debug.Log(pathNum);
            //        }
            //    }
            //}


            //for (int i = 0; i < _nodePathList.Count; i++)
            //{
            //    Debug.Log(_nodePathList[i]);
            //}
        //}
    }

    public int FindClosestNode()
    {
        Vector3 playerPosition = gameObject.transform.position;
        Vector3[] NodePosition = new Vector3[6];

        for (int i = 0; i < g._nodeList.Count; i++)
        {
            NodePosition[i] = g._nodeList[i].GetNodeVector();
        }

        List<float> distance = new List<float>(6);
        float shortDist = Vector3.Distance(playerPosition, NodePosition[0]);
        int shortDistNode = 0;

        for (int i = 0; i < g._nodeList.Count; i++)
        {
            distance.Add(Vector3.Distance(playerPosition, NodePosition[i]));

            if (shortDist > distance[i])
            {
                shortDist = distance[i];
                shortDistNode = i;
            }
        }

        return shortDistNode;
    }

    public void pathfollow()
    {
        Vector3 targetPosition = _waypoints[_currentPointIndex];

        _desiredVelocity = seek(_waypoints[_currentPointIndex]);

        //현재 속도
        Vector3 currentVelocity = _rigidbody.velocity;

        //조종힘
        Vector3 seekForce = _desiredVelocity.normalized * _seekStrength;

        _rigidbody.velocity = (currentVelocity + seekForce).normalized * _speed;

        if (Vector3.Distance(targetPosition, gameObject.transform.position) < _waypointRange)
        {
            _currentPointIndex++;

            ////마지막 좌표에 도착했으면 첫번째 좌표로 돌아가기
            //if (_currentPointIndex == _waypoints.Length)
            //{
            //   _currentPointIndex = 0;
            //}
        }
    }

    private Vector3 seek(Vector3 target)
    {
        _desiredVelocity = (target - transform.position).normalized * _speed;

        // y축의 값이 있을 수 있으므로, 최초에 0으로 만들어 y축의 값을 사용하지 않도록 한다.
        _desiredVelocity.y = 0.0f;

        return _desiredVelocity - _currentVelocity;
    }
}
