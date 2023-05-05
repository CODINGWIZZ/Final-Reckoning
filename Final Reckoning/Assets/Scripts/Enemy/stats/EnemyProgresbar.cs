using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class EnemyProgresbar : MonoBehaviour
{
    public Image mask;
    public enemyHP hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float fillAmount = hp.hp / hp.maxHP;
        mask.fillAmount = fillAmount;
    }
}
