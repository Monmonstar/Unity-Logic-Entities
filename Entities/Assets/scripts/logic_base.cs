using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class logic_base : MonoBehaviour {

	private void OnEnabled()
	{
        gameObject.name = gameObject.name + " (" + ObjectNames.GetClassName(this) + ")";
	}

    void OnDrawGizmos()
    {
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.MiddleCenter;
        //HandleUtility.GetHandleSize.handleSize =
        //Vector3 labelPos = T
        Handles.Label(transform.position, gameObject.name, style);
    }
}