using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    public PlayerControlerRB playerController;
    private bool playerYConmprobation = true;
    private BoxCollider2D collider_Platform;

    // Use this for initialization
    void Start ()
    {

        playerYConmprobation = true;
        collider_Platform = GetComponent<BoxCollider2D>();

    }
	
	// Update is called once per frame
	void Update () {
        //print(gameObject.GetComponent<BoxCollider2D>().isTrigger);
        if (playerYConmprobation)
        {

            if (playerController.transform.position.y <= transform.position.y)
            {
                collider_Platform.isTrigger = true;
            }
            else if (playerController.transform.position.y >= transform.position.y)
            {
                collider_Platform.isTrigger = false;
            }

        }
        
	}
}
