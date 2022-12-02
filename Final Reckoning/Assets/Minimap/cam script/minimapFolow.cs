using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapFolow : MonoBehaviour
{
    public Transform transformCam;
    public Transform transformPlayser;
    public Transform transformMap;
    public Transform transformPlayer;

    public GameObject HeadPosition;

    public bool lowerCamera;

    [HideInInspector]
    public RaycastHit hit;

    private void Start()
    {
        HeadPosition = GameObject.Find("HeadPosition");
        lowerCamera = false;
    }

    public float offset;

    private void LateUpdate()
    {
        if(Physics.Raycast(HeadPosition.transform.position, Vector3.up, out hit)) 
        {
            offset = hit.point.y - 0.5f;
        }
        else
        {
            offset = transformPlayer.position.y + 6;
        }

        transformMap.position = new Vector3(transformPlayser.position.x, offset, transformPlayser.position.z);

        transformMap.rotation = Quaternion.Euler(transformMap.eulerAngles.x, transformCam.eulerAngles.y, 0f);
    }
}
