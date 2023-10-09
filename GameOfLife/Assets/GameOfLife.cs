using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GameOfLife : MonoBehaviour
{
    public GameObject cellPrefab;
    public GameObject pauseMenu;
    Cell[,] cells;
    float cellSize = 0.25f; // Size of our cells
    int numberOfColumns, numberOfRows;
    int neighbourCount;
    int spawnChancePercentage = 25;
    bool paused;
    void Start()
    {
        // Lower framerate makes it easier to test and see what's happening.
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 20;

        // Calculate our grid depending on size and cellSize
        numberOfColumns = Mathf.FloorToInt((Camera.main.orthographicSize * Camera.main.aspect * 2) / cellSize);
        numberOfRows = Mathf.FloorToInt((Camera.main.orthographicSize * 2) / cellSize);


        // Initiate our matrix array
        cells = new Cell[numberOfColumns, numberOfRows];

        // Create all objects
        // For each row
        for (int y = 0; y < numberOfRows; y++)
        {
            // For each column in each row
            for (int x = 0; x < numberOfColumns; x++)
            {
                // Create our game cell objects, multiply by cellSize for correct world placement
                Vector2 newPos = new Vector2(x * cellSize - Camera.main.orthographicSize * Camera.main.aspect, y * cellSize - Camera.main.orthographicSize);

                var newCell = Instantiate(cellPrefab, newPos, Quaternion.identity);
                newCell.transform.localScale = Vector2.one * cellSize;

                cells[x, y] = newCell.GetComponent<Cell>();


                if (Random.Range(0, 100) < spawnChancePercentage)
                {
                    cells[x, y].alive = true;

                }
                cells[x, y].UpdateStatus();
            }
        }
    }

    void Update()
    {
        PauseGame();
        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColumns; x++)
            {

                if (paused == false)
                {
                    
                    neighbourCount = 0;
                    GetNeighbor(x, y);


                    // Any live cell with fewer than two live neighbors dies (underpopulation)
                    if (neighbourCount < 2)
                    {
                        cells[x, y].alive = false; // Dead

                    }

                    // Any live cell with more than three live neighbors dies (overpopulation)
                    else if (neighbourCount > 3)
                    {
                        cells[x, y].alive = false; // Dead

                    }


                    // Any dead cell with exactly three live neighbors becomes a live cell (reproduction)
                    else if (neighbourCount == 3)
                    {
                        cells[x, y].alive = true; // Alive

                    }
                }
                else if (paused == true)
                {
                    continue;
                }


            }

        }
        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColumns; x++)
            {
                cells[x, y].UpdateStatus();
            }
        }





    }

    void GetNeighbor(int x, int y)
    {
        for (int xOffset = -1; xOffset <= 1; xOffset++)
        {
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {

                if (xOffset == 0 && yOffset == 0)
                {
                    continue; // Skip the current cell itself
                }

                int neighborX = x + xOffset;
                int neighborY = y + yOffset;

                // Check if neighborX and neighborY are within valid bounds
                if (neighborX >= 0 && neighborX < numberOfColumns && neighborY >= 0 && neighborY < numberOfRows)
                {
                    if (cells[neighborX, neighborY].cellState == 1)
                    {

                        neighbourCount++;
                    }
                }
            }
        }

    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            paused = true;
            pauseMenu.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            paused = false;
            pauseMenu.SetActive(false);
        }
    }



}