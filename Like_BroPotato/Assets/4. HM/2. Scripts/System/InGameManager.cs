using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;

    public PlayerMove playerObj;
    public InGamePoolManager objPool;

    private void Awake()
    {
        instance = this;
    }
}
