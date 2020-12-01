using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float jumpForce = 25f;

    ///////////////////////////////////
    [SerializeField]
    bool isJumping = false;
    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetKey(KeyCode.Space) && IsGrounded() && !isJumping) {
            isJumping = true;
            StartCoroutine(JumpRoutine());
        }
    }

    IEnumerator JumpRoutine() {
        //Add force on the first frame of the jump
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        //Wait while the character's y-velocity is positive (the character is going up)
        while (Input.GetButton("Jump") && rb.velocity.y > 0) {
            yield return null;
        }

        //If the jumpButton is released but the character's y-velocity is still
        //positive, set the character's y-velocity to 0
        if (rb.velocity.y > 0) {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        isJumping = false;
    }

    /// <summary>
    /// Check if the player is "grounded" by making a small raycast downwards and seeing if we find something designated as ground
    /// </summary>
    /// <returns></returns>
    bool IsGrounded() {
        float distToGround = GetComponent<CircleCollider2D>().bounds.extents.y;
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + 0.1f, LayerMask.GetMask("Ground"));
    }  
}
