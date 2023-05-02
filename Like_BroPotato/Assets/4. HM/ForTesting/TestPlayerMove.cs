using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMove : MonoBehaviour
{
  public Vector2 inputVec;

  public float speed;

  public Test_Scanner_Upgrade scanner;
  Rigidbody2D playerRigid;
  SpriteRenderer playerSpriteRender;
  Animator playerAnim;

  private void Awake()
  {
    scanner = this.GetComponent<Test_Scanner_Upgrade>();
    playerRigid = this.GetComponent<Rigidbody2D>();
    playerSpriteRender = this.GetComponent<SpriteRenderer>();
    playerAnim = this.GetComponent<Animator>();

  }

  private void FixedUpdate()
  {

    inputVec.x = Input.GetAxis("Horizontal");
    inputVec.y = Input.GetAxis("Vertical");

    Vector2 moveVec = inputVec.normalized * (speed * Time.fixedDeltaTime);
    playerRigid.MovePosition(playerRigid.position + moveVec);
  }

  private void LateUpdate()
  {
    if (inputVec.x != 0) // 플레이어가 움직일 때
    {
      playerSpriteRender.flipX = inputVec.x < 0; // 0보다 작을때 flipx = true
    }

    playerAnim.SetFloat("Speed", inputVec.magnitude);
    // magnitude => vector의 길이를 반환
  }
}
