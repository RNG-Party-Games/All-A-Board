using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour
{
    public bool activated = false;
    public int loop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate() {
        activated = true;
        LoopManager.instance.CheckActivations();
    }

    public void Reset() {
        activated = false;
    }
}
