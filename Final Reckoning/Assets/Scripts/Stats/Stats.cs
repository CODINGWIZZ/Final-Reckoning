using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public float reganHpDelay;
    public float reganHpAmaunt;
    public float reganHpColdown;
    public bool regenHp;

    public float mana;
    public float maxMana;
    public float reganManaDelay;
    public float regenManaAmaundt;
    public float regenManaColdown;
    public bool regenMana;

    public float stamina;
    public float maxStamina;
    public float reganStaminaDelay;
    public float regenStaminaAmount;
    public float regenStaminaColdown;
    public bool regenStamina;
    public float staminaDrain;

    public float xp;
    public float nextlevel;
    public int level;
    public float giveXp;

    public float attackDamage;
    public float magickDamage;
    public float movmentspeed;

    public float damageMultiplier;

    public float hunger;
    public float thersd;
    public float bodelyFunktion;

    public float levellMultiplier;
    public void Update()
    {
        if (xp >= nextlevel)
        {

            xp = xp - nextlevel;
            nextlevel = nextlevel * levellMultiplier;
            level++;
        }
    }
}
