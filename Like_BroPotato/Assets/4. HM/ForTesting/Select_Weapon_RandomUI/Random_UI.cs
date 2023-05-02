using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UI에 랜덤한 스크립터블 오브젝트를 넣기 위한 스크립트
// 리스트 안의 아이템들을 Shuffle 하고 순서대로 출력 

public class Random_UI : MonoBehaviour
{
    public List<Test_Weapon_Data> weaponDatas;
    public List<UI_ReadingData> ui_WeaponsIcon;

    private void OnEnable()
    {
        Test_GameManager.instance.TimeStop();
        List<Test_Weapon_Data> shuffledData = Shuffle(weaponDatas);

        for(int i = 0; i < shuffledData.Count; i++)
        {
            ui_WeaponsIcon[i].weaponData = shuffledData[i];
            ui_WeaponsIcon[i].ChangeInfo();
        }
    }

    // 리스트 내 데이터들을 Shuffle 함
    List<Test_Weapon_Data> Shuffle(List<Test_Weapon_Data> datas)
    {
        // 원래 리스트 복사해옴
        List<Test_Weapon_Data> shuffledDatas = new List<Test_Weapon_Data>(weaponDatas);

        int dataCount = shuffledDatas.Count;

        System.Random random = new System.Random();

        for(int i = dataCount - 1; i > 0; i--)
        {
            // 남은 범위 내에서 무작위 인덱스 생성 
            int ranIndex = random.Next(0, i + 1);

            // 현재 i 항목을 무작위 인덱스 항목과 교환
            (shuffledDatas[i], shuffledDatas[ranIndex]) = (shuffledDatas[ranIndex], shuffledDatas[i]);
        }

        return shuffledDatas;
    }
}
