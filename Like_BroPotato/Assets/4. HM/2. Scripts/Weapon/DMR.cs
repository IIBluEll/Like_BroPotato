using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMR : WeaponStatus
{
    public WeaponData dmr_Data;
    
    protected override void Start()
    {
        base.Start();
        Init(dmr_Data);
    }
}
