using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private LayerMask platformLayerMask;
    public Rigidbody2D rb;
    public Vector2 moveVector;
    public float Speed = 1f;
    public float accSpeed = 1.5f;
    public float JumpForce = 5f;
    private bool Switch = true;
    private CapsuleCollider2D capsuleCollider2D;
    Animator animator;
    private bool FacingRight = true;
    public bool isFacingRight = true;


    public Vector3 characterScreenPos;
    public Camera cam;

    void Start()
    {
        animator = GetComponent<Animator>();
        platformLayerMask = LayerMask.GetMask("Platform");
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

        characterScreenPos = cam.WorldToScreenPoint(transform.position);
        Debug.Log(Input.mousePosition);
        FlipCharacter();
        if (isOnGround())
        {
            Jump();
            Walk();
        }

    }
  

    void Walk()
    {

        moveVector.x = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(moveVector.x) * Speed);



        rb.velocity = new Vector2(Speed * moveVector.x, rb.velocity.y);

        if (Input.GetKey(KeyCode.LeftShift) && Switch == true && Mathf.Abs(rb.velocity.x) > 0 && isOnGroundLeft() == true)
        {

            Speed = accSpeed;
            Switch = false;
        }

        if (rb.velocity.x == 0 && Switch == false)
        {
            Speed = 1f;
            Switch = true;
        }

    }
    void Jump()
    {


        if (Input.GetKeyDown(KeyCode.Space) && isOnGround())
        {
            animator.Play("Main_char_jump");
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

    }
    private bool isOnGroundLeft()
    {
        float additionalHeightValue = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(new Vector2(capsuleCollider2D.bounds.min.x, capsuleCollider2D.bounds.center.y), Vector2.down, capsuleCollider2D.bounds.extents.y + additionalHeightValue, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(new Vector2(capsuleCollider2D.bounds.min.x, capsuleCollider2D.bounds.min.y), Vector2.down * additionalHeightValue, rayColor);
        return raycastHit.collider != null;
    }


    private bool isOnGroundRight()
    {
        float additionalHeightValue = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(new Vector2(capsuleCollider2D.bounds.max.x, capsuleCollider2D.bounds.center.y), Vector2.down, capsuleCollider2D.bounds.extents.y + additionalHeightValue, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(new Vector2(capsuleCollider2D.bounds.max.x, capsuleCollider2D.bounds.min.y), Vector2.down * additionalHeightValue, rayColor);
        return raycastHit.collider != null;
    }
    private bool isOnGround()
    {
        if (isOnGroundLeft() || isOnGroundRight())
            return true;
        else
            return false;
    }

    private void FlipCharacter()
    {
        if (moveVector.x < 0 && FacingRight)
        {
            Flip();
            isFacingRight = false;
        }
        else
            if (moveVector.x > 0 && !FacingRight)
        {
            Flip();
            isFacingRight = true;
        }
    }
    private void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
}
