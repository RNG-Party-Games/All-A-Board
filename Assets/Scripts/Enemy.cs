using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Activatable
{
    public Animator anim;
    public string activationAnim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit() {
        if (!activated) {
            anim.Play(activationAnim);
            Activate();
        }
    }
}
