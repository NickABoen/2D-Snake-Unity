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
        Camera.main.orthographicSize = Mathf.Max(Map_Size.x / 2, Map_Size.y / 2);
        GenerateBasicMap();
    }

    public void GenerateBasicMap()
    {
        //Create Horizontal Walls
        for(int i = 0; i < Map_Size.x; i++)
        {
            Vector2 position_offset = new Vector2(Map_Size.x / 2, (Map_Size.y / 2) - 1);
            Vector2 top_position = new Vector2(i, 0) - position_offset;
            Vector2 bottom_position = new Vector2(i, Map_Size.y - 1) - position_offset;
            CreateWall(top_position);
            CreateWall(bottom_position);
        }

        //Create Vertical Walls
        for(int i = 0; i < Map_Size.y - 2; i++)
        {
            Vector2 position_offset = new Vector2(Map_Size.x / 2, ((Map_Size.y/2) - 2));
            Vector2 left_position = new Vector2(0, i) - position_offset;
            Vector2 right_position = new Vector2(Map_Size.x - 1, i) - position_offset;
            CreateWall(left_position);
            CreateWall(right_position);
        }

        CreateBackground();
    }

    private void CreateBackground()
    {
        GameObject new_background = Instantiate(Background);

        new_background.transform.localScale = Map_Size;
        //new_background.transform.position = new Vector2(Map_Size.x / 2, Map_Size.y / 2);

        Current_Map.Add(new_background);
    }

    private void CreateWall(Vector2 position)
    {
        GameObject new_wall = Instantiate(Wall);
        new_wall.transform.position = position + new Vector2(0.5f, -0.5f);
        Current_Map.Add(new_wall);
    }

    public void ClearMap()
    {
        Current_Map.Clear();
    }
}
