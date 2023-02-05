using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSimpleton : MonoBehaviour
{
    
    void Start()
    {
        transform.GetComponent<AudioSource>().volume = (float)PlayerPrefs.GetInt("Volume");
    }

    
    
}
