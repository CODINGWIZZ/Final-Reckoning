using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{

    public float viewRadius;

    public LayerMask targetMask;
    public LayerMask obstecalMask;


    public Transform target;
    public Transform enemyTransform;

    [HideInInspector]
    public bool seeTarget;

    [HideInInspector]
    public Vector3 targetPos;
    [HideInInspector]
    public Vector3 viewArea;

    [HideInInspector]
    public List<Transform> visebelTarget = new List<Transform>();

    [HideInInspector]
    public RaycastHit hit;

    void Start()
    {
        //viewArea = new Vector3(viewRadius, viewRadius, viewRadius);
        StartCoroutine("FindTargetWhithDelay", .2);
    }

    IEnumerator FindTargetWhithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        visebelTarget.Clear();
        seeTarget = false;
        Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetInViewRadius.Length; i++)
        {
            Transform targert = targetInViewRadius[i].transform;
            Vector3 dirToTarget = (targert.position - enemyTransform.position).normalized;

            if (Vector3.Distance(enemyTransform.forward, dirToTarget) < viewRadius)
            {
                float dstToTarget = Vector3.Distance(enemyTransform.position, targert.position);

                Physics.Raycast(enemyTransform.position, dirToTarget, dstToTarget, obstecalMask);

                Debug.Log("in range");

                if (!Physics.Raycast(enemyTransform.position, dirToTarget, out hit, dstToTarget, obstecalMask))
                {
                    visebelTarget.Add(targert);
                    targetPos = new Vector3(target.position.x, target.position.y, target.position.z);
                    seeTarget = true;
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += enemyTransform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
