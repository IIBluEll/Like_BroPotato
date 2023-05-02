using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectGun_UI : MonoBehaviour
{
    [Header("## Weapon Status ##")]
    public WeaponData weaponData;
    [SerializeField] private Text txt_WeaponName;
    [SerializeField] private Text txt_WeaponDescription;
    [SerializeField] private Text txt_WeaponStat;

    [Space(10f), Header("## Weapon Icon ##"), SerializeField]
    private Image weaponIcon;

    private GameObject weaponPrefeb;

    [Space(5f), Header("## UI Object ##"), SerializeField]
    private GameObject selectGun_UI;
    public void ChangeData()
    {
        txt_WeaponName.text = weaponData.weaponName;
        txt_WeaponDescription.text = weaponData.weaponDescription;
        weaponIcon.sprite = weaponData.weaponIcon;
        txt_WeaponStat.text = $"데미지 : {weaponData.baseDamage}\n" +
                              $"사거리 : {weaponData.baseDistance}\n" +
                              $"명중률 : {weaponData.baseHitRate}";

        weaponPrefeb = weaponData.gunPrefebs;

    }

    public void OnClick()
    {
        GameObject gunPrefeb = Instantiate(weaponPrefeb);

        InGameManager.instance.TimeResume();
        selectGun_UI.SetActive(false);
    }
}
