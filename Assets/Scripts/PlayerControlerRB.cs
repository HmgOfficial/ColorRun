using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlerRB : MonoBehaviour {

    private Rigidbody2D rb;

    public float movementForce = 5;
    public string playerColor;
    public float jumpForce = 0.5f;
    public SpriteRenderer sr;
    public float score;
    private float scoreMultiplier;
    private int baseScore;
    public int hp;
    private bool isGrounded;
    private float gravity = -9.8f;
    private Vector2 direction;
    public CanvasController canvasController;
    private bool invulnerability;
    private float invulnerabilityTimer;
    public string gameMode = "Easy";
    public AudioSource playerSFX;
    public AudioClip GroundHitClip;
    public AudioClip JumpClip;
    public Animator animator;
    public GameObject soundManager;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
        playerColor = "";
        score = 0;
        scoreMultiplier = 1;
        baseScore = 5;
        hp = 3;
        isGrounded = false;
        invulnerability = true;
        canvasController.hudPanel.SetActive(true);
        /*if ()
        {
            playerSFX.mute = true;
        }
        else
        {
            playerSFX.mute = false;
        }*/
        
    }
	
	// Update is called once per frame
	void Update () {
        //Physics();
        if (hp <= 0)
        {
            canvasController.ActiveLostPanel();
            Time.timeScale = 0;
        }
        //print(isGrounded);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ToYellow();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ToBlue();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ToRed();
        }
        if (invulnerabilityTimer >= 0)
        {
            StartCoroutine("Invulnerability");
            //Invulnerability();
        }
        else
        {
            invulnerability = false;
            sr.enabled = true;
        }
    }
    void FixedUpdate()
    {
        Movement();
        Gravity();
        //Jump();
        //Jump2();
    }
    void Gravity()
    {
        if (isGrounded == false)
        {
            direction.y -= gravity * Time.deltaTime;
        }
        
    }
    void Movement()
    {
        direction = new Vector2((Vector2.right.magnitude * movementForce * Time.deltaTime), rb.velocity.y);
        rb.velocity = direction;
        
    }
    public void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {   
            //print("X inicio: " + transform.position.x); Comprobacion 1 de salto en X
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    void Physics()
    {
        if (isGrounded == false)
        {
            direction.y -= gravity * Time.deltaTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }
    public void Jump2()
    {
        //print(isGrounded);
        if (isGrounded)
        {
            playerSFX.clip = JumpClip;
            playerSFX.Play();
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    public void ToYellow()
    {
        animator.SetTrigger("Yellow");
        playerColor = "Yellow";
        sr.color = Color.white;
    }
    public void ToBlue()
    {
        animator.SetTrigger("Blue");
        playerColor = "Blue";
        sr.color = Color.white;
    }
    public void ToRed()
    {
        animator.SetTrigger("Red");
        playerColor = "Red";
        sr.color = Color.white;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print(collision.gameObject.name);
        if (collision.transform.tag == "Floor")
        {
            playerSFX.clip = GroundHitClip;
            playerSFX.Play();
            isGrounded = true;
            /*if (playerColor != "Black")
            {
                playerColor = "Black";
                sr.color = Color.black;
            }*/


        }
        //print(collision.transform.name);
        if (collision.transform.tag == playerColor && (collision.transform.tag == "Yellow" || collision.transform.tag == "Blue" || collision.transform.tag == "Red"))
        {

            isGrounded = true;
            if (invulnerability == false)
            {
                Score();
            }
            
        }
        else if (collision.transform.tag != playerColor && (collision.transform.tag == "Yellow" || collision.transform.tag == "Blue" || collision.transform.tag == "Red"))
        {
            isGrounded = true;
            if (invulnerability == false)
            {
                WrongColor(collision.gameObject);
            }
            
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.transform.tag == "Floor")
        {

            isGrounded = true;
            if (playerColor != "Black" && gameMode == "Hard")
            {
                playerColor = "Black";
                sr.color = Color.black;
            }

        }

        if (collision.transform.tag == playerColor && (collision.transform.tag == "Yellow" || collision.transform.tag == "Blue" || collision.transform.tag == "Red"))
        {

            isGrounded = true;
            if (invulnerability == false)
            {
                Score();
            }

        }
        else if (collision.transform.tag != playerColor && (collision.transform.tag == "Yellow" || collision.transform.tag == "Blue" || collision.transform.tag == "Red"))
        {
            isGrounded = true;
            if (invulnerability == false)
            {
                WrongColor(collision.gameObject);
            }

        }
    }
    
    void Score()
    {
        score += (scoreMultiplier * baseScore);
        scoreMultiplier += 0.1f;
    }
    void WrongColor(GameObject platform)
    {

        invulnerability = true;
        invulnerabilityTimer = 1.5f;
        hp--;
        scoreMultiplier = 1;
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.name + collision.tag);
        if (collision.tag == "Goal")
        {
            canvasController.ActiveWinPanel();
            canvasController.hudPanel.SetActive(false);
            Time.timeScale = 0;
        }
        else if (collision.tag == "LostFloor")
        {
            canvasController.ActiveLostPanel();
            canvasController.hudPanel.SetActive(false);
            Time.timeScale = 0;
        }
        else if (collision.tag == "Tutorial")
        {
            canvasController.tutorialPanel.gameObject.SetActive(false);
        }
    }
    IEnumerator Invulnerability()
    {
        invulnerabilityTimer -= Time.deltaTime;
        if (sr.isVisible)
        {
            sr.enabled = false;
        }
        else
        {
            sr.enabled = true;
        }
        yield return 0;
    }

}
