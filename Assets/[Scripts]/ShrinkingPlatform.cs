//Wanhao Sun
//101277502
//ShrinkingPlatform.cs
//make the platform be able to shrink and recover, and play the sound effect while transforming

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatform : MonoBehaviour
{
    bool ifRocover;
    int soundFrequency;
    // Start is called before the first frame update
    void Start()
    {
        ifRocover = false;
        soundFrequency = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ifRocover)
        {
            Rocover();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        ifRocover = false;
        Shrink();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        ifRocover = true;
    }
    public void Shrink()
    {
        if(transform.localScale.x > 0)
        {
            if (soundFrequency <= 15)
            {
                if (soundFrequency == 0)
                {
                    SoundManager.PlaySound("shrinkSound");
                    soundFrequency++;
                }
                else
                {
                    soundFrequency++;
                }
            }
            else
            {
                soundFrequency = 0;
            }
            transform.localScale = new Vector3(transform.localScale.x - 0.5f * Time.deltaTime, transform.localScale.y - 0.5f * Time.deltaTime, transform.localScale.z);
            transform.localPosition = new Vector3(transform.localPosition.x + 0.75f * Time.deltaTime, transform.localPosition.y - 0.25f * Time.deltaTime, transform.localPosition.z);
        }
    }
    public void Rocover()
    {
        if(transform.localScale.x < 1)
        {
            if (soundFrequency <= 60)
            {
                if (soundFrequency == 0)
                {
                    SoundManager.PlaySound("recoverSound");
                    soundFrequency++;
                }
                else
                {
                    soundFrequency++;
                }
            }
            else
            {
                soundFrequency = 0;
            }

            transform.localScale = new Vector3(transform.localScale.x + 0.5f * Time.deltaTime, transform.localScale.y + 0.5f * Time.deltaTime, transform.localScale.z);
            transform.localPosition = new Vector3(transform.localPosition.x - 0.75f * Time.deltaTime, transform.localPosition.y + 0.25f * Time.deltaTime, transform.localPosition.z);
        }
    }
}
