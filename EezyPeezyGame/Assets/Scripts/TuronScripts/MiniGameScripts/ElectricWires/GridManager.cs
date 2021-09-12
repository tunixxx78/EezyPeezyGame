using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Abandoned part of minigame -> creating grid for background

public class GridManager : MonoBehaviour
{
    [SerializeField] int rows = 6, cols = 8;
    [SerializeField] float tileSize = 1;

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        GameObject referenceTile = (GameObject)Instantiate(Resources.Load("ElectricTileBase"));

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject tile = (GameObject)Instantiate(referenceTile, transform);

                float posX = col * tileSize;
                float posY = row * -tileSize;

                tile.transform.position = new Vector2(posX, posY);
            }
        }

        Destroy(referenceTile);

        float gridW = cols * tileSize;
        float gridH = rows * tileSize;

        transform.position = new Vector2(-gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2);
    }

}
