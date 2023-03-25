using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8f, maxVelocity = 4f;
    private Rigidbody2D myBody;
    private Animator anim;
    // Start is called before the first frame update

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMoveKeyboard();
    }

    void PlayerMoveKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        float h = CrossPlatformInputManager.GetAxis("Horizontal");//Input.GetAxisRaw ("Horizontal");
        if (h>0)
        {
            if (vel < maxVelocity)
                forceX = speed;

            Vector3 temp = transform.localScale;
            float localScale = temp.x;
            temp.x = 0.15f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
        }
        else if (h<0)
        { 
            if (vel < maxVelocity)
               forceX = -speed;

            Vector3 temp = transform.localScale;
            temp.x = -0.15f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        myBody.AddForce(new Vector2(forceX, 0));
    }
}
