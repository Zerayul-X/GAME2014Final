//Wanhao Sun
//101277502
//SoundManager.cs
//initialize the sounds effects and that can be used for other scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip shrinkSound, recoverSound;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        shrinkSound = Resources.Load<AudioClip>("shrink"); 
        recoverSound = Resources.Load<AudioClip>("recover");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string sound)
    {
        switch (sound)
        {
            case "shrinkSound":
                audioSource.PlayOneShot(shrinkSound);
                break;
            case "recoverSound":
                audioSource.PlayOneShot(recoverSound);
                break;

            default:
                break;
        }
    }
}
