using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPScreen : MonoBehaviour
{
    [Header("Health UI")]
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        // PlayerMovement.OnHealthChanged += UpdateHealthText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateHealthText(int currentHealth) {
        if(healthText != null) {
            healthText.text = "HP: " + currentHealth.ToString();
        }
    }

    private void OnDestroy() {
        // PlayerMovement.OnHealthChanged -= UpdateHealthText;
    }
}
