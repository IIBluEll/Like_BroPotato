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
  public float _Speed; // 총알 속도 

  // 샷건 전용
  public int pelletCount = 5; 
  public float spreadAngle = 30f; 

  [SerializeField] float timer; // 원거리 전용 발사속도 타이머

  TestPlayerMove player;

  private void Awake()
  {
    player = Test_GameManager.instance.player;
  }

  private void Update()
  {
    timer += Time.deltaTime;

    if (timer > _FireTime)
    {
      timer = 0;
      Fire();
    }
  }
  public void Init(WeaponData data)
  {
    name = "Gun " + data.weaponID;
    transform.parent = player.transform;
    transform.localPosition = Vector3.zero;

    id = data.weaponID;
    _Distance = data.baseDistance;
    _Damage = data.baseDamage;
    _Count = data.baseCount;
    _FireTime = data.baseFireTime;
    _HitRate = data.baseHitRate;
    _Speed = data.baseSpeed;

    player.scanner.scanRange = this._Distance;

    for (int i = 0; i < Test_GameManager.instance.poolMgr.Prefebs.Length; i++)
    {
      if (data.projectile == Test_GameManager.instance.poolMgr.Prefebs[i])
      {
        prefabID = i;
        break;
      }
    }
  }

  //! 개선 필요! 메서드를 따로 빼서 압축 가능할듯
  public void Fire()
  {
    if (!player.scanner.nearestTarget)
      return;

    // 플레이어와 가장 가까운 타겟의 거리와 방향을 구함
    Vector3 targetpos = player.scanner.nearestTarget.position;
    Vector3 dir = targetpos - transform.position;
    dir = dir.normalized;

    switch (id)
    {
      case 1:
      case 3:

        Transform bullet;
        bullet = Test_GameManager.instance.poolMgr.Get(prefabID).transform;

        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir); // 총알을 타겟 방향으로 z축 기준으로 회전

        bullet.GetComponent<Test_Bullet>().Init(_Damage, _Count, _Speed,_HitRate, dir); // (Damgae,Per,방향) 데미지와 관통갯수,방향을 전달

        break;

      case 2:

        float angleStep = spreadAngle / (pelletCount - 1);

        for (int i = 0; i < pelletCount; i++)
        {
          float angle = -spreadAngle / 2 + angleStep * i;
          Quaternion spreadRotation = Quaternion.Euler(0, 0, angle);
          Vector3 spreadDir = spreadRotation * dir;

          Transform SG_bullet;
          SG_bullet = Test_GameManager.instance.poolMgr.Get(prefabID).transform;

          SG_bullet.position = transform.position;
          SG_bullet.rotation = Quaternion.FromToRotation(Vector3.up, spreadDir); // Rotate the bullet around the z-axis towards the target

          SG_bullet.GetComponent<Test_Bullet>().Init(_Damage, _Count, _Speed, _HitRate, spreadDir); // (Damage, Per, Direction) Delivers damage, number of penetrations, and direction
        }
        break;
    }
  }
}


