using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantLoop : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) {
        if (other.tag == "MainCamera") {
            if(PathManager.instance.state == PathManager.CartState.Unlinked) {
                SFXController.instance.CantLoop();
            }
        }
    }
}
