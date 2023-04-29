using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_UI_Item : MonoBehaviour
{
    public WeaponData data;     // 무기 데이터 
    public Test_Weapon weapon; // 무기 정보

    public GameObject select_First_Weapon;
    Image icon;

    private void Awake()
    {
         // 아이콘 이미지 설정
        icon = GetComponentsInChildren<Image>()[1];
        icon.sprite = data.weaponIcon;
    }

    public void OnClik()
    {
        GameObject newWeapon = new GameObject();
        weapon = newWeapon.AddComponent<Test_Weapon>();
        weapon.Init(data);
        select_First_Weapon.SetActive(false);
    }
}
