using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBG : MonoBehaviour
{
    void Awake()
    {
        int musicPlayingLenght = FindObjectsOfType<MusicBG>().Length;

        if (musicPlayingLenght > 1)
            Destroy(this.gameObject);
        else
            DontDestroyOnLoad(this.gameObject);
    }
}
