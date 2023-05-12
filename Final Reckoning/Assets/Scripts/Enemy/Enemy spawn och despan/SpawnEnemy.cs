using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float spawnDelayStart;
    public float spawnDelay;
    public ProgresBar progresBar;
    public GameObject enemy;
    public bool deth = false;
    public EnemyView enemyView;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (deth == true)
        {
            spawnDelay = progresBar.delay(spawnDelay);
            if(spawnDelay <= 0)
            {
                enemyView.enemyTransform = Instantiate(enemy, transform).transform;
                deth = false;
            }
        }
    }
}
