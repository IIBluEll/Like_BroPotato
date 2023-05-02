using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssultGun : WeaponStatus
{
    [SerializeField] protected float timer;
    
    public WeaponData assult_Data;
    
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
}
