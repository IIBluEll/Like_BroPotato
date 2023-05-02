using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ReadingData : MonoBehaviour
{
    public Test_Weapon_Data weaponData;
    public Text txt_WeaponName;
    public Text txt_WeaponDescription;
    public Text txt_WeaponStat;

    public Image img_WeaponIcon;

    public GameObject select_Weapon_UI;
    public Test_Weapon weapon;

    public void ChangeInfo()
    {
        txt_WeaponName.text = weaponData.weaponName;
        txt_WeaponDescription.text = weaponData.weaponDescription;
        img_WeaponIcon.sprite = weaponData.weaponIcon;

        txt_WeaponStat.text = $"데미지 : {weaponData.baseDamage}\n사거리 : {weaponData.baseDistance}\n명중률 : {weaponData.baseHitRate}";
    }

    public void onClick()
    {
        GameObject newWeapon = new GameObject();
        weapon = newWeapon.AddComponent<Test_Weapon>();

        weapon.Init(weaponData);
        Test_GameManager.instance.TimeResume();
        select_Weapon_UI.SetActive(false);
    }
}
