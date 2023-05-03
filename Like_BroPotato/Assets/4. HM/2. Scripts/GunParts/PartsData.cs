using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PartsData",menuName = "Scriptable Object/PartsData")]
public class PartsData : ScriptableObject
{
    public enum GunType {Assult, Shothun, DMR}
    
    [Header("## Parts Stauts Data")]
    public string partsName;            // 파츠 이름
    public string weaponDescription;    // 파츠 설명

    [Header("## Parts Stauts Data")]
    public float changeDistance; // 사거리 변경
    public float changeDamage;   // 데미지 변경
    public int changeCount;    // 관통력 변경
    public float changeFireTime; // 연사력 변경
    public float changeHitRate;  // 명중률 변경
    public float changeSpeed;  // 총알속도 변경
}
