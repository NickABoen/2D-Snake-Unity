using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapSystem : MonoBehaviour {

    public GameObject Background;
    public GameObject Wall;
    public Vector2 Map_Size;

    private List<GameObject> Current_Map;

    public void Start()
    {
        Current_Map = new List<GameObject>();
    }

    public void GenerateBasicMap()
    {
        CreateBackground();
        //Create Top Wall
        for(int i = 0; i < Map_Size.x; i++)
        {
            Vector2 position_offset = new Vector2(Map_Size.x / 2, Map_Size.y / 2);
            CreateWall(new Vector2(i - position_offset.x, 0 - position_offset.y));
        }

        //Create Bottom Wall
        for(int i = 0; i < Map_Size.x; i++)
        {
            Vector2 position_offset = new Vector2(Map_Size.x / 2, Map_Size.y / 2);
            CreateWall(new Vector2(i - position_offset.x, position_offset.y));
        }

        //Create Left Wall
        for(int i = 0; i < Map_Size.y; i++)
        {
            Vector2 position_offset = new Vector2(Map_Size.x / 2, Map_Size.y / 2);
            CreateWall(new Vector2(0 - position_offset.x, i - position_offset.y));
        }

        //Create Right Wall
        for(int i = 0; i < Map_Size.y; i++)
        {
            Vector2 position_offset = new Vector2(Map_Size.x / 2, Map_Size.y / 2);
            CreateWall(new Vector2(position_offset.x, i - position_offset.y));
        }
    }

    private void CreateBackground()
    {
        GameObject new_background = Instantiate(Background);

        new_background.transform.localScale.Set(Map_Size.x, Map_Size.y, new_background.transform.localScale.z);
        new_background.transform.position.Set(Map_Size.x / 2, Map_Size.y / 2, new_background.transform.position.z);

        Current_Map.Add(new_background);
    }

    private void CreateWall(Vector2 position)
    {
        GameObject new_wall = Instantiate(Wall);
        new_wall.transform.position.Set(position.x, position.y, new_wall.transform.position.z);
        Current_Map.Add(new_wall);
    }

    public void ClearMap()
    {
        Current_Map.Clear();
    }
}
