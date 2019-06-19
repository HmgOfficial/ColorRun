using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuController : MonoBehaviour {

    public GameObject panel_Levels;
    public GameObject panel_Settings;
    public GameObject panel_Main;
    public GameObject panel_Credits;
    public GameManager gameManager;
    public Button[] levelButtons;
    public Toggle sfxToggle;
    public Toggle musicToggle;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Levels()
    {
        if (panel_Levels.gameObject.activeInHierarchy == true)
        {
            LevelDefine(EventSystem.current.currentSelectedGameObject.name);
            print(gameManager.currentLevel);
            Back();
            return;
        }
        panel_Levels.SetActive(true);
    }
    public void Settings()
    {
        panel_Settings.SetActive(true);
    }
    public void Back()
    {
        panel_Levels.SetActive(false);
        panel_Settings.SetActive(false);
        panel_Main.SetActive(true);
        
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void LevelDefine(string levelName)
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (levelButtons[i].name == levelName)
            {
                gameManager.currentLevel = i+1;
                return;
            }
        }
    }
    public void Credits()
    {
        if (panel_Credits.activeInHierarchy == false)
        {
            panel_Credits.gameObject.SetActive(true);
        }
        else
        {
            panel_Credits.gameObject.SetActive(false);
        }
    }
    /*public void Sound()
    {
        if (musicToggle.isOn == false)
        {
            gameManager.music = false;
        }
        else
	    {
            gameManager.music = true;
        }
    }
    public void SFX()
    {
        if (sfxToggle.isOn == false)
        {
            print(gameManager.sfx);
            gameManager.sfx = true;
        }
        else
        {
            print(gameManager.sfx);
            gameManager.sfx = false;
        }
    }*/
}
