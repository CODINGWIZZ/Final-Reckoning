using UnityEditor.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class enemyHP : MonoBehaviour
{
    public float maxHP;
    public float hp;
    public float hpRegenAmount;
    public float hpRegenCurrentDelay;
    public float hpRegenStartDelay;
    public SpawnEnemy delay;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
        delay = transform.parent.gameObject.GetComponent<SpawnEnemy>();
    }

    public float Wait(float wait)
    {
        if (wait > 0)
        {
            wait -= 1 * Time.deltaTime;
        }
        return wait;
    }
    public float regain(float regain, float regainAmount, float max)
    {
        if (regain <= max)
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

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            delay.deth = true;
            delay.spawnDelay = delay.spawnDelayStart;
            Destroy(this.gameObject);
        }
        else if (hp < maxHP)
        {
            hpRegenCurrentDelay = Wait(hpRegenCurrentDelay);
            if(hpRegenCurrentDelay <= 0)
            {
                hp = regain(hp, hpRegenAmount, maxHP);
            }
        }
    }
}
