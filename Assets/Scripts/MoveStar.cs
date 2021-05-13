using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStar : MonoBehaviour
{
    public float walkSpeed = 15f;
    public float jumpSpeed = 5f;
    public bool useForce; // true para usar AddForce, false para velocity
    Rigidbody2D rigidbody;
    Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        useForce = false;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Input.GetAxis("Horizontal") * walkSpeed;
        Vector2 vel;
                // Pulo
        vel = new Vector2(delta, rigidbody.velocity.y);
        if(useForce)
            vel = new Vector2(delta,0);
        
        // Pulo
        if(collider.IsTouchingLayers(LayerMask.GetMask("Ground"))
            && Input.GetButtonDown("Jump"))
        {
            vel += new Vector2(0,jumpSpeed);
        }

        if(useForce && rigidbody.velocity.magnitude < 5)
            rigidbody.AddForce(vel, ForceMode2D.Impulse);
        else
            rigidbody.velocity = vel;
    }
}
