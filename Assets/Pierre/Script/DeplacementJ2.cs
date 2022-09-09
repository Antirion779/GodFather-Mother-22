using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.U2D;

public class DeplacementJ2 : MonoBehaviour
{
    public float speed, move;
    private Rigidbody2D rg2D;

    public bool faceR = true;
    private SpriteRenderer SpriteR;
    private SpriteRenderer spriteChapo;

    public float force;
    public bool isGrounded, isPlayered;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers; 
    public LayerMask playerLayers;

    public Transform sightStart, sightEndH1, sightEndH2, sightEndV;
    public bool murH1 = false;
    public bool murH2 = false;
    public bool murV = false;

    public bool playerH1 = false;
    public bool playerH2 = false;
    public bool playerV = false;

    public GameObject p1, p2, barre1, barre2, spawn, winj2, chapo;


    void Start()
    {
        rg2D = GetComponent<Rigidbody2D>();
        SpriteR = GetComponent<SpriteRenderer>();
        spriteChapo = chapo.GetComponent<SpriteRenderer>();
    }

  
    void Update()
    {
        /*float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //rg2D.AddForce(Vector2.right * speed * Time.deltaTime);*/

        float directionX = 0;

        var move = 0;


        if (Input.GetKey(KeyCode.Q))
        {
            move = -1;
            directionX = move * speed * Time.deltaTime;
            //directionX -= Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            faceR = false;
            SpriteR.flipX = true;
            spriteChapo.flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            move = 1;
            directionX = move * speed * Time.deltaTime;
            //directionX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            faceR = true;
            SpriteR.flipX = false;
            spriteChapo.flipX = false;
        }


        if (directionX > 0 && murH1 == false && playerH1 == false)
            transform.Translate(directionX, 0, 0);

        if (directionX < 0 && murH2 == false && playerH2 == false)
            transform.Translate(directionX, 0, 0);


        if ((isGrounded || isPlayered) && murV || murH1 && murH2)
            Death();


        if (Input.GetButtonDown("Jump") && (isGrounded || isPlayered) && playerV == false)
        {
            rg2D.velocity = Vector2.up * force;
            SoundManager.Instance.PlayPlayerJump(transform.position, 0.5f);
        }

        Raycasting();
        Behaviours();

        
    }

    void Raycasting()
    {
        murH1 = Physics2D.Linecast(sightStart.position, sightEndH1.position, 1 << LayerMask.NameToLayer("Ground"));
        murH2 = Physics2D.Linecast(sightStart.position, sightEndH2.position, 1 << LayerMask.NameToLayer("Ground"));
        murV = Physics2D.Linecast(sightStart.position, sightEndV.position, 1 << LayerMask.NameToLayer("Ground"));
        playerH1 = Physics2D.Linecast(sightStart.position, sightEndH1.position, 1 << LayerMask.NameToLayer("Player1"));
        playerH2 = Physics2D.Linecast(sightStart.position, sightEndH2.position, 1 << LayerMask.NameToLayer("Player1"));
        playerV = Physics2D.Linecast(sightStart.position, sightEndV.position, 1 << LayerMask.NameToLayer("Player1"));
    }

    void Behaviours()
    {

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        isPlayered = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, playerLayers);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    private void Death()
    {
        SoundManager.Instance.PlayPlayerDeath(transform.position, 1.0f);
        p1.SetActive(false);
        p2.SetActive(false);
        if (barre1 != null)
            barre1.SetActive(false);
        if (barre2 != null)
            barre2.SetActive(false);
        spawn.SetActive(false);
        winj2.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            Death();
        }
    }

}
