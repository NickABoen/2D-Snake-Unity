using UnityEngine;
using System.Collections;

public static class ComponentFactory { 
    //Add public static creation methods here
    public static GameObject CreateSnakeSegment(bool isHeadSegment)
    {
        GameObject new_segment;
        if (isHeadSegment)
        {
            new_segment = AssetManager.Instantiate(AssetManager.Instance.Head_Segment_Prefab);
        }
        else
        {
            new_segment = AssetManager.Instantiate(AssetManager.Instance.Body_Segment_Prefab);
        }
        return new_segment;
    }
}
