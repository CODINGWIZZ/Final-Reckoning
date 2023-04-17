using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class ProgresBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Stats stats;

    public Image mask;

    public string typ;

    public Canvas canvas;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill(typ);
        Refill(typ);
    }

    void GetCurrentFill(string typ)
    {
        if (typ.ToLower() == "xp")
        {
            float fillAmount = stats.xp / stats.nextlevel;
            mask.fillAmount = fillAmount;
        }
        if (typ.ToLower() == "hp")
        {
            float fillAmount = stats.hp / stats.maxHp;
            mask.fillAmount = fillAmount;
        }
        if (typ.ToLower() == "mp") 
        {
            float fillAmount = stats.mana / stats.maxMana;
            mask.fillAmount = fillAmount;
        }
        if (typ.ToLower() == "stamina")
        {
            float fillAmount = stats.stamina / stats.maxStamina;
            mask.fillAmount = fillAmount;
        }
    }

    void Refill(string typ)
    {
        if (typ.ToLower() == "hp")
        {
            if (stats.hp < stats.maxHp)
            {
                /*if( stats.reganHpColdown > 0)
                {
                    stats.reganHpColdown -= 1 * Time.deltaTime;
                }
                if (stats.reganHpColdown <= 0 && stats.hp != stats.maxHp)
                {
                    if (stats.hp + stats.reganHpAmaunt > stats.maxHp)
                    {
                        stats.hp = stats.maxHp;
                    }
                    else
                    {
                        stats.hp += stats.reganHpAmaunt;
                    }
                }*/
                stats.reganHpColdown = delay(stats.reganHpColdown);
                if (stats.reganHpColdown <= 0)
                {
                    stats.hp = heal(stats.hp, stats.reganHpAmaunt, stats.maxHp);
                }
            }
        }
        if (typ.ToLower() == "mp")
        {
            if ( stats.mana < stats.maxMana)
            {
               
                stats.mana += stats.reganMpDelay;
            }
        }
        if (typ.ToLower() == "stamina")
        {
            if (stats.stamina < stats.maxStamina)
            {
                
                stats.stamina += stats.regenStaminaAmount;
            }
            if (stats.stamina == stats.maxStamina)
            {
                canvas.enabled = false;
            }
            else
            {
                canvas.enabled = true;
            }
        }
    }

    float delay (float wait)
    {
        if (wait > 0)
        {
            wait -= 1 * Time.deltaTime;
        }
        return wait;
    }

    float heal(float regain, float regainAmount, float max)
    {
        if(regain <= max)
        {
            if (regain + regainAmount <= max)
            {
                regain += regainAmount * Time.deltaTime;
            }
            else if (regain + regainAmount > max)
            {
                regain = max;
            }
        }
        return regain;
    }
}
