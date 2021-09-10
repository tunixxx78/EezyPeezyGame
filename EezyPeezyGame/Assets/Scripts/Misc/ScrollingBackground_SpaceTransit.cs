using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground_SpaceTransit : MonoBehaviour
{

    //this script is attached to the background quad object in Space transit. It controls the rendered and loops the repeating texture material.
    public float bgSpeed;
    public Renderer bgRend;

    // Update is called once per frame
    void Update()
    {
        // you can set the background moving speed in the inspector 
        bgRend.material.mainTextureOffset += new Vector2(0f, bgSpeed * Time.deltaTime);

    }
}
