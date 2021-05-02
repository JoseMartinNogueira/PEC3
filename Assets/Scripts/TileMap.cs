using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class TileMap : MonoBehaviour
{


    public TileType[] tileTypes;

    public int[,] tiles;

    public int mapSizeX;
    public int mapSizeY;

    public int currentTileType = 0;
    //public bool player

    // Start is called before the first frame update
    void Start()
    {
        GenerateMapData();
        SpawnMap(tiles);
    }


    void GenerateMapData()
    {
        tiles = new int[mapSizeX, mapSizeY];
        for(int x = 0; x < mapSizeX; x++)
        {
            for(int y = 0; y < mapSizeY; y++)
            {
                tiles[x, y] = 0;
            }
        }
    }
    public void SpawnMap(int[,] mapInfo)
    {
        tiles = mapInfo;
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                if(tiles[x,y] != 0 ) {
                    var child = Instantiate(tileTypes[tiles[x,y]].tileVisualPrefab, new Vector3(x, y, -1), Quaternion.identity);
                    child.transform.parent = this.transform;
                }
                var ground = Instantiate(tileTypes[0].tileVisualPrefab, new Vector3(x, y, 0), Quaternion.identity);
                ground.transform.parent = this.transform;
            }
        }
    }

    public void ClearMap()
    {
        foreach(Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void SetValue(Vector3 worldPosition, GameObject gameObject )
    {
        int x = Mathf.FloorToInt(worldPosition.x);
        int y = Mathf.FloorToInt(worldPosition.y);
        if(x >= 0 && y >= 0 && x < mapSizeX && y < mapSizeY)
        {
            //if( (currentTileType == 3 && )
            if(gameObject.tag != "Ground") {
                Destroy(gameObject);
            }
            tiles[x, y] = currentTileType;
            int layer = -1;
            if(currentTileType == 0) {
                layer = 0;
            }
            var child = Instantiate(tileTypes[currentTileType].tileVisualPrefab, new Vector3(x, y, layer), Quaternion.identity);
            child.transform.parent = this.transform;
        }
    }
 }
