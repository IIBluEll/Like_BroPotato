using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_LookEnemy : MonoBehaviour
{
  Transform target;

  private SpriteRenderer spriteRenderer;
  Test_Scanner_Upgrade scanner;
  private void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    scanner = this.GetComponentInParent<Test_Scanner_Upgrade>();
  }

  private void Update()
  {
    if (scanner.nearestTarget != null)
    {
      target = scanner.nearestTarget;

       // 현재 오브젝트와 타겟 사이의 벡터 계산
        Vector3 direction = target.position - transform.position;
        // 벡터의 각도를 계산
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Z 축을 기준으로 회전하는 쿼터니언을 계산
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        // 현재 오브젝트의 회전을 타겟 회전으로 설정
        transform.rotation = targetRotation;

    }
  }
}
