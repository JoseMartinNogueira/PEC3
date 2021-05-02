using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box : MonoBehaviour
{
    LevelManager lvl;
    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            lvl = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        }
    }
    public bool MoveBox(Vector2 direction)
    {
        if(BoxBlocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            return true;
        }
    }

    private bool BoxBlocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPosition = new Vector2(position.x, position.y) + direction;
        int[,] map = lvl.GetTileMap().tiles;
        if (map[(int)newPosition.x, (int)newPosition.y] == 1)
        {
            return true;
        }
        List<GameObject> boxes = lvl.getBoxes();
        foreach (var box in boxes)
        {
            if(box.transform.position.x == newPosition.x && box.transform.position.y == newPosition.y)
            {
                return true;
            }
        }
        return false;
    }
}
