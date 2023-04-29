using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Bullet : MonoBehaviour
{
  public float damage;
  public int count;

  public float speed;
  public float hitRate;

  Rigidbody2D rigid;


  private void Awake()
  {
    rigid = GetComponent<Rigidbody2D>();
  }

  public void Init(float _damage, int _count, float _speed, float _hitRate, Vector3 dir)
  {
    this.damage = _damage;
    this.count = _count;
    this.speed = _speed;
    this.hitRate = _hitRate;

    rigid.velocity = dir * _speed;
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    float randNum = Random.Range(1, 101);

    if (other.CompareTag("Enemy"))
    {
      if (randNum < hitRate)
      {
        count--;
      }
      if (count == 0)
      {
        rigid.velocity = Vector2.zero;
        gameObject.SetActive(false);
      }
    }
    else if (other.CompareTag("Wall"))
    {
      gameObject.SetActive(false);
    }
    else
      return;
  }
}
