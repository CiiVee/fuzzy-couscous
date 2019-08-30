using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour {
    [SerializeField]
    public Text counterText;
    [SerializeField]
    public Image fillImg;
    
    public bool timeCounter = true;
    public GameState state;
    [SerializeField]
    public float seconds, maxTime, fill;
    
    
	// Use this for initialization
	void Start () {
        seconds = maxTime;

        counterText = GameObject.FindGameObjectWithTag("Timer").GetComponentInChildren<Text>();
        fillImg = GameObject.FindGameObjectWithTag("Timer").GetComponentInChildren<Image>(); ;
	}

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.Playing)
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
    }

    public void endGame()
    {
        timeCounter = false;
        counterText.color = Color.yellow;
        counterText.text = "0.00";
        
    }
}
