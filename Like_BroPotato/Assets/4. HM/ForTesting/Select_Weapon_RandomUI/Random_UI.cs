using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UI에 랜덤한 스크립터블 오브젝트를 넣기 위한 스크립트
// 리스트 안의 아이템들을 Shuffle 하고 순서대로 출력 

public class Random_UI : MonoBehaviour
{
    public List<WeaponData> weaponDatas;
    public List<UI_ReadingData> ui_WeaponsIcon;

    private void OnEnable()
    {
        Test_GameManager.instance.gameObject.SendMessage("TimeStop",SendMessageOptions.DontRequireReceiver);

        // 리스트 내 데이터들을 Shuffle 함
        List<WeaponData> shuffledData = Shuffle(weaponDatas);

        for(int i = 0; i < shuffledData.Count; i++)
        {
            ui_WeaponsIcon[i].weaponData = shuffledData[i];
            ui_WeaponsIcon[i].ChangeInfo();
        }
    }

    // 리스트 내 데이터들을 Shuffle 함
    List<WeaponData> Shuffle(List<WeaponData> datas)
    {
        // 원래 리스트 복사해옴
        List<WeaponData> shuffledDatas = new List<WeaponData>(weaponDatas);

        int dataCount = shuffledDatas.Count;

        System.Random random = new System.Random();

        for(int i = dataCount - 1; i > 0; i--)
        {
            // 남은 범위 내에서 무작위 인덱스 생성 
            int ranIndex = random.Next(0, i + 1);

            // 현재 i 항목을 무작위 인덱스 항목과 교환
            WeaponData temp = shuffledDatas[i];
            shuffledDatas[i] = shuffledDatas[ranIndex];

            shuffledDatas[ranIndex] = temp;
        }

        return shuffledDatas;
    }

    public void OnClick()
    {
         Test_GameManager.instance.gameObject.SendMessage("TimeResume",SendMessageOptions.DontRequireReceiver);

         this.gameObject.SetActive(false);
    }
}
