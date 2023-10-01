using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    public GameObject cellPrefab;
    
    Cell[,] cells;
    float cellSize = 0.25f;
    int numberOfColumn, numberOfRows;
    int spawnChancePercentage = 1;

    // Start is called before the first frame update
    void Start()
    {
        numberOfColumn = (int)Mathf.Floor((Camera.main.orthographicSize * Camera.main.aspect * 2) / cellSize);
        numberOfRows = (int)Mathf.Floor(Camera.main.orthographicSize * 2 / cellSize);
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 2;

        cells = new Cell[numberOfColumn, numberOfRows];
    }

    // Update is called once per frame
    void Update()
    {
        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColumn; x++) // Use numberOfColumn here
            {
                Vector2 newPos = new Vector2(x * cellSize - Camera.main.orthographicSize * Camera.main.aspect, y * cellSize - Camera.main.orthographicSize);

                cells[x, y] = Instantiate(cellPrefab, newPos, Quaternion.identity).GetComponent<Cell>();

                //if (System.Random.Range(0, 100) < spawnChancePercentage)
                //{
                //    cells[x, y].alive = true;
                //    cells[x, y].UpdateStatus();

                //    // Activate the left neighbor
                //    CellNeighbour leftNeighbor = new CellNeighbour(cells[x, y]);
                //}
            }
        }
    }

    public class CellNeighbour
    {
        public Cell cell;
        private float cellSize = 0.25f;
        public Vector2 cellPosition;
        public float[] xOffset = {-1,1};
        public float[] yOffset = {-1, 1};
        public CellNeighbour(Cell cell)
        {
            this.cell = cell;
            cellPosition = cell.transform.position;
            Vector2 neighborPosition = new Vector2(cellPosition.x - cellSize, cellPosition.y);

            
            Cell Neighbor = FindCellAtPosition(neighborPosition);

            if (Neighbor.alive == false)
            {
                Neighbor.alive = true;
                Neighbor.UpdateStatus();
            }
        }
        private Cell FindAllPositions() 
        {
            return cell;
        }

        private Cell FindCellAtPosition(Vector2 position)
        {
            foreach (Cell cell in GameObject.FindObjectsOfType<Cell>())
            {
                if (Vector2.Distance(cell.transform.position, position) < 0.01f)
                {
                    return cell;
                }
            }
            return null; 
        }
    }
}

