using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTest : MonoBehaviour
{
   // public GameObject target;
   // public GameObject bullet;
   public Text damageTxt;

   private void Start()
   {
      damageTxt.text = "";
   }

   public void UpdateText(float damage)
   {
      StartCoroutine(DamageTxt(damage));
   }

   IEnumerator DamageTxt(float damage)
   {
      damageTxt.text = "피해량 : " + damage;

      yield return new WaitForSeconds(.5f);
      
      damageTxt.text = "";

   }
}
