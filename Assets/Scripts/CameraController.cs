using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public PlayerControlerRB player;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = player.gameObject.transform.position - transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        
        transform.position = new Vector3(player.gameObject.transform.position.x - offset.x, transform.position.y , player.gameObject.transform.position.z - offset.z);
	}
}
