using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOpen : MonoBehaviour
{
  public GameObject selectWeapon_UI;

  private void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log($"Trigger : {other.tag}");

    if(other.tag == "Player")
        StartCoroutine("PopUp_UI");
  }

  IEnumerator PopUp_UI()
  {
    selectWeapon_UI.SetActive(true);
    yield return new WaitForEndOfFrame();
    this.gameObject.SetActive(false);
  }
}
