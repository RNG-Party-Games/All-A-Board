using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public static SFXController instance;
    public AudioSource sfx;
    public AudioClip cantloop, refreshSFX, onigiriSFX;

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    public void PlaySFX(AudioClip clip, float volume, bool shouldPitch) {
        AudioSource newSFX = Instantiate(sfx);
        newSFX.clip = clip;
        newSFX.volume = volume;
        if(shouldPitch && FPSController.instance.bullet_time) {
            newSFX.pitch = 0.5f;
        }
        newSFX.Play();
        newSFX.GetComponent<SFX>().SetInvoke("Kill", clip.length);
    }

    public void CantLoop() {
        PlaySFX(cantloop, 1, false);
    }

    public void Refresh() {
        PlaySFX(refreshSFX, 1, false);
    }

    public void Onigiri() {
        PlaySFX(onigiriSFX, 1, false);
    }
}
