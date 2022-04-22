using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private Dictionary<int, GameObject> tileSet;
    private Dictionary<int, GameObject> tileGroups;
    private int mapWidth = 25;
    private int mapHeight = 25;
    private List<List<int>> noiseGrid = new List<List<int>>();
    private List<List<GameObject>> tileGrid = new List<List<GameObject>>();
    public GameObject prefabWallBlack;
    public GameObject prefabFloor;

    private float magnification = 7.0f;
    private int xOffset = 0;
    private int yOffset = 0;
    
    void Start()
    {
        CreateTileSet();
        CreateTileGroups();
        GenerateMap();
    }
    
    private void CreateTileSet()
    {
        tileSet = new Dictionary<int, GameObject>()
        {
            {0, prefabWallBlack},
            {1, prefabFloor}
        };
    }

    private void CreateTileGroups()
    {
        tileGroups = new Dictionary<int, GameObject>();
        foreach (var keyValuePair in tileSet)
        {
            GameObject tileGroup = new GameObject(keyValuePair.Value.name);
            tileGroup.transform.parent = gameObject.transform;
            tileGroup.transform.localPosition = new Vector3(0, 0, 0);
            tileGroups.Add(keyValuePair.Key, tileGroup);
        }
    }

    private void GenerateMap()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            noiseGrid.Add(new List<int>());
            tileGrid.Add(new List<GameObject>());
            for (int y = 0; y < mapWidth; y++)
            {
                int tileId = GetIdUsingPerline(x, y);
                noiseGrid[x].Add(tileId);
                CreateTile(tileId, (x, y));
            }
        }
    }

    private int GetIdUsingPerline(int x, int y)
    {
        float rewPerlin =  Mathf.PerlinNoise(
            (x - xOffset) / magnification, 
            (y - yOffset) / magnification
            );
        float clampPerlin = Mathf.Clamp(rewPerlin, 0.0f, 1.0f);
        float scalePerlin = clampPerlin * tileSet.Count;

        if (scalePerlin == 2)
        {
            scalePerlin = 1;
        }

        return Mathf.FloorToInt(scalePerlin);
    }

    private void CreateTile(int tileId, (int x, int y) coordinate)
    {
        GameObject tilePrefab = tileSet[tileId];
        GameObject tileGroup = tileGroups[tileId];
        GameObject tile = Instantiate(tilePrefab, tileGroup.transform);

        tile.name = string.Format("tileX{0}Y{1}", coordinate.x, coordinate.y);
        tile.transform.localPosition = new Vector3(coordinate.x, coordinate.y, 0);
        
        tileGrid[coordinate.x].Add(tile);
    }
}
