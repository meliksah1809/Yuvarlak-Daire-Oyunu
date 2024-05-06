using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunDurdur : MonoBehaviour
{
    private bool oyundurumu = false;
    public void oyunDurdur() 
    { 
        if (oyundurumu == false)
        {
            Time.timeScale = 0f;
            oyundurumu = true;
        }
        else
        {
            Time.timeScale = 1f;
            oyundurumu = false;
        }

    }
}
