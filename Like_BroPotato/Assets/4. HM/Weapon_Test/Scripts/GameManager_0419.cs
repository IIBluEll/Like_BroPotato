using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_0419 : MonoBehaviour
{
   public static GameManager_0419 instance;

    public WeaponData getweaponData = null;

   private void Awake()
   {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
   }
}
