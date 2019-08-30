using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour {
    public bool mergedThisTurn = false;
	 
	public int indRow;
	public int indCol;

    public int number;

    public string TileType;
    public string TileValue;
    public Sprite TileTextColor;

    void Awake()
    {
        Debug.Log("Applied");
        ApplyStyle(number);

        this.transform.Find("Element").GetComponent<Image>().sprite = TileTextColor;
    }

    void ApplyStyleFromHolder(int index)
    {
        TileType = TileStyleHolder.Instance.TileStyles[index].TileType;
        TileValue = TileStyleHolder.Instance.TileStyles[index].TileValue;
        TileTextColor = TileStyleHolder.Instance.TileStyles[index].TileTextColor;
    }

    void ApplyStyle(int num)
    {
        switch (num)
        {
            case 0:
                ApplyStyleFromHolder(0);
                break;
            case 1:
                ApplyStyleFromHolder(1);
                break;
            case 2:
                ApplyStyleFromHolder(2);
                break;
            case 3:
                ApplyStyleFromHolder(3);
                break;
            default:
                Debug.LogError("Check the numbers that you pass to ApplyStyle!");
                break;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
