using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovment : MonoBehaviour
{
    public Transform transformSpawn;

    public string enemyParent;

    private Vector3 targetPos;

    private NavMeshAgent navMesh;

    private void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        transformSpawn = transform.parent;
    }

    public void Update()
    {
        GameObject enemy0 = GameObject.Find(enemyParent);
        EnemyView enemyView1 = enemy0.GetComponent<EnemyView>();

        if (enemyView1.seeTarget == true)
        {
            targetPos = enemyView1.targetPos;
            navMesh.destination = targetPos;
        }
        if (enemyView1.seeTarget == false)
        {
            targetPos = transformSpawn.position;
            navMesh.destination = targetPos;
            navMesh.Move(new Vector3(0, 0, 0).normalized);
        }
    }
}
