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

    }

    private GameObject CreateBackground()
    {
        GameObject new_background = Instantiate(Background);

        new_background.transform.localScale.Set(Map_Size.x, Map_Size.y, new_background.transform.localScale.z);
        new_background.transform.position.Set(Map_Size.x / 2, Map_Size.y / 2, new_background.transform.position.z);

        return new_background;
    }

    private GameObject CreateWall(Vector2 position)
    {
        GameObject new_wall = Instantiate(Wall);
        new_wall.transform.position.Set(position.x, position.y, new_wall.transform.position.z);
        return new_wall;
    }

    public void ClearMap()
    {
        Current_Map.Clear();
    }
}
