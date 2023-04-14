using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon",menuName = "Scriptable Object/WeaponData")]
public class WeaponData : ScriptableObject
{
    public enum WeaponType {Gun, Meel}

    [Header("## Main Info")]
    public WeaponType weaponType;
    public int weaponID;        // 무기 ID
    public string weaponName;       // 무기 이름 
    public string weaponDescription;    // 무기 설명
    public Sprite weaponIcon; // 무기 아이콘 스프라이트

    [Header("## Weapon Level Data")]
    public float baseDamage;    // 기본 데미지
    public int baseCount; // 기본 관통

    public float[] damages;
    public int[] counts;

    [Header("## Gun")]
    public GameObject projectile; // 투사체 프리펩
}
