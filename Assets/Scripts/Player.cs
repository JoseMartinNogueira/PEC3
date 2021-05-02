using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    LevelManager lvl;
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            lvl = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        }
    }
    public bool Move(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) < 0.5)
        {
            direction.x = 0;
        }
        else
        {
            direction.y = 0;
        }
        direction.Normalize();
        if(Blocked(this.transform.position, direction)){
            return false;
        }
        else
        {
            transform.Translate(direction);
            return true;
        }
    }

    private bool Blocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPosition = new Vector2(position.x, position.y) + direction;
        int[,] map = lvl.GetTileMap().tiles;
      
        if(map[(int)newPosition.x,(int)newPosition.y] == 1)
        {
            return true;
        }
        if(map[(int)newPosition.x, (int)newPosition.y] == 3)
        {
            lvl.nextLevel();
        }
        List<GameObject> boxes = lvl.getBoxes();
        foreach (var box in boxes)
        {
            if(box.transform.position.x == newPosition.x && box.transform.position.y == newPosition.y)
            {
                Box auxBox = box.GetComponent<Box>();
                if( auxBox && auxBox.MoveBox(direction))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        return false;
    }
}
