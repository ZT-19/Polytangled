using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColor : MonoBehaviour
{
    private Color32 backgroundColor1 = ColorThemes.backgroundColor;
    Camera currentInstance;
    // Start is called before the first frame update
    void Start()
    {
        currentInstance = GetComponent<Camera>();
        currentInstance.backgroundColor = backgroundColor1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
