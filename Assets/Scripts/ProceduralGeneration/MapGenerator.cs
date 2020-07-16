using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] gridPrefs;

    public int rows;
    public int columns;

    private float roomWidth = 50.0f;
    private float roomHeight = 50.0f;

    private Room[,] genGrid;

    public GameObject RandomRoomPref()
    {
        return gridPrefs[Random.Range(0, gridPrefs.Length)];
    }

    public void GenerateGrid()
    {
        genGrid = new Room[columns, rows];

        for (int curRow = 0; curRow < rows; curRow++)
        {
            for(int curCol = 0; curCol < columns; curCol++)
            {
                float xPos = roomWidth * curCol;
                float zPos = roomHeight * curRow;
                Vector3 newPos = new Vector3(xPos, 0, zPos);

                GameObject tempRoom = Instantiate(RandomRoomPref(), newPos, Quaternion.identity, this.transform) as GameObject;

                tempRoom.name = "Room_" + curCol + " , " + curRow;

                Room temp = tempRoom.GetComponent<Room>();

                if (rows == 1)
                {

                }
                else if (curRow == 0)
                {
                    temp.doorNorth.SetActive(false);
                }
                else if (curRow == rows - 1)
                {
                    temp.doorSouth.SetActive(false);
                }
                else
                {
                    temp.doorNorth.SetActive(false);
                    temp.doorSouth.SetActive(false);
                }

                if (columns == 1)
                {

                }
                else if (curCol == 0)
                {
                    temp.doorEast.SetActive(false);
                }
                else if (curCol == rows - 1)
                {
                    temp.doorWest.SetActive(false);
                }
                else
                {
                    temp.doorWest.SetActive(false);
                    temp.doorEast.SetActive(false);
                }

                genGrid[curCol, curRow] = temp;
            }
        }
    }

    void Start()
    {
        GenerateGrid();
    }
}