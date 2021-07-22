using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySaurus : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rigid;
    public SpriteRenderer render;
    public float moveSpeed;
    bool isLeft = true;
    bool isDead = false;

    void Update()
    {
        if(isDead){
            return;
        }
        if(isLeft){
            rigid.velocity = Vector2.left * moveSpeed;
            render.flipX = false;
        }else{
            rigid.velocity = Vector2.right * moveSpeed;
            render.flipX = true;
        }
    }

    public void OnDamage()
    {
        BoxCollider2D col = gameObject.GetComponent<BoxCollider2D>();
        col.enabled = false;
        render.color = new Color(1, 1, 1, 0.5f);
        isDead = true;
        rigid.AddForce(Vector2.up * 8, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "wall")
        {
            isLeft = !isLeft;
        }
    }
}
