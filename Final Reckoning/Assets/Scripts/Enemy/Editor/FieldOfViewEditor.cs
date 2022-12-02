using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        EnemyView fov = (EnemyView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius);

        Handles.color = Color.red;
        foreach (Transform visebelTarget in fov.visebelTarget)
        {
            Handles.DrawLine(fov.enemyTransform.position, visebelTarget.position);
        }
    }
}
