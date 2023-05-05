using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarPos : MonoBehaviour
{
    public Transform enemy;
    public Transform barTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barTransform.position = enemy.position;
    }
}
