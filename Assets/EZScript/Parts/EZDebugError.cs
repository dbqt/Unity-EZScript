using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class EZDebugError : EZPart {
    public override EZType Type { get { return EZType.DebugError; } }
    public string Message = "";

    public override void Execute()
    {
        Debug.LogError(Message);
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
