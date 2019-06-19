using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int currentLevel;
    public int maxLevel;
    public GameObject[] levels;
    public enum GameMode {Easy,Hard};
    public GameMode gameMode;
    public GameManager gameManagerPrefab;
    public bool music;
    public bool sfx;



	// Use this for initialization
	void Start () {
        //Instantiate(levels[currentLevel], Vector3.zero, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Change2EasyMode()
    {
        gameMode = GameMode.Easy;
    }
    public void Change2HardMode()
    {
        gameMode = GameMode.Hard;
    }
    public void ActualizarNivel()
    {
        if (currentLevel -1 == maxLevel)
        {
            gameManagerPrefab.maxLevel++;
            maxLevel = gameManagerPrefab.maxLevel;
        }
    }
}
