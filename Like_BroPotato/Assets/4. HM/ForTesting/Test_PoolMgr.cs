using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_PoolMgr : MonoBehaviour
{
    public GameObject[] Prefebs;
    List<GameObject>[] Pool;

    private void Awake()
    {
        Pool = new List<GameObject>[Prefebs.Length];

        for(int i = 0; i < Prefebs.Length; i++)
            Pool[i] = new List<GameObject>(); // pool List 초기화
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach(GameObject item in Pool[index])
        {
            if(!item.activeSelf) // 비활성화되어 있는 오브젝트가 있을경우 select에 할당
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if(!select) // 모든 오브젝트가 활성화되어 있을 경우 새로 생성해서 select에 할당
        {
            select = Instantiate(Prefebs[index], transform);
            Pool[index].Add(select);
        }

        return select;
    }
}
