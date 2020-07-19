using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapGenerator : MonoBehaviour
{
    //Variables

    [Header("Tile Prefabs")]
    public GameObject[] gridPrefs;

    [Header("Grid Size")]
    public int rows;
    public int columns;

    public enum MapType
    {
        Seeded,
        Random,
        MapDay
    }

    [Header("Seed")]
    public MapType mapType = MapType.Random;
    public int mapSeed;

    private float roomWidth = 50.0f;
    private float roomHeight = 50.0f;

    private Room[,] genGrid;

    //Gets a random room
    public GameObject RandomRoomPref()
    {
        return gridPrefs[UnityEngine.Random.Range(0, gridPrefs.Length)];
    }

    //gets the date back
    public int DateToInt(DateTime dateUse)
    {
        return dateUse.Year + dateUse.Month + dateUse.Day + 
            dateUse.Hour + dateUse.Minute + dateUse.Second + 
            dateUse.Millisecond;
    }

    //Generates the grid randomly
    public void GenerateGrid()
    {
        UnityEngine.Random.InitState(mapSeed);
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

                RowDeactivate(curRow, temp);
                ColDeactivate(curCol, temp);

                genGrid[curCol, curRow] = temp;
            }
        }
    }

    //deactivates doors on the row
    void RowDeactivate(int curRow, Room temp)
    {
        if (rows == 1)
            return;

        if (curRow == 0)
            temp.doorNorth.SetActive(false);
        else if (curRow == rows - 1)
            temp.doorSouth.SetActive(false);
        else
        {
            temp.doorNorth.SetActive(false);
            temp.doorSouth.SetActive(false);
        }
    }

    //Deactivates doors on the columns
    private void ColDeactivate(int curCol, Room temp)
    {
        if (columns == 1)
            return;

        if (curCol == 0)
            temp.doorEast.SetActive(false);
        else if (curCol == rows - 1)
            temp.doorWest.SetActive(false);
        else
        {
            temp.doorWest.SetActive(false);
            temp.doorEast.SetActive(false);
        }
    }

    //Calls start game
    private void Start()
    {
        StartGame();
    }

    //detects what type of map to spawn
    public void StartGame()
    {
        switch(mapType)
        {
            case MapType.Seeded:
                break;
            case MapType.Random:
                mapSeed = DateToInt(DateTime.Now);
                break;
            case MapType.MapDay:
                mapSeed = DateToInt(DateTime.Now.Date);
                break;
            default:
                Debug.LogWarning("No Seed Type: MAPGENERATOR");
                break;
        }
        GenerateGrid();
        GameManager.Instance.SpawnPlayer();

        for(int i = 0; i < GameManager.Instance.numOfEnemies; i++)
        {
            GameManager.Instance.SpawnEnemy();
        }
    }
}