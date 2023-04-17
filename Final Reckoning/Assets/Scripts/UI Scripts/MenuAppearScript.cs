using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAppearScript : MonoBehaviour
{
    public GameObject menu;
    public bool menuVisible;

    // Start is called before the first frame update
    void Start()
    {
        menuVisible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q")) {
            menuVisible = !menuVisible;
            menu.SetActive(menuVisible);
        }

        if(menu.activeSelf) {
            menuVisible = true;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        } else {
            menuVisible = false;
            
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
