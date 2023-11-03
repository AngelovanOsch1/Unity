using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2D;
    public GameObject lastCheckpoint;
    public Lives livesScript;

    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        moveSpeed = 3f;
        jumpForce = 60f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {

        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }

        if (moveVertical > 0.1f && !isJumping)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);     
            isJumping = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
    public void Respawn()
    {
        if (livesScript.GetLives() > 0)
        {
            if (lastCheckpoint != null)
            {
                transform.position = lastCheckpoint.transform.position;
            }
            else
            {
                // Handle case where there's no last checkpoint set
                // For example, respawn at a default position.
                // transform.position = defaultRespawnPosition;
            }

            livesScript.UpdateLives(livesScript.GetLives() - 1);
        }
        else
        {
            // Game Over Logic
        }
    }

}