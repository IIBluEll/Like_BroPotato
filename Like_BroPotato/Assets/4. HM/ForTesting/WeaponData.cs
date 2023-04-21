using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon",menuName = "Scriptable Object/WeaponData")]
public class WeaponData : ScriptableObject
{
    public enum WeaponType {Assult, Shothun, DMR}

    [Header("## Main Info")]
    public WeaponType weaponType;
    public int weaponID;        // 무기 ID
    public string weaponName;       // 무기 이름 
    public string weaponDescription;    // 무기 설명
    public Sprite weaponIcon; // 무기 아이콘 스프라이트

    [Header("## Weapon Level Data")]

    public float baseDistance; // 기본 사거리
    public float baseDamage;    // 기본 데미지
    public int baseCount; // 기본 관통
    public float baseFireTime; // 기본 연사력
    public float baseHitRate; // 기본 명중률

    public float baseSpeed; // 기본 총알 속도

    [Header("## Gun")]
    public GameObject projectile; // 투사체 프리펩

    public Sprite gun_Sprite; // 총 스프라이트
}
