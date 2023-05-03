using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;

    public PlayerMove playerObj;
    public InGamePoolManager objPool;
    
    public List<GameObject> playerGunParts;
    public List<GameObject> assultGunParts;
    public List<GameObject> dmrParts;
    public List<GameObject> shotGunParts;

    private void Awake()
    {
        instance = this;
    }

    public void ChoicePlayerGun(int gunId)
    {
        switch (gunId)
        {
            case 0 : 
                playerGunParts = assultGunParts;
                break;
            
            case 1 : 
                playerGunParts = dmrParts;
                break;
            
            case 2 : 
                playerGunParts = shotGunParts;
                break;
        }
    }

    public void TimeStop()
    {
        Time.timeScale  = 0;
    }
    
    public void TimeResume()
    {
        Time.timeScale  = 1;
    }
}
