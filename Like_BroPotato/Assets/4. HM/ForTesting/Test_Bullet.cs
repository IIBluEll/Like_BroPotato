using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Bullet : MonoBehaviour
{
    public float damage;
    public int count;

    public float speed;

    Rigidbody2D rigid;

   
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Init(float damage,int count, float speed, Vector3 dir)
    {
        this.damage = damage;
        this.count = count;
        this.speed = speed;
        rigid.velocity = dir * speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Enemy"))
            return;

            count--;

            if(count == 0)
            {
                rigid.velocity = Vector2.zero;
                gameObject.SetActive(false);
            }
    }
}
