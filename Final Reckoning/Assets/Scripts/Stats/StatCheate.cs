using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatCheate : MonoBehaviour
{
    public Stats stats;

    public string type;

    public TextMeshProUGUI text;    

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (type.ToLower() == "hp")
        {
            text.text = Mathf.Round(stats.hp) + "/" + stats.maxHp;
            text.textStyle = TMP_Style.NormalStyle;
            text.fontStyle = FontStyles.Normal;
            text.color = Color.black;
        }
        else if (type.ToLower() == "mp")
        {
            text.text = Mathf.Round(stats.mana) + "/" + stats.maxMana;
            text.textStyle = TMP_Style.NormalStyle;
            text.fontStyle = FontStyles.Normal;
            text.color = Color.black;
        }
        else if (type.ToLower() == "xp")
        {
            text.text = stats.xp + "/" + stats.nextlevel;
            text.textStyle = TMP_Style.NormalStyle;
            text.fontStyle = FontStyles.Normal;
            text.color = Color.black;
        }
        else if (type.ToLower() == "lv")
        {
            text.text = "LVL: " + stats.level.ToString();
            text.textStyle = TMP_Style.NormalStyle;
            text.fontStyle = FontStyles.Normal;
            text.color = Color.black;
        }
        else if (type.ToLower() == "stamina")
        {
            text.text = Mathf.Round(stats.stamina) + "/" + stats.maxStamina;
            text.textStyle = TMP_Style.NormalStyle;
            text.fontStyle = FontStyles.Normal;
            text.color = Color.black;
        }
        else if (type.ToLower() == "ad")
        {
            text.text = stats.attackDamage + "%";
            text.textStyle = TMP_Style.NormalStyle;
            text.fontStyle = FontStyles.Normal;
            text.color = Color.black;
        }
        else if (type.ToLower() == "md")
        {
            text.text = stats.magickDamage + "%";
            text.textStyle = TMP_Style.NormalStyle;
            text.fontStyle = FontStyles.Normal;
            text.color = Color.black;
        }
        else if (type.ToLower() == "movmentspeed")
        {
            text.text = stats.movmentspeed + "%";
            text.textStyle = TMP_Style.NormalStyle;
            text.fontStyle = FontStyles.Normal;
            text.color = Color.black;
        }
    }
}
