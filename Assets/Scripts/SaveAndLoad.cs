using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public static void saveMap(TileMap tileMap)
    {
        int fileID = 1;
        while (File.Exists(Application.dataPath + "/Maps/map" + fileID + ".txt"))
        {
            fileID++;
        }
        string strOutPut = Utils.JsonHelper.ToJson<int>(Utils.to1DArray(tileMap.tiles));
        Debug.Log("ID " + fileID);
        File.WriteAllText("Assets/Maps/map" + fileID + ".txt", strOutPut);
    }
    
    public static void loadMap(TileMap tileMap, string strId)
    {
        string level = File.ReadAllText("Assets/Maps/map" + strId + ".txt");
        int[] arrayData = Utils.JsonHelper.FromJson<int>(level);
        int offSetX = tileMap.mapSizeX;
        int offSetY= tileMap.mapSizeX;
        int[,] mapData = new int[offSetX, offSetY];
        for (int x = 0; x < offSetX; ++x)
        {
            for(int y = 0; y < offSetY; ++y)
            {
                mapData[x, y] = arrayData[x * offSetY + y];
            }
        }
        tileMap.ClearMap();
        tileMap.SpawnMap(mapData);
        
    }
}
