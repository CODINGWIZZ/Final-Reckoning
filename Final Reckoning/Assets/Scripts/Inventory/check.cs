using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{
    public bool backpack;
    public bool chest;
    // Start is called before the first frame update
    void Start()
    {
        backpack = false;
        chest = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (backpack == false)
            {
                backpack = true;
            }
            else
            {
                backpack = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (chest == false)
            {
                chest = true;
            }
            else
            {
                chest = false;
            }
        }
    }
}
