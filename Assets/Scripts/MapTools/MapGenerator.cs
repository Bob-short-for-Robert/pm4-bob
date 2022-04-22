using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{
    private Dictionary<int, GameObject> tileSet;
    private Dictionary<int, GameObject> tileGroups;
    private (int x , int y) mapSize = (50, 50);
    private List<List<int>> noiseGrid = new List<List<int>>();
    private List<List<GameObject>> tileGrid = new List<List<GameObject>>();
    public GameObject prefabWallBlack;
    public GameObject prefabFloor;

    private int randomFillPercent = 35;
    
    void Start()
    {
        SetMapValue();
        CreateTileSet();
        CreateTileGroups();
        GenerateMap();
        SetMapObjects();
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        ClearMap();
        SetMapValue();
        GenerateMap();
        SetMapObjects();
    }

    private void ClearMap()
    {
        foreach (var mapY in tileGrid)
        {
            foreach (var tile in mapY)
            {
                GameObject.Destroy(tile.gameObject);
            }
        }
        noiseGrid.Clear();
        tileGrid.Clear();
        
    }

    private void SetMapValue()
    {
        randomFillPercent = (int) (Random.value * 10 + 35);
        mapSize.x = (int) (Random.value * 30 + 40);
        mapSize.y = (int) (Random.value * 30 + 40);
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
        List<List<bool>> mapMatrix = new MapMatrixGenerator().GetMapMatrix((mapSize.x, mapSize.y), randomFillPercent);
        
        for (int x = 0; x < mapSize.x; x++)
        {
            noiseGrid.Add(new List<int>());
            tileGrid.Add(new List<GameObject>());
            for (int y = 0; y < mapSize.y; y++)
            {
                int tileId = mapMatrix[x][y]? 0: 1;
                noiseGrid[x].Add(tileId);
                CreateTile(tileId, (x, y));
            }
        }
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

    private void SetMapObjects()
    {
        var player = GameObject.Find("Player");
        player.transform.localPosition = new Vector3(mapSize.x / 2, mapSize.x / 2, 0);
    }
}
