using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Debug_Restart : MonoBehaviour
{
    public void Onclick()
    {
        SceneManager.LoadScene(0);
    }
}
