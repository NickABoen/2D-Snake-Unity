﻿using UnityEngine;
using System.Collections;

public class AssetManager : Singleton<AssetManager>{
    protected AssetManager() { } //block the constructor from being used for a singleton

    //Anything can be added here now
    public GameObject Head_Segment_Prefab, Body_Segment_Prefab;
}
