using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class test : MonoBehaviour
{
    public Canvas canvas;

    public KeyCode openCloseInventory;

    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = !canvas.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(openCloseInventory))
        {
            canvas.enabled = canvas.enabled ? false : true;
        }
    }
}
