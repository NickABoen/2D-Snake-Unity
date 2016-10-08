using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapSystem : MonoBehaviour {

    public GameObject Background;
    public GameObject Wall;
    public Vector2 Map_Size = new Vector2(10.0f, 10.0f);
    public Vector2 Tile_Size = new Vector2(1.0f, 1.0f);

    private List<GameObject> Current_Map;
    private Vector2 cam_size;

    public void Start()
    {
        Current_Map = new List<GameObject>();
        //Camera.main.orthographicSize = Mathf.Max(Map_Size.x / 2, Map_Size.y / 2);
        Vector2 new_camera_size = Map_Size;
        new_camera_size.Scale(Tile_Size);
        new_camera_size = new_camera_size / 2;
        Camera.main.orthographicSize = Mathf.Max(new_camera_size.x, new_camera_size.y);
        cam_size = new_camera_size;
        GenerateBasicMap();
    }

    public void GenerateBasicMap()
    {
        Vector2 byX, byY;
        byX = byY = Vector2.zero;
        Vector2 offset = (Map_Size / 2);
        offset.Scale(Vector2.left + Vector2.up);

        int max = (int)(Map_Size.x + Map_Size.y - 1);
        for(int i = 0; i < max; i++)
        {
            bool vectorsEqual = Vector2.SqrMagnitude(byX - byY) == 0;

            CreateWall(byX + offset);

            if(!vectorsEqual)
            {
                CreateWall(byY + offset);
            }

            byX += (Mathf.Abs(byX.x) < Map_Size.x-1) ? Vector2.right : Vector2.down;
            byY += (Mathf.Abs(byY.y) < Map_Size.y-1) ? Vector2.down : Vector2.right;
        }

        CreateBackground();
    }

    private void CreateBackground()
    {
        GameObject new_background = Instantiate(Background);

        Vector2 background_size = Map_Size;
        background_size.Scale(Tile_Size);
        new_background.transform.localScale = background_size;

        Current_Map.Add(new_background);
    }

    private void CreateWall(Vector2 position)
    {
        GameObject new_wall = Instantiate(Wall);
        new_wall.transform.localScale = Tile_Size;
        new_wall.transform.position = position + (Tile_Size / 2);
        Current_Map.Add(new_wall);
    }

    public void ClearMap()
    {
        Current_Map.Clear();
    }
}
