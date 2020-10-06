using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > 5) {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other) {
        if(other.tag == "Shootable") {
            other.GetComponent<Shootable>().Hit();
            Destroy(gameObject);
        }
    }
}
