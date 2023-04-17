using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Weapon : MonoBehaviour
{
  public int id;
  public int prefabID;
  public float _Distance;  // 사거리
  public float _Damage;    // 데미지
  public int _Count;       // 관통
  public float _FireTime;  // 연사력
  public float _HitRate;   // 명중률

  float timer; // 원거리 전용 발사속도 타이머

  TestPlayerMove player;

  private void Awake()
  {
    player = Test_GameManager.instance.player;
  }

  public void Init(WeaponData data)
  {
    name = "Weapon " + data.weaponID;
    transform.parent = player.transform;
    transform.localPosition = Vector3.zero;

    id = data.weaponID;
    _Distance = data.baseDistance;
    _Damage = data.baseDamage;
    _Count = data.baseCount;
    _FireTime = data.baseFireTime;
    _HitRate = data.baseHitRate;

    for (int i = 0; i < Test_GameManager.instance.poolMgr.Prefebs.Length; i++)
    {
      if (data.projectile == Test_GameManager.instance.poolMgr.Prefebs[i])
      {
        prefabID = i;
        break;
      }
    }
  }

  public void Fire()
  {
    if (!player.scanner.nearestTarget)  
            return;

        // 플레이어와 가장 가까운 타겟의 거리와 방향을 구함
        Vector3 targetpos = player.scanner.nearestTarget.position;
        Vector3 dir = targetpos - transform.position;
        dir = dir.normalized;

        Transform bullet;
        bullet = Test_GameManager.instance.poolMgr.Get(prefabID).transform;

        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up,dir); // 총알을 타겟 방향으로 z축 기준으로 회전

        bullet.GetComponent<Test_Bullet>().Init(_Damage, _Count, dir); // (Damgae,Per,방향) 데미지와 관통갯수,방향을 전달
    }
}


