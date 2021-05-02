using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public int prefab;
    public void changePrefab()
    {
        TileMap tilemap = GameObject.Find("Map").GetComponent<TileMap>();
        tilemap.currentTileType = prefab;
    }

    public void saveMap()
    {
        TileMap tileMap = GameObject.Find("Map").GetComponent<TileMap>();
        SaveAndLoad.saveMap(tileMap);
    }

    public void loadMapGame()
    {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().loadLevel(GameObject.Find("InputField").GetComponentInChildren<Text>().text);
    }
    public void loadMap()
    {
        TileMap tileMap = GameObject.Find("Map").GetComponent<TileMap>();
        string level = GameObject.Find("InputField").GetComponentInChildren<Text>().text;
        SaveAndLoad.loadMap(tileMap, level);
    }

    public void loadEditor()
    {
        SceneManager.LoadScene("Editor");
    } 

    public void loadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void returnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
