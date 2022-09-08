using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rg2D;

    public bool faceR = true;
    private SpriteRenderer SpriteR;

    public float force;
    public bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Transform sightStart, sightEndH1, sightEndH2, sightEndV;
    public bool murH1 = false;
    public bool murH2 = false;
    public bool murV = false;

    void Start()
    {
        rg2D = GetComponent<Rigidbody2D>();
        SpriteR = GetComponent<SpriteRenderer>();
    }

  
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rg2D.AddForce(Vector2.right * speed * Time.deltaTime);

        float directionX = 0;

        if (Input.GetButton("Horizontal"))
                    directionX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        if (Input.GetAxis("Horizontal") < 0)
        {
            faceR = false;
            SpriteR.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            faceR = true;
            SpriteR.flipX = false;
        }

        if (directionX > 0 && murH1 == false)
            transform.Translate(directionX, 0, 0);

        if (directionX < 0 && murH2 == false)
            transform.Translate(directionX, 0, 0);

        if (isGrounded && murV || murH1 && murH2)
            Debug.Log("t mor");

        

        if (Input.GetButton("Jump") && isGrounded)
            rg2D.velocity = Vector2.up* force;

        Raycasting();
        Behaviours();

        }

    void Raycasting()
    {
        murH1 = Physics2D.Linecast(sightStart.position, sightEndH1.position, 1 << LayerMask.NameToLayer("Ground"));
        murH2 = Physics2D.Linecast(sightStart.position, sightEndH2.position, 1 << LayerMask.NameToLayer("Ground"));
        murV = Physics2D.Linecast(sightStart.position, sightEndV.position, 1 << LayerMask.NameToLayer("Ground"));
    }

    void Behaviours()
    {

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}
