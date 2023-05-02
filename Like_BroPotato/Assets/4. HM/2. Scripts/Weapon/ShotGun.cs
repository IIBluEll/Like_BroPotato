using UnityEngine;
using UnityEngine.Serialization;

public class ShotGun : WeaponStatus
{
    public WeaponData shotGun_Data;
    // 샷건 전용
    [SerializeField] private int pelletCount = 5;
    [SerializeField] private float spreadAngle = 30f;
    
    protected override void Start()
    {
        base.Start();
        Init(shotGun_Data);
    }

    protected override void Fire()
    {
        if (!player.scanner.nearestTarget)
            return;

        // 플레이어와 가장 가까운 타겟의 거리와 방향을 구함
        Vector3 targetpos = player.scanner.nearestTarget.position;
        Vector3 dir = targetpos - transform.position;
        dir = dir.normalized;
        
        float angleStep = spreadAngle / (pelletCount - 1);

        for (int i = 0; i < pelletCount; i++)
        {
            float angle = -spreadAngle / 2 + angleStep * i;
            Quaternion spreadRotation = Quaternion.Euler(0, 0, angle);
            Vector3 spreadDir = spreadRotation * dir;

            MakeBullet(spreadDir);
        }
        
    }
}