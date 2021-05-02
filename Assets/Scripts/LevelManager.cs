using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private TileMap map;
    private List<GameObject> boxes;

    private bool inputReady;
    public Player player;
    private int currentLevel;
    private bool newLevel = false;
    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find("Map").GetComponent<TileMap>();
        SaveAndLoad.loadMap(map, "1");
        player = GameObject.Find("Character(Clone)").GetComponent<Player>();
        BoxList();
        currentLevel = 1;
    }
    private void FixedUpdate()
    {
        if(newLevel)
        {
            player = GameObject.Find("Character(Clone)").GetComponent<Player>();
            BoxList();
            newLevel = false;
        }
        else
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveInput.Normalize();
            if(moveInput.sqrMagnitude > 0.5)
            {
                if (inputReady)
                {
                    inputReady = false;
                player.Move(moveInput);
                }
            }
            else
            {
                inputReady = true;
            }
        }
        
    }

    public TileMap GetTileMap()
    {
        return map;
    }

    void BoxList()
    {
        boxes = new List<GameObject>(GameObject.FindGameObjectsWithTag("Box"));
    }
    public List<GameObject> getBoxes()
    {
        return boxes;
    }

    public void nextLevel()
    {
        currentLevel++;
        SaveAndLoad.loadMap(map, currentLevel.ToString());
        newLevel = true;
    }
    public void loadLevel(string lvl)
    {
        SaveAndLoad.loadMap(map, lvl);
        currentLevel = int.Parse(lvl);
        newLevel = true;
    }
}
