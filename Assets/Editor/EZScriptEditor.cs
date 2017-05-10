using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

[CustomEditor(typeof(EZScript))]
[CanEditMultipleObjects]
public class EZScriptEditor : Editor
{

    AnimBool showStartEvents = new AnimBool(true);
    private object startEvents;

    void OnEnable()
    {
        showStartEvents.valueChanged.AddListener(Repaint);
    }

    public override void OnInspectorGUI()
    {
        // TODO: Remove this.
        //DrawDefaultInspector();

        EZScript script = (EZScript)target;

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Start", EditorStyles.boldLabel);
        showStartEvents.target = EditorGUILayout.Foldout(showStartEvents.target, "Start Content");
        if (EditorGUILayout.BeginFadeGroup(showStartEvents.faded))
        {
            EZHelper.AddIndent();
            EZHelper.StartZone();

            if (script.StartPart == null)
            {
                // Dropdown to choose type
                script.StartPartEnum = EditorGUILayout.Popup("Type", script.StartPartEnum, Enum.GetNames(typeof(EZType)));
                EZType newPart = (EZType)script.StartPartEnum;
                if (newPart != EZType.None)
                {
                    System.Type type = EZHelper.GetType(newPart);
                    // Add part button
                    if (GUILayout.Button("Add part", GUILayout.Width(100)))
                    {
                        script.StartPart = script.gameObject.AddComponent(type) as EZPart;
                    }
                }
            }
            else
            {
                script.StartPart.EditorContent();
                // Remove part button
                if (GUILayout.Button("Remove part", GUILayout.Width(100)))
                {
                    // destroy start part safely
                    script.StartPart.DestroySelf();
                    script.StartPart = null;
                    // reset enum for start part
                    script.StartPartEnum = 0;
                    GUIUtility.ExitGUI();
                }
            }

            EZHelper.EndZone();
            EZHelper.RemoveIndent();
        }
        EditorGUILayout.EndFadeGroup();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Update", EditorStyles.boldLabel);
    }

    

}
