using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class logic_relay : logic_base {

    public UnityEvent onTriggered;

    public void TriggerRelay()
	{
        onTriggered.Invoke();
    }

    public void TriggerRelayDelayed(float delay){
        Invoke("onTriggered.Invoke()", delay);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (int i = 0; i < onTriggered.GetPersistentEventCount(); i++)
        {
            object obj = onTriggered.GetPersistentTarget(i);
            GameObject go = obj as GameObject;
            Gizmos.DrawLine(transform.position, go.transform.position);
        }
    }
}
