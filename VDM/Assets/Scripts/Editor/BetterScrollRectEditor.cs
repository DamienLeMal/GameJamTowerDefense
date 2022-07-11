using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine.EventSystems;
[CustomEditor(typeof(BetterScrollRect), true)]
public class BetterScrollRectEditor : ScrollRectEditor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
    }
}
