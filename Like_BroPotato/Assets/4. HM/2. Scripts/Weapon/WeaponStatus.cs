using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponStatus : MonoBehaviour
{
    protected float baseDistance; // 기본 사거리
    protected float baseDamage;    // 기본 데미지
    protected int baseCount; // 기본 관통
    protected float baseFireTime; // 기본 연사력
    protected float baseHitRate; // 기본 명중률
    protected float baseSpeed; // 기본 총알 속도
    
    protected PlayerMove player;
    protected PlayerScanner playerScanner;
    protected GameObject firePos;

    protected virtual void Start()
    {
        
    }
    protected virtual void Update()
    {
        
    }
    
    protected void Init(WeaponData data)
    {
        this.baseDistance = data.baseDistance;
        this.baseDamage = data.baseDamage;
        this.baseCount = data.baseCount;
        this.baseFireTime = data.baseFireTime;
        this.baseHitRate = data.baseHitRate;
        this.baseSpeed = data.baseSpeed;

        playerScanner.scanRange = baseDistance;
    }

    protected virtual void Fire()
    {
        if (!playerScanner.nearestTarget)
            return;

        // 플레이어와 가장 가까운 타겟의 거리와 방향을 구함
        Vector3 targetpos = player.scanner.nearestTarget.position;
        Vector3 dir = targetpos - transform.position;
        dir = dir.normalized;
        
        MakeBullet(dir);
    }
    
    protected void MakeBullet(Vector3 _dir)
    {
        var bullet = InGameManager.instance.objPool.Get(0).transform;
        
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, _dir); // 총알을 타겟 방향으로 z축 기준으로 회전

        bullet.GetComponent<Test_Bullet>()
            .Init(baseDamage, baseCount, baseSpeed, baseHitRate, _dir); // (Damgae,Per,방향) 데미지와 관통갯수,방향을 전달
    }
}
