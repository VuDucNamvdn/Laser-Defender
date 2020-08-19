using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    Player pawn;
    TextMeshProUGUI healthText;
    int maxHealth = 0;
    // Start is called before the first frame update
    void Start()
    {
        pawn = FindObjectOfType<Player>();
        maxHealth = pawn.getHealth();
        healthText = FindObjectOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pawn)
        {
            healthText.text = pawn.getHealth().ToString();
            healthText.color = Color.Lerp(Color.red, Color.green, pawn.getHealth() / (float)maxHealth);
        }
    }
}
