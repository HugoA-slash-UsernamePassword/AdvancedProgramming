using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMaterial : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Material mat = GetComponent<Renderer>().material;
        mat.mainTextureOffset = mat.mainTextureOffset + new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * 0.01f;
    }
}
