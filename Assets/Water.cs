using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    Material mymat;
    public float offsetX, offsetY;
    // Start is called before the first frame update
    void Start()
    {
        mymat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = (mymat.mainTextureOffset.x + offsetX);
        float y = (mymat.mainTextureOffset.y + offsetY);
        x = x - Mathf.Floor(x);
        y = y - Mathf.Floor(y);
        mymat.mainTextureOffset = new Vector2(x, y);
    }
}
