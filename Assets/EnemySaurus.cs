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
/*
    void Start(){
        render = this.gameObject.GetComponentInChildren<SpriteRenderer>();
    }*/

    void Update()
    {
        if(isLeft){
            rigid.velocity = Vector2.left * moveSpeed;
            render.flipX = false;
        }else{
            rigid.velocity = Vector2.right * moveSpeed;
            render.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "wall")
        {
            isLeft = !isLeft;
        }
    }
}
