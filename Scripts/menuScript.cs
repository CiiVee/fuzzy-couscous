using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class menuScript : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject GameModePanel;
    public GameObject HowToPlayPanel;
    public GameObject HowToPlayPanel2;
    public GameObject HowToPlayPanel3;

    
    public void triggerMenu(int trigger)
    {
        Debug.Log("Clicked");
        switch (trigger)
        {
            case (0):
                //Load BINARY Mode
                SceneManager.LoadScene("GameScene");
                break;
            case (1):
                //Quit Game
                Application.Quit();
                break;
            case (2):
                //Load Settings
                SettingsPanel.SetActive(true);
                break;
            case (3):
                //Load Main Menu
                SceneManager.LoadScene("MenuScene");
                SceneManager.UnloadSceneAsync("GameScene");
                break;
            case (4):
                //Load How To Play
                HowToPlayPanel.SetActive(true);
                break;
            case (5):
                //Load How To Play 2
                HowToPlayPanel.SetActive(false);
                HowToPlayPanel2.SetActive(true);
                break;
            case (6):
                //UnLoad How To Play
                HowToPlayPanel2.SetActive(false);
                HowToPlayPanel3.SetActive(true);
                break;
            case (7):
                //UnLoad How To Play
                HowToPlayPanel3.SetActive(false);
                break;
        }
    }

    public void OnMouseUp()
    {
        //Back Button
        Debug.Log("Back Button Clicked");
        this.transform.parent.gameObject.SetActive(false);
    }
}
