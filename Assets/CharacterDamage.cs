using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamage : MonoBehaviour
{
    public BoxCollider2D col1;
    public BoxCollider2D col2;
    public SpriteRenderer render;

    void OnDamage(){
        col1.enabled = false;
        col2.enabled = false;
        render.color = new Color(1, 1, 1, 0.5f);
        
        GameManager.I.GameOver();
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "enemy")
        {
            OnDamage();
        }
    }
}
