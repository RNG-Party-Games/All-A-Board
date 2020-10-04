using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletMeter : MonoBehaviour
{
    public TextMeshProUGUI number;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTime(float sec) {
        number.text = sec.ToString("F1");
    }
}
