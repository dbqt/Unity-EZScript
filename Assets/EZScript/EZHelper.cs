using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class EZHelper {

    #region Helpers

    public static int IndentLevel = 0;

    public static System.Type GetType(EZType type)
    {
        switch (type)
        {
            case EZType.DebugLog:
                return typeof(EZDebugLog);
            case EZType.DebugWarning:
                return typeof(EZDebugWarning);
            case EZType.DebugError:
                return typeof(EZDebugError);
            default:
                return typeof(void);
        }
    }

    public static void AddIndent()
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Space(15);
        EditorGUILayout.BeginVertical();
        IndentLevel++;
    }

    public static void RemoveIndent()
    {
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        IndentLevel--;
    }

    public static void DrawHorizontalLine()
    {
        EditorGUILayout.TextField("", GUI.skin.horizontalSlider);
    }

    public static void StartZone()
    {
        GUIStyle gsTest = EditorStyles.helpBox;
        //gsTest.normal.background = MakeTex(1, 1, new Color(1.0f, 1.0f, 1.0f, 0.2f));
        gsTest.padding = new RectOffset(5,5,5,5);
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
    }

    public static void EndZone()
    {
        EditorGUILayout.EndVertical();
    }

    static private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];

        for (int i = 0; i < pix.Length; i++)
            pix[i] = col;

        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();

        return result;
    }

    #endregion //Helpers
}
