using System.Collections.Generic;
using UnityEngine;

public class Shuffle_gunUI : MonoBehaviour
{
    public List<WeaponData> weaponDatas;
    public List<SelectGun_UI> ui_guns;
   
    
    private void OnEnable()
    {
        InGameManager.instance.TimeStop();
        List<WeaponData> shuffledData = Shuffle(weaponDatas);

        for(int i = 0; i < shuffledData.Count; i++)
        {
            ui_guns[i].weaponData = shuffledData[i];
            
            ui_guns[i].ChangeData();
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
            (shuffledDatas[i], shuffledDatas[ranIndex]) = (shuffledDatas[ranIndex], shuffledDatas[i]);
        }

        return shuffledDatas;
    }
}