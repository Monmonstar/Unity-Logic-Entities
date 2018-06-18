using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class logic_onupdate : logic_base {

    public UnityEvent onUpdate;

	void Update () {
        onUpdate.Invoke();
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (int i = 0; i < onUpdate.GetPersistentEventCount(); i++)
        {
            object obj = onUpdate.GetPersistentTarget(i);
            GameObject go = obj as GameObject;
            Gizmos.DrawLine(transform.position, go.transform.position);
        }
    }
}
