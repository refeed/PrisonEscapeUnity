using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllerScript : MonoBehaviour

{
    public float runSpeed;
    Rigidbody rb;
    Animator anim;

    bool facingRight;

    //jump
    bool grounded = false;
    Collider[] groundCols;
    float groundRad = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHght;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        facingRight = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(grounded && Input.GetAxis("Jump") > 0){
            grounded = false;
            anim.SetBool("grounded", grounded);
            rb.AddForce(new Vector3(0, jumpHght,0));
        }
        groundCols = Physics.OverlapSphere(groundCheck.position, groundRad, groundLayer);
        if(groundCols.Length >0) grounded = true;
        else grounded = false;

        anim.SetBool("grounded", grounded);

        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(move));
        rb.velocity = new Vector3(move * runSpeed, rb.velocity.y, 0);

        if (move > 0 && !facingRight) Flip();
        else if ( move < 0 && facingRight) Flip();
    }
    void Flip(){
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
    }
}
