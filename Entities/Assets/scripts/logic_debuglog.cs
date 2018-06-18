﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class logic_debuglog : logic_base {

    public string message;

    public void DisplayMessageInConsole(){
        Debug.Log(message);
    }

    [MenuItem("GameObject/Logic Nodes/Logic Debug Log", false, 10)]
    static void CreateCustomGameObject(MenuCommand menuCommand)
    {
        // Create a custom game object
        GameObject go = new GameObject("Logic_DebugLog");
        go.AddComponent<logic_debuglog>();
        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }
}
