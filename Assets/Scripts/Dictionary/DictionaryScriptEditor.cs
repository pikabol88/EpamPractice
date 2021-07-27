
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DictionarySoundsScript))]
public class DictionaryScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (((DictionarySoundsScript)target).modifyValues)
        {
            if (GUILayout.Button("Save changes"))
            {
                ((DictionarySoundsScript)target).DeserializeDictionary();
            }

        }
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        if (GUILayout.Button("Print Dictionary"))
        {
            ((DictionarySoundsScript)target).PrintDictionary();
        }
    }
}