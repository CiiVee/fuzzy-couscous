using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class TileStyle
{
    public int Number;
    public string TileType;
    public string TileValue;
    public Sprite TileTextColor;
}


public class TileStyleHolder : MonoBehaviour
{

    // SINGLETON
    public static TileStyleHolder Instance;

    public TileStyle[] TileStyles;

    void Awake()
    {
        Instance = this;
    }
}
