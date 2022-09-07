using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rg2D;

    public float force;
    public bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    void Start()
    {
        rg2D = GetComponent<Rigidbody2D>();
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

        transform.Translate(directionX, 0, 0);

        if (Input.GetButton("Jump") && isGrounded == true)
        {
            Debug.Log("saut");
            //rg2D.velocity = new Vector2(rg2D.velocity.x, force);
            rg2D.velocity = Vector2.up* force;
        }


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
