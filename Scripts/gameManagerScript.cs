using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
//Chester Porcioncula Velasco BSCS 4 Class of 2019
public enum GameState
{
    Playing,
    GameOver,
    Paused
}

public enum GameMode
{
    Binary,
    Octal,
    Hexa
}

public class gameManagerScript : MonoBehaviour {
    System.Random rnd = new System.Random();
    //Selected Elements
    //ELEMENT TEXT AND NUMBER
    [SerializeField]
    private string elementText;
    public string Binary, Octal, Hexa;
    public int sum = 0;
    public int deci = 21;
    //ElementColors
    public Sprite[] blue;
    public Sprite[] green;
    public Sprite[] red;
    public Sprite[] octal;
    public Sprite[] hexa;
    public Sprite transparent;
    public int elementNumber;
    //Nodes
    public Tile[] tileCombination;
    public int Score = 0;
    public int numberOfActivatedTiles = 0;
    //Game State if Playing, Paused, Gameover etc.
    public GameState State;
    public GameMode GameMode;
    //Panels
    public GameObject pausePanel;
    public GameObject resetFlagsButton;
    public GameObject gameOverPanel;
    public int gameMode = 1;
    public GameObject binaryFieldPanel;
    public GameObject octalFieldPanel;
    public GameObject hexaFieldPanel;
    public Text BinaryText;
    public Text DecimalText;
    public Text MatchText;
    public Text ScoreText;
    public Text GameModeText;
    public Text GameOverScore;
    
    //BGM
    public bool backPlay = true;
    public bool sfxPlay = true;
    //SOUND FX
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;
    //TIMER TEXT
    [SerializeField]
    public Text counterText;
    [SerializeField]
    public Image fillImg;
    public bool timeCounter = true;
    [SerializeField]
    public float seconds, maxTime, fill;
    public double second;
    
	// Use this for initialization
	void Start () {
        State = GameState.Playing;
        GameMode = GameMode.Binary;
        AudioListener.volume = 1;
        //Time
        seconds = maxTime;
        
        counterText = GameObject.FindGameObjectWithTag("Timer").GetComponentInChildren<Text>();
        fillImg = GameObject.FindGameObjectWithTag("Timer").GetComponentInChildren<Image>();
        //INITIALIZATION ON SCRIPT

        deci = rnd.Next(0, 255);
        MatchText.text = deci.ToString();

        if (GameMode == GameMode.Binary)
            ApplyBinaryStyle();
        else if (GameMode == GameMode.Octal)
            ApplyOctalStyle();
        else if (GameMode == GameMode.Hexa)
            ApplyHexaStyle();
	}
    
    public void ApplyBinaryStyle()
    {
        int i = 0;
        //BINARY DISPLAY
        nodeController[] AllTilesOneDim = GameObject.FindObjectsOfType<nodeController>();
        foreach (nodeController t in AllTilesOneDim)
        {
            //t.transform.Find("Element").GetComponent<Image>().sprite = blue[3];<---------
            elementText = t.elementText;
            if (string.Equals(t.elementNumber, "00"))
            {
                if (i == 0)
                {
                    t.transform.Find("Element").GetComponent<Image>().sprite = blue[0];
                    t.colorText = "Blue";
                    i++;
                }
                else if (i == 1)
                {
                    t.transform.Find("Element").GetComponent<Image>().sprite = red[0];
                    t.colorText = "Red";
                    i++;
                }
                else if (i == 2)
                {
                    t.transform.Find("Element").GetComponent<Image>().sprite = green[0];
                    t.colorText = "Green";
                    i = 0;
                }
            }
            else if (string.Equals(t.elementNumber, "01"))
            {
                if (i == 0)
                {
                    t.transform.Find("Element").GetComponent<Image>().sprite = blue[1];
                    t.colorText = "Blue";
                    i++;
                }
                else if (i == 1)
                {
                    t.transform.Find("Element").GetComponent<Image>().sprite = red[1];
                    t.colorText = "Red";
                    i++;
                }
                else if (i == 2)
                {
                    t.transform.Find("Element").GetComponent<Image>().sprite = green[1];
                    t.colorText = "Green";
                    i = 0;
                }
            }
            else if (string.Equals(t.elementNumber, "10"))
            {
                if (i == 0)
                {
                    t.transform.Find("Element").GetComponent<Image>().sprite = blue[2];
                    t.colorText = "Blue";
                    i++;
                }
                else if (i == 1)
                {
                    t.transform.Find("Element").GetComponent<Image>().sprite = red[2];
                    t.colorText = "Red";
                    i++;
                }
                else if (i == 2)
                {
                    t.transform.Find("Element").GetComponent<Image>().sprite = green[2];
                    t.colorText = "Green";
                    i = 0;
                }
            }
            else if (string.Equals(t.elementNumber, "11"))
            {
                if (i == 0)
                {
                    t.transform.Find("Element").GetComponent<Image>().sprite = blue[3];
                    t.colorText = "Blue";
                    i++;
                }
                else if (i == 1)
                {
                    t.transform.Find("Element").GetComponent<Image>().sprite = red[3];
                    t.colorText = "Red";
                    i++;
                }
                else if (i == 2)
                {
                    t.transform.Find("Element").GetComponent<Image>().sprite = green[3];
                    t.colorText = "Green";
                    i = 0;
                }
            }
        }
    }

    public void ApplyHexaStyle()
    {
        //HEXA DISPLAY
        nodeController[] AllTilesOneDim = GameObject.FindObjectsOfType<nodeController>();
        foreach (nodeController t in AllTilesOneDim)
        {
            //t.transform.Find("Element").GetComponent<Image>().sprite = blue[3];<---------
            elementText = t.elementText;
            if (string.Equals(t.elementText, "0"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = hexa[0];
            }
            else if (string.Equals(t.elementText, "1"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = hexa[1];
            }
            else if (string.Equals(t.elementText, "2"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = hexa[2];
            }
            else if (string.Equals(t.elementText, "3"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = hexa[3];
            }
            else if (string.Equals(t.elementText, "4"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = hexa[4];
            }
            else if (string.Equals(t.elementText, "5"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = hexa[5];
            }
            else if (string.Equals(t.elementText, "6"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = hexa[6];
            }
            else if (string.Equals(t.elementText, "7"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = hexa[7];
            }
            else if (string.Equals(t.elementText, "8"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = hexa[8];
            }
            else if (string.Equals(t.elementText, "9"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = hexa[9];
            }
            else if (string.Equals(t.elementText, "A"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = hexa[10];
            }
            else if (string.Equals(t.elementText, "B"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = hexa[11];
            }
            else if (string.Equals(t.elementText, "C"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = hexa[12];
            }
            else if (string.Equals(t.elementText, "D"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = hexa[13];
            }
            else if (string.Equals(t.elementText, "E"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = hexa[14];
            }
            else if (string.Equals(t.elementText, "F"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = hexa[15];
            }
        }
    }

    public void ApplyOctalStyle()
    {
        //OCTAL DISPLAY
        nodeController[] AllTilesOneDim = GameObject.FindObjectsOfType<nodeController>();
        foreach (nodeController t in AllTilesOneDim)
        {
            //t.transform.Find("Element").GetComponent<Image>().sprite = blue[3];<---------
            elementText = t.elementText;
            if (string.Equals(t.elementText, "0"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = octal[0];
            }
            else if (string.Equals(t.elementText, "1"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = octal[1];
            }
            else if (string.Equals(t.elementText, "2"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = octal[2];
            }
            else if (string.Equals(t.elementText, "3"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = octal[3];
            }
            else if (string.Equals(t.elementText, "4"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = octal[4];
            }
            else if (string.Equals(t.elementText, "5"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = octal[5];
            }
            else if (string.Equals(t.elementText, "6"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = octal[6];
            }
            else if (string.Equals(t.elementText, "7"))
            {
                t.transform.Find("Element").GetComponent<Image>().sprite = octal[7];
            }
        }
    }

    static int BinaryToDec(string input)
    {
        char[] array = input.ToCharArray();
        Array.Reverse(array);
        int sum = 0;      
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == '1')
            {
                if (i == 0)
                    sum += 1;
                else
                    sum += (int)Mathf.Pow(2, i);
            }
        }
        return sum;
    }
    private void GameOver()
    {
        State = GameState.GameOver;
    }

    public void bgmToggle()
    {
        if (backPlay)
        {
            AudioListener.pause = true;
            backPlay = false;
        }
        else
        {
            AudioListener.pause = false;
            backPlay = true;
        }
    }

    public void sfxToggle()
    {
        if (sfxPlay)
        {
            sound1.volume = 0;
            sound2.volume = 0;
            sound3.volume = 0;
            sfxPlay = false;
        }
        else
        {
            sound1.volume = 1;
            sound2.volume = 1;
            sound3.volume = 1;
            sfxPlay = true;
        }
    }

    public void pauseGame(bool trigger)
    {
        if (trigger)
        {
            State = GameState.Paused;
            trigger = true;
            pausePanel.SetActive(true);
        }
        else if(!trigger)
        {
            State = GameState.Playing;
            trigger = false;
            pausePanel.SetActive(false);
        }

    }

	// Update is called once per frame
	void Update () {
        if (State == GameState.GameOver)
        {
            binaryFieldPanel.SetActive(false);
            octalFieldPanel.SetActive(false);
            hexaFieldPanel.SetActive(false);
        }

        if (GameMode == GameMode.Binary)
        {
            GameModeText.text = "Binary Bomb";
            BinaryText.text = Binary;
            binaryFieldPanel.SetActive(true);
            octalFieldPanel.SetActive(false);
            hexaFieldPanel.SetActive(false);
        }
        else if (GameMode == GameMode.Octal)
        {
            GameModeText.text = "Octal Bomb";
            BinaryText.text = Octal;
            octalFieldPanel.SetActive(true);
            binaryFieldPanel.SetActive(false);
            hexaFieldPanel.SetActive(false);
        }
        else if (GameMode == GameMode.Hexa)
        {
            GameModeText.text = "Hexadecimal Bomb";
            BinaryText.text = Hexa;
            hexaFieldPanel.SetActive(true);
            binaryFieldPanel.SetActive(false);
            octalFieldPanel.SetActive(false);
        }

        if (State == GameState.Paused)
        {
            if (GameMode == GameMode.Binary)
            {
                binaryFieldPanel.SetActive(false);
                octalFieldPanel.SetActive(false);
                hexaFieldPanel.SetActive(false);
            }
            else if (GameMode == GameMode.Octal)
            {
                octalFieldPanel.SetActive(false);
                binaryFieldPanel.SetActive(false);
                hexaFieldPanel.SetActive(false);
            }
            else if (GameMode == GameMode.Hexa)
            {
                hexaFieldPanel.SetActive(false);
                binaryFieldPanel.SetActive(false);
                octalFieldPanel.SetActive(false);
            }
        }
        //BINARY DISPLAY
        sum = BinaryToDec(Binary);
        DecimalText.text = sum.ToString();
        

        //TIME
        second = Math.Round(seconds);
        if (State == GameState.Playing)
        {
            if (timeCounter)
            {
                if (seconds > 0)
                {
                    seconds -= Time.deltaTime;
                    fillImg.fillAmount = seconds / maxTime;
                    fill = fillImg.fillAmount;
                    counterText.text = seconds.ToString("F");
                }
                else
                    endGame();
            }
        }

        //TimerBar Color
        if (seconds >= 135)
            fillImg.GetComponent<Image>().color = new Color32(110, 195, 115, 255); //green
        else if (seconds >= 90)
            fillImg.GetComponent<Image>().color = new Color32(255, 195, 30, 255); //orange
        else if (seconds >= 45)
            fillImg.GetComponent<Image>().color = new Color32(240, 80, 80, 255); //red
        else
        {
            if(second%2 == 0)
                fillImg.GetComponent<Image>().color = new Color32(240, 80, 80, 255); //red
            else
                fillImg.GetComponent<Image>().color = new Color32(255, 195, 30, 255); //yellow
        }


        if (State == GameState.GameOver)
        {
            endGame();
        }

        //SCORE

        if (string.Equals(MatchText.text, sum.ToString()))
        {
            sound3.Play();
            Score = Score + sum;
            ScoreText.text = Score.ToString();
            deci = rnd.Next(0, 255);
            MatchText.text = deci.ToString();
            seconds = seconds + 5;
            ResetFlags();
            gameMode = gameMode + 1;
            if(gameMode == 1)
                GameMode = GameMode.Binary;
            else if (gameMode == 2)
            {
                GameMode = GameMode.Octal;
            }
            else if (gameMode == 3)
            {
                GameMode = GameMode.Hexa;
                gameMode = 0;
            }
        }
        if (numberOfActivatedTiles == 0)
            resetFlagsButton.SetActive(false);
        else
            resetFlagsButton.SetActive(true);
	}

    public void endGame()
    {
        timeCounter = false;
        counterText.color = Color.yellow;
        counterText.text = "0.00";
        gameOverPanel.SetActive(true);
        GameOverScore.text = "Final Score:\n" + Score.ToString();
        State = GameState.GameOver;
    }

    public void ResetFlags()
    {
        sound2.Play();
        Binary = "";
        Hexa = "";
        Octal = "";
        if (GameMode == GameMode.Binary)
            ApplyBinaryStyle();
        else if (GameMode == GameMode.Octal)
            ApplyOctalStyle();
        else if (GameMode == GameMode.Hexa)
            ApplyHexaStyle();
        nodeController[] AllTilesOneDim = GameObject.FindObjectsOfType<nodeController>();
        foreach (nodeController t in AllTilesOneDim)
        {
            t.Awake();
        }
        numberOfActivatedTiles = 0;
    }
}
