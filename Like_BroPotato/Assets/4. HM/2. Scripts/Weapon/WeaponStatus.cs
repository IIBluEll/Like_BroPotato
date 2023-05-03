using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class WeaponStatus : MonoBehaviour
{
    public float BaseDistance { get; set; }
    public float BaseDamage { get; set; }
    public int BaseCount { get; set; }
    public float BaseFireTime { get; set; }
    public float BaseHitRate { get; set; }
    public float BaseSpeed { get; set; }

    protected PlayerMove player;
    protected PlayerScanner playerScanner;
    protected GameObject firePos;

    [SerializeField] protected float timer;

    protected virtual void Start()
    {
        player = InGameManager.instance.playerObj;
        playerScanner = player.scanner;
        firePos = player.transform.GetChild(0).gameObject;

        var transform1 = transform;
        transform1.parent = firePos.transform;
        transform1.localPosition = Vector3.zero;
    }

    protected virtual void Update()
    {
        timer += Time.deltaTime;

        if (timer > BaseFireTime)
        {
            timer = 0;
            Fire();
        }

        // 총구가 적을 계속 볼 수 있도록 회전
        if (playerScanner.nearestTarget)
            LookAtEnemy(playerScanner.nearestTarget);

        playerScanner.scanRange = BaseDistance;
    }

    protected void Init(WeaponData data)
    {
        InGameManager.instance.ChoicePlayerGun(data.weaponID);

        this.BaseDistance = data.baseDistance;
        this.BaseDamage = data.baseDamage;
        this.BaseCount = data.baseCount;
        this.BaseFireTime = data.baseFireTime;
        this.BaseHitRate = data.baseHitRate;
        this.BaseSpeed = data.baseSpeed;

        var transform1 = transform;
        transform1.parent = firePos.transform;
        transform1.localPosition = Vector3.zero;
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
            .Init(BaseDamage, BaseCount, BaseSpeed, BaseHitRate, _dir); // (Damgae,Per,방향) 데미지와 관통갯수,방향을 전달
    }

    // 총구가 적을 계속 볼 수 있도록 회전
    protected void LookAtEnemy(Transform target)
    {
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