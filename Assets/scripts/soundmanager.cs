using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;

public class soundmanager : MonoBehaviour
{

    [SerializeField] public AudioSource parrySound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static soundmanager instance;
     void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }
    public void PlayParrySound(AudioClip audioclip,Transform spawntransform)
    {
        if (!parrySound.isPlaying)
        {
            // AudioSource.PlayClipAtPoint(PARRY, Camera.main.transform.position);
            AudioSource audiosource = Instantiate(parrySound, spawntransform.position, Quaternion.identity);
            audiosource.clip = audioclip;
            audiosource.Play();
            float cliplength = audioclip.length;
            Destroy(audiosource.gameObject, cliplength);
        }

    }
}
