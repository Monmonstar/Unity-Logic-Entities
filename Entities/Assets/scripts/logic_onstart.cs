using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class logic_onstart : logic_base {

    public UnityEvent onStart;

	void Start () {
        onStart.Invoke();
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (int i = 0; i < onStart.GetPersistentEventCount(); i++)
        {
            object obj = onStart.GetPersistentTarget(i);
            GameObject go = obj as GameObject;
            Gizmos.DrawLine(transform.position, go.transform.position);
        }
    }
}