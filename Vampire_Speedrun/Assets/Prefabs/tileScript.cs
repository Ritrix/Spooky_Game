using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Tilemaps;
#endif

[CustomGridBrush(false, true, false, "My First Brush")]
public class MyFirstBrush : GridBrushBase
{
#if UNITY_EDITOR
    [MenuItem("Assets/Prefabs/My First Brush")]
    public static void CreateBrush()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save First Brush", "New First Brush", "asset", "Save First Brush");
        if (path == null)
            return;

        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<MyFirstBrush>(), path);
    }
#endif
}

[CustomEditor(typeof(MyFirstBrush))]
public class MyFirstBrushEditor : GridBrushEditor
{ }

