using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_GameManager : MonoBehaviour
{
    public static Test_GameManager instance;

    public TestPlayerMove player;
    public Test_PoolMgr poolMgr;

    private void Awake()
    {
        instance = this;
    }
}
