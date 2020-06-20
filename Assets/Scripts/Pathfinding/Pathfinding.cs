using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    private EnemyPersonality personallity;
    Grid grid;
    public Transform startPos;
    public Transform targetPos;

    private void Awake()
    {
        personallity = GetComponent<EnemyPersonality>();
        grid = GameManager.gamemanager.GetComponent<Grid>();
        startPos = transform;
        targetPos = personallity.target;
    }

    private void Update()
    {
        FindPath(startPos.position, targetPos.position);
    }

    void FindPath(Vector3 a_startPos, Vector3 a_targetPos)
    {
        Node startNode = grid.NodeFromWorldPosition(a_startPos);
        Node targetNode = grid.NodeFromWorldPosition(a_targetPos);

        List<Node> openList = new List<Node>();
        HashSet<Node> closedList = new HashSet<Node>();

        openList.Add(startNode);

        while(openList.Count > 0)
        {
            Node curNode = openList[0];
            for(int i = 1; i < openList.Count; i++)
            {
                if(openList[i].FCost < curNode.FCost || openList[i].FCost == curNode.FCost && openList[i].hCost < curNode.hCost)
                {
                    curNode = openList[i];
                }
            }
            openList.Remove(curNode);
            closedList.Add(curNode);

            if(curNode == targetNode)
            {
                GetFinalPath(startNode, targetNode);
            }

            foreach(Node NeighborNode in grid.GetNeighboringNode(curNode))
            {
                if(!NeighborNode.isWall || closedList.Contains(NeighborNode))
                {
                    continue;
                }
                int moveCost = curNode.gCost + GetManhattenDistance(curNode, NeighborNode);

                if(moveCost < NeighborNode.gCost || !openList.Contains(NeighborNode))
                {
                    NeighborNode.gCost = moveCost;
                    NeighborNode.hCost = GetManhattenDistance(NeighborNode, targetNode);
                    NeighborNode.parent = curNode;

                    if(!openList.Contains(NeighborNode))
                    {
                        openList.Add(NeighborNode);
                    }
                }
            }
        }
    }

    void GetFinalPath(Node a_startingNode, Node a_endNode)
    {
        List<Node> finalPath = new List<Node>();
        Node currentNode = a_endNode;

        while(currentNode != a_startingNode)
        {
            finalPath.Add(currentNode);
            currentNode = currentNode.parent;
        }

        finalPath.Reverse();

        grid.finalPath = finalPath;
    }

    int GetManhattenDistance(Node a_NodeA, Node a_NodeB)
    {
        int ix = Mathf.Abs(a_NodeA.gridX - a_NodeB.gridX);
        int iy = Mathf.Abs(a_NodeA.gridY - a_NodeB.gridY);

        return ix + iy;
    }
}
