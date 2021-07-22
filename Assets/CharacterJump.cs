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

    public AudioSource audioSource;
    public AudioClip clip;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            if(jumpCount < limitJumpCount){
                jumpCount += 1;
                rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "ground")
        {
            jumpCount = 0;
        }else if(other.gameObject.tag == "enemy"){
            EnemySaurus enemy = other.gameObject.GetComponent<EnemySaurus>();
            enemy.OnDamage();

            rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            audioSource.clip = clip;
            audioSource.volume = SoundManager.I.Volume;
            audioSource.Play();
        }

    }
}
