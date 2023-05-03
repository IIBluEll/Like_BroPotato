using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsStatus : MonoBehaviour
{
    public PartsData partsData;

    private WeaponStatus weaponStatus;
    
    protected void OnEnable()
    {
        weaponStatus = this.transform.GetComponentInParent<WeaponStatus>();
        
        weaponStatus.BaseDistance += partsData.changeDistance;
        weaponStatus.BaseDamage += partsData.changeDamage;
        weaponStatus.BaseCount += partsData.changeCount;
        weaponStatus.BaseFireTime += partsData.changeFireTime;
        weaponStatus.BaseHitRate += partsData.changeHitRate;
        weaponStatus.BaseSpeed += partsData.changeSpeed;
    }

    protected void OnDisable()
    {
        weaponStatus.BaseDistance -= partsData.changeDistance;
        weaponStatus.BaseDamage -= partsData.changeDamage;
        weaponStatus.BaseCount -= partsData.changeCount;
        weaponStatus.BaseFireTime -= partsData.changeFireTime;
        weaponStatus.BaseHitRate -= partsData.changeHitRate;
        weaponStatus.BaseSpeed -= partsData.changeSpeed;
    }
}
