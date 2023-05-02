using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D playerRigid;
    private SpriteRenderer playerSpriteRender;
    private Animator playerAnim;

    public PlayerScanner scanner;
    
    private Vector2 inputVec;
    
    public float speed;
    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Awake()
    {
        scanner = this.GetComponent<PlayerScanner>();
        playerRigid = this.GetComponent<Rigidbody2D>();
        playerSpriteRender = this.GetComponent<SpriteRenderer>();
        playerAnim = this.GetComponent<Animator>();
    }
    
    private void FixedUpdate()
    {
        Vector2 moveVec = inputVec * (speed * Time.fixedDeltaTime);
        playerRigid.MovePosition(playerRigid.position + moveVec);
    }
    
    private void LateUpdate()
    {
        if(inputVec.x != 0)                         // inputVec.x 값이 0이 아닐 경우 ( 플레이어가 움직일 경우 )
        {
            playerSpriteRender.flipX = inputVec.x < 0;    // inputVec.x 값이 0보다 작을 경우 True => flipX = true
                                                          // inputVec.x 값이 0보다 클 경우 False  => flipx = false
        }
        playerAnim.SetFloat(Speed, inputVec.magnitude);   // magnitude -> vector의 길이를 반환
    }

    // InputSystem에서 호출할 함수
    public void OnMove(InputAction.CallbackContext context)
    {
        inputVec = context.ReadValue<Vector2>();
    }

}
