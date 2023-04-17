using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menu;

    public GameObject startGameButton;
    public GameObject exitGameButton;
    public GameObject showCreditsButton;
    public GameObject extendedCreditsButton;
    public GameObject closeButton;
    public GameObject inventoryCanvas;
    public GameObject minimapCanvas;

    private List<GameObject> buttonList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        buttonList.Add(startGameButton);
        buttonList.Add(exitGameButton);
        buttonList.Add(showCreditsButton);

        inventoryCanvas.SetActive(false);
        minimapCanvas.SetActive(false);

        extendedCreditsButton.SetActive(false);
        closeButton.SetActive(false);
    }

    void SetAllButtons(bool state) {
        for(int i = 0; i < buttonList.Count; i++) {
            buttonList[i].SetActive(state);
        }
    }

    void EnableButton(GameObject button) {
        button.SetActive(true);
    }

    void DisableButton(GameObject button) {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        menu.SetActive(false);
        inventoryCanvas.SetActive(true);
        minimapCanvas.SetActive(true);
    }

    public void ExitButton() {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void ShowExtendedCredits() {
        extendedCreditsButton.SetActive(true);
        closeButton.SetActive(true);
    }

    void HideExtendedCredits() {
        extendedCreditsButton.SetActive(false);
        closeButton.SetActive(false);
    }

    public void CreditsButton() {
        SetAllButtons(false);
        ShowExtendedCredits();
    }

    public void CloseCredits() {
        SetAllButtons(true);
        HideExtendedCredits();
    }
}
