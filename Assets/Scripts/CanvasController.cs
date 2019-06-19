using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour {

    public PlayerControlerRB playerControler;
    public Text hpText, scoreText;
    public GameObject lostPanel;
    public GameObject winPanel;
    public GameObject hudPanel;
    public GameObject pausePanel;
    public GameObject tutorialPanel;
    public GameManager gameManagerPrefab;
    public Button[] levelsButton;
    public Toggle hardToggle;
    


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        ActualizarCanvas();
	}
    void ActualizarCanvas()
    {
        hpText.text = playerControler.hp.ToString();
        scoreText.text = playerControler.score.ToString();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ActiveLostPanel()
    {
        lostPanel.SetActive(true);
    }
    public void ActiveWinPanel()
    {
        winPanel.SetActive(true);
    }
    public void DesactivLostPanel()
    {
        lostPanel.SetActive(false);
    }
    public void RefreshLevel()
    {
        for (int i = 0; i <= gameManagerPrefab.maxLevel; i++)
        {
            if (levelsButton[i].isActiveAndEnabled == false)
            {
                levelsButton[i].gameObject.SetActive(true);
            }
            if (gameManagerPrefab.currentLevel == gameManagerPrefab.maxLevel)
            {
                if (gameManagerPrefab.gameMode == GameManager.GameMode.Hard)
                {
                    hardToggle.GetComponent<Toggle>().interactable = false;
                }
                else if (gameManagerPrefab.gameMode == GameManager.GameMode.Easy)
                {
                    hardToggle.GetComponent<Toggle>().interactable = false;
                }
            }
            else if (gameManagerPrefab.currentLevel < gameManagerPrefab.maxLevel)
            {
                hardToggle.GetComponent<Toggle>().interactable = true;
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        hudPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        hudPanel.SetActive(true);
        pausePanel.SetActive(false);
    }
}
