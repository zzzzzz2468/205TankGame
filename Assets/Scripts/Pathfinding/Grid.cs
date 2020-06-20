using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Transform startPos;
    public LayerMask wallMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public float Distance;

    Node[,] grid;
    public List<Node> finalPath;

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    private void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector3 bottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;
        for(int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = bottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool wall = true;

                if (Physics.CheckSphere(worldPoint, nodeRadius, wallMask))
                    wall = false;

                grid[x, y] = new Node(wall, worldPoint, x, y);
            }
        }
    }

    public Node NodeFromWorldPosition(Vector3 a_worldPos)
    {
        float xpoint = ((a_worldPos.x + gridWorldSize.x / 2) / gridWorldSize.x);
        float ypoint = ((a_worldPos.z + gridWorldSize.y / 2) / gridWorldSize.y);

        xpoint = Mathf.Clamp01(xpoint);
        ypoint = Mathf.Clamp01(ypoint);

        int x = Mathf.RoundToInt((gridSizeX - 1) * xpoint);
        int y = Mathf.RoundToInt((gridSizeY - 1) * ypoint);

        return grid[x, y];
    }

    public List<Node> GetNeighboringNode(Node a_Node)
    {
        List<Node> neighboringNodes = new List<Node>();
        int xCheck;
        int yCheck;

        //RightSide
        xCheck = a_Node.gridX + 1;
        yCheck = a_Node.gridY;
        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                neighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //LeftSide
        xCheck = a_Node.gridX - 1;
        yCheck = a_Node.gridY;
        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                neighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //TopSide
        xCheck = a_Node.gridX;
        yCheck = a_Node.gridY + 1;
        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                neighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //BottomSide
        xCheck = a_Node.gridX;
        yCheck = a_Node.gridY - 1;
        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                neighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        return neighboringNodes;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

        if(grid != null)
        {
            foreach(Node node in grid)
            {
                if (node.isWall)
                    Gizmos.color = Color.white;
                else
                    Gizmos.color = Color.yellow;


                if (finalPath != null)
                {
                    if(finalPath.Contains(node))
                        Gizmos.color = Color.red;
                }

                Gizmos.DrawCube(node.position, Vector3.one * (nodeDiameter - Distance));
            }
        }
    }
}
