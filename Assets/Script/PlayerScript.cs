using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float runningSpeed;
    [SerializeField] float jumpSpeed;
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] TextMeshProUGUI pointText;
    [SerializeField] public int points = 0;

    void Start()
    {
        runningSpeed = 5f;
        jumpSpeed = 5f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Debug.Log("Mathf.Epsilon: " + Mathf.Epsilon);
        pointText.text = points.ToString();
    }

    void Update()
    {
        Run();

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && CheckGrounded())
        {
            rb.velocity = new Vector2 (rb.velocity.x, jumpSpeed);
        }

        //update point
        pointText.text = points.ToString();

        //eat coin
    }

    void Run()
    {
        //horizontal movement
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontal, 0f, 0f) * runningSpeed * Time.deltaTime;
        transform.Translate(movement);

        //flip sprite
        //FlipSprite();

        //animation transition
        bool playerHasHorizontalSpeed = Mathf.Abs(horizontal) > 0;
        
        animator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        float horizontal = Input.GetAxis("Horizontal");
        bool playerHasHorizontalSpeed = Mathf.Abs(horizontal) > 0;

        if (playerHasHorizontalSpeed)
        {
            float currentScaleX = transform.localScale.x;
            float newScaleX;
            if (horizontal < 0)
            {
                newScaleX = -currentScaleX;
            } else
            {
                newScaleX = currentScaleX;
            }
            float currentScaleY = transform.localScale.y;

            transform.localScale = new Vector2(newScaleX, currentScaleY);
        }
    }

    bool CheckGrounded()
    {
        // You may need to adjust the raycast length and layer mask based on your player's size and environment.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        return hit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Debug.Log("Eat coin");
        }
    }

    public void addToCoin(int point)
    {
        points = points + point;
        Debug.Log("point main: " + points);
    }
}
