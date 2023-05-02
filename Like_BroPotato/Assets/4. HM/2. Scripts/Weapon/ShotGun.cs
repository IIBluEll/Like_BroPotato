using UnityEngine;

public class ShotGun : WeaponStatus
{
    [SerializeField] protected float timer;
    
    public WeaponData assult_Data;
    
    // 샷건 전용
    [SerializeField] private int pelletCount = 5;
    [SerializeField] private float spreadAngle = 30f;
    
    protected override void Start()
    {
        base.Start();
        
        player = InGameManager.instance.playerObj;
        playerScanner = player.scanner;
        firePos = player.transform.GetChild(0).gameObject;
        Init(assult_Data);
    }

    protected override void Update()
    {
        base.Update();
        
        timer += Time.deltaTime;

        if (timer > baseFireTime)
        {
            timer = 0;
            Fire();
        }
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