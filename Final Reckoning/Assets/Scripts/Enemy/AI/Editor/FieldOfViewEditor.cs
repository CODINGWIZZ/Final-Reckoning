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
        Handles.RadiusHandle(Quaternion.identity, fov.enemyTransform.parent.position, fov.viewRadius, false);

        Handles.color = Color.red;
        foreach (Transform visebelTarget in fov.visebelTarget)
        {
            Handles.DrawLine(fov.enemyTransform.position, visebelTarget.position);
        }
    }
}
