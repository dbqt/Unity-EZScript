using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EZPart : MonoBehaviour {

    public virtual EZType Type { get { return EZType.None; } }
    public EZPart NextPart;
    public int NextPartEnum;

    private void OnDrawGizmos()
    {

        this.hideFlags = HideFlags.HideInInspector;
    }

    public virtual void Execute()
    {
        if (NextPart != null) NextPart.Execute();
    }

    public virtual void DestroySelf()
    {
        // destroy child before self
        if (NextPart != null) NextPart.DestroySelf();

        DestroyImmediate(this);
    }

    public virtual void EditorContent()
    {
        EZHelper.AddIndent();
        EZHelper.StartZone();

        if (NextPart != null)
        {
            NextPart.EditorContent();
            // Remove part button
            if (GUILayout.Button("Remove part", GUILayout.Width(100)))
            {
                // destroy self and all children
                NextPart.DestroySelf();
                NextPart = null;
                // reset enum
                this.NextPartEnum = 0;
                // stop drawing to avoid reference exception
                GUIUtility.ExitGUI();
            }
        }
        else
        {
            // Dropdown to choose type
            this.NextPartEnum = EditorGUILayout.Popup("Type", this.NextPartEnum, Enum.GetNames(typeof(EZType)));
            // set type for adding part button
            EZType newPart = (EZType)this.NextPartEnum;
            if (newPart != EZType.None)
            {
                System.Type type = EZHelper.GetType(newPart);
                // Add part button
                if (GUILayout.Button("Add part", GUILayout.Width(100)))
                {
                    NextPart = this.gameObject.AddComponent(type) as EZPart;
                }
            }
        }
        EZHelper.EndZone();
        EZHelper.RemoveIndent();
    }

}
