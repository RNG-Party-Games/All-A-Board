using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other) {
        if (other.tag == "MainCamera") {
            other.GetComponent<Animator>().Play("MusicTransition");
        }
    }
}
