using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class nodeController : MonoBehaviour
{
    //Selected Elements

    public static bool DO_NOT = false;
    [SerializeField]
    public int nodeState;
    
    private Image TileImage;
    [SerializeField]
    private Sprite element;
    [SerializeField]
    public string elementText;
    public string colorText;
    public string elementNumber;

    private Sprite holder;
    
    
    public gameManagerScript gmScript;

    public void Awake()
    {
        TileImage = transform.Find("Element").GetComponent<Image>();
        element = transform.Find("Element").GetComponent<Image>().sprite;
        nodeState = 0;
    }

    void Start()
    {
        nodeState = 0;
    }

    public void flipNode()
    {
        if (gmScript.GameMode == GameMode.Binary)
        {
            if (gmScript.numberOfActivatedTiles < 4)
            {

                if (nodeState == 0)
                {
                    gmScript.sound1.Play();
                    if (gmScript.Binary.Length < 8)
                    {
                        gmScript.Binary += elementNumber;
                    }

                    holder = gameObject.transform.Find("Element").GetComponent<Image>().sprite;
                    gameObject.transform.Find("Element").GetComponent<Image>().sprite = gmScript.transparent;
                    nodeState = 1;
                    gmScript.numberOfActivatedTiles = gmScript.numberOfActivatedTiles + 1;
                }
                else
                {
                    gmScript.sound2.Play();
                    gameObject.transform.Find("Element").GetComponent<Image>().sprite = holder;
                    nodeState = 0;
                    gmScript.numberOfActivatedTiles = gmScript.numberOfActivatedTiles - 1;
                    gmScript.ResetFlags();
                }
            }
            else if (nodeState == 1)
            {
                gmScript.sound2.Play();
                gameObject.transform.Find("Element").GetComponent<Image>().sprite = holder;
                nodeState = 0;
                gmScript.numberOfActivatedTiles = gmScript.numberOfActivatedTiles - 1;
                gmScript.ResetFlags();
            }
            else
                Debug.Log("DEACTIVATE TILE FIRST!");
        }

        else if (gmScript.GameMode == GameMode.Hexa)
        {
            if (gmScript.numberOfActivatedTiles < 2)
            {
                if (nodeState == 0)
                {
                    gmScript.Hexa += elementText;
                    gmScript.sound1.Play();
                    if (gmScript.Binary.Length < 8)
                    {
                        gmScript.Binary += elementNumber;
                    }
                    holder = gameObject.transform.Find("Element").GetComponent<Image>().sprite;
                    nodeState = 1;
                    gmScript.numberOfActivatedTiles = gmScript.numberOfActivatedTiles + 1;
                }
                else if (nodeState == 1)
                {
                    gmScript.Hexa += elementText;
                    gmScript.sound1.Play();
                    if (gmScript.Binary.Length < 8)
                    {
                        gmScript.Binary += elementNumber;
                    }
                    gameObject.transform.Find("Element").GetComponent<Image>().sprite = holder;
                    gameObject.transform.Find("Element").GetComponent<Image>().sprite = gmScript.transparent;
                    nodeState = 2;
                    gmScript.numberOfActivatedTiles = gmScript.numberOfActivatedTiles + 1;
                }
                else
                {
                    gmScript.sound2.Play();
                    gameObject.transform.Find("Element").GetComponent<Image>().sprite = holder;
                    nodeState = 0;
                    gmScript.numberOfActivatedTiles = gmScript.numberOfActivatedTiles - 2;
                }
            }
            else if (gmScript.numberOfActivatedTiles == 2)
            {
                gmScript.sound2.Play();
                gameObject.transform.Find("Element").GetComponent<Image>().sprite = holder;
                nodeState = 0;
                gmScript.numberOfActivatedTiles = gmScript.numberOfActivatedTiles - 1;
                gmScript.ResetFlags();
            }
            else
                Debug.Log("DEACTIVATE TILE FIRST!");
        }

        else if (gmScript.GameMode == GameMode.Octal)
        {
            if (gmScript.numberOfActivatedTiles < 3)
            {
                if (nodeState == 0)
                {
                    gmScript.Octal += elementText;
                    gmScript.sound1.Play();
                    if (gmScript.Binary.Length < 8)
                    {
                        gmScript.Binary += elementNumber;
                    }

                    holder = gameObject.transform.Find("Element").GetComponent<Image>().sprite;
                    nodeState = 1;
                    gmScript.numberOfActivatedTiles = gmScript.numberOfActivatedTiles + 1;
                }
                else if (nodeState == 1)
                {
                    gmScript.Octal += elementText;
                    gmScript.sound1.Play();
                    if (gmScript.Binary.Length < 8)
                    {
                        gmScript.Binary += elementNumber;
                    }
                    gameObject.transform.Find("Element").GetComponent<Image>().sprite = holder;
                    gameObject.transform.Find("Element").GetComponent<Image>().sprite = gmScript.transparent;
                    nodeState = 2;
                    gmScript.numberOfActivatedTiles = gmScript.numberOfActivatedTiles + 1;
                }
                else
                {
                    gmScript.sound2.Play();
                    gameObject.transform.Find("Element").GetComponent<Image>().sprite = holder;
                    nodeState = 0;
                    gmScript.numberOfActivatedTiles = gmScript.numberOfActivatedTiles - 2;
                    gmScript.ResetFlags();
                }
            }
            else if (gmScript.numberOfActivatedTiles == 2)
            {
                gmScript.sound2.Play();
                gameObject.transform.Find("Element").GetComponent<Image>().sprite = holder;
                nodeState = 0;
                gmScript.numberOfActivatedTiles = gmScript.numberOfActivatedTiles - 1;
                gmScript.ResetFlags();
            }
            else
                gmScript.ResetFlags();
        }
    }

    private void SetVisible()
    {
        TileImage.enabled = true;
    }

    private void SetEmpty()
    {
        TileImage.enabled = false;
    }

    public int state
    {
        get { return nodeState; }
        set { nodeState = value; }
    }
    
    public void Update()
    {
        /*timetoLoads = Mathf.RoundToInt(gmScript.seconds);
        //SPAWNING NEW TILE
        if (nodeLoading == true)
        {
            gameObject.transform.Find("Element").GetComponent<Image>().sprite = nodeLoad;
            Debug.Log("NodeLoading");
        }
        else if(timetoLoads == timetoLoad)
            nodeLoading = true;*/
    }

    /*public void falseCheck()
    {
        StartCoroutine(pause());
    }

    IEnumerator pause()
    {
        yield return new WaitForSeconds(0.2F);
        if (_state == 0)
            GetComponent<Image>().sprite = firstSelect;
        else if (_state == 1)
            GetComponent<Image>().sprite = secondSelect;
        DO_NOT = false;
    }*/
}
