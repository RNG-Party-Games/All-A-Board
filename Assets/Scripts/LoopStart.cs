using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopStart : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) {
        if (other.tag == "MainCamera") {
            LoopManager.instance.RestartLoop();
        }
    }
}
