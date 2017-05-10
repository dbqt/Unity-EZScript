using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class EZDebugLog : EZPart {
    public override EZType Type { get { return EZType.DebugLog; } }

    public string Message = "";

    public override void Execute()
    {
        Debug.Log(Message);
        base.Execute();
    }

    public override void EditorContent()
    {
        EditorGUILayout.LabelField(Type.ToString(), EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Message");
        Message = EditorGUILayout.TextArea(Message);
        EditorGUILayout.EndHorizontal();
        base.EditorContent();
    }
}
