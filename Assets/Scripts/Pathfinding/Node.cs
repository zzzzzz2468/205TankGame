using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    //X and Y postion in node array
    public int gridX;
    public int gridY;

    //node obstructed or not
    public bool isWall;

    //position
    public Vector3 position;

    //store node it came from
    public Node parent;

    //cost to get to next square and goal
    public int gCost;
    public int hCost;

    //add gCost and hCost for FCost
    public int FCost { get { return gCost + hCost; } }

    //Constructor
    public Node(bool a_isWall, Vector3 a_Pos, int a_gridX, int a_gridY)
    {
        isWall = a_isWall;
        position = a_Pos;
        gridX = a_gridX;
        gridY = a_gridY;
    }
}
