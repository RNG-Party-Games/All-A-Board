using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Activatable
{
    public Animator anim;
    public string activationAnim, triggerAnim;
    public bool noTrigger;
    public AudioClip deathSFX;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit() {
        if (!activated) {
            anim.Play(activationAnim);
            Activate();
            SFXController.instance.PlaySFX(deathSFX, 1, false);
        }
    }

    public override void CustomReset() {
        if(activated && noTrigger) {
            anim.Play(triggerAnim);
        }
    }

}
