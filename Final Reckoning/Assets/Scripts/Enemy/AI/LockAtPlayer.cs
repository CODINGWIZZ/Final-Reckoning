using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAtPlayer : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerArmature").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
