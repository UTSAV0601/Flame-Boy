using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject losePanel;
    public Text healthDisplay;
    public float speed;
    private float input;
    Rigidbody2D rb;
    Animator anim;
    AudioSource source;
    public int health;

    // to decide how long our dash last
    public float startDashTime;
    private float dashTime;
    public float extraSpeed;
    private bool isDashing;


    void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        //stores rigidbody2D component that is attach to the player characte
        rb = GetComponent<Rigidbody2D>();
        healthDisplay.text = health.ToString();
    }
    private void Update()
    {
        if (input != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        // one way of setting the rotation value of object( x, y, z)
        Vector3 cscale = transform.localScale;

        if (input > 0)
        {
            cscale.x = 1;
        }
        if (input < 0)
        {
            cscale.x = -1;
        }

        transform.localScale = cscale;


        // to check wether space key was pressed
        if ( Input.GetKeyDown(KeyCode.Space) && isDashing == false )
        {
            speed += extraSpeed;
            isDashing = true;
            dashTime = startDashTime;
        }

        //to restrict the dash and decrease its spped to normal.
        if(dashTime <= 0 && isDashing == true)
        {
            isDashing = false;
            speed -= extraSpeed;
        }
        // to make sure that dash doesn't actually come to an end.
        else
        {
            dashTime -= Time.deltaTime;
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //sorting player's input
        input = Input.GetAxis("Horizontal");

        //moving player
        rb.velocity = new Vector2(input * speed, rb.velocity.y);

    }
        // function to store damage to the character
    public void TakeDamage(int damageAmount)
    {
        // to play the hurt sound of character 
        source.Play();
        health -= damageAmount;
        healthDisplay.text = health.ToString();

        if (health <= 0)
        {
            // to enable lose screen.
            losePanel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
