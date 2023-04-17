using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MouseItemData))]
public class RaycastDropEditor : Editor
{
    private void OnSceneGUI()
    {
        MouseItemData mouse = new MouseItemData();

        Vector3 nol = new Vector3(0, 0, 0);

        Transform startPoint = mouse._playerTransform;
        Handles.color = Color.white;

        Handles.DrawLine(startPoint.position, nol, 20);
    }
}
