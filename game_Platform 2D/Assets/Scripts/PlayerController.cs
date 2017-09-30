using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 2f;

    private float maxSpeed = 5f;
    private Rigidbody2D playerRgb;
    private Animator anim;
    public bool grounded;

	// Use this for initialization
	void Start () {
        playerRgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("speed", Mathf.Abs(playerRgb.velocity.x));
        anim.SetBool("Grounded", grounded);
	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");  //devuelve la direccion precionada
        playerRgb.AddForce(Vector2.right * speed * h);

        float limitSpeed = Mathf.Clamp(playerRgb.velocity.x, -maxSpeed, maxSpeed); //clamp: limita el valor entre uno maximo y minimo
        playerRgb.velocity = new Vector2(limitSpeed, playerRgb.velocity.y);

        if(h > 0.1f)
        {
            transform.localScale = Vector3.one;
        }
        else if( h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if( collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            grounded = false;
    }

}
