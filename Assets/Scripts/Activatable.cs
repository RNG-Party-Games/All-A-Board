using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour
{
    public bool activated = false;
    public int loop;
    // Start is called before the first frame update
    protected void Start()
    {
        // reporting to loop manager
        LoopManager.instance.AddActive(this);
    }

    // Update is called once per frame
    protected void Update()
    {

    }

    public void Activate() {
        activated = true;
        LoopManager.instance.CheckActivations();
    }

    public virtual void CustomReset() {}

    public void Reset() {
        CustomReset();
        activated = false;
    }
}
