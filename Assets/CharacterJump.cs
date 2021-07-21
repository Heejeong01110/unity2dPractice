using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float jumpHeight;
    bool isGrounded;
    int jumpCount = 0;
    int limitJumpCount = 2;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            if(jumpCount < limitJumpCount){
                jumpCount += 1;
                rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            }
        }
        /*
        if(isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow)){
            isGrounded = false;
        }
        */
    }

    public void OnTriggerEnter2D(Collider2D other) {
        /*
        if(other.gameObject.tag== "ground"){
            isGrounded = true;
            jumpCount = 0;
        }
        */

        if (other.gameObject.tag == "ground")
        {
            jumpCount = 0;
        }

    }
}
