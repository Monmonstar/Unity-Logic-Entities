using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

public class logic_timer : MonoBehaviour {

    public float interval;
    public bool beginOnStart;
    public bool triggerOnce;
    public bool randomTime;
    public float randomMin;
    public float randomMax;

    public UnityEvent onTimerFinished;

    float timer;
    bool ticking;


	// Use this for initialization
	void Start () {
        if(randomMin >= randomMax && randomTime){
            Debug.LogWarning("randomMin is higher than randomMax! Aborting...");
            return;
        }
		
        SetTimer();

        if(beginOnStart){
            StartTimer();
        }
    }
    
    public void SetTimer(){
		if(randomTime){
			timer = Random.Range(randomMin, randomMax);
        } else {
            timer = interval;
        }

    }

    public void StartTimer(){
        ticking = true;
    }

	void OnDrawGizmos()
	{
        Gizmos.color = Color.yellow;
        for (int i = 0; i < onTimerFinished.GetPersistentEventCount(); i++)
        {
            object obj = onTimerFinished.GetPersistentTarget(i);
            GameObject go = obj as GameObject;
            Gizmos.DrawLine(transform.position, go.transform.position);
        }
    }

	// Update is called once per frame
	void Update () {
        if(ticking){
            timer -= Time.deltaTime;

            if(timer <= 0){
                onTimerFinished.Invoke();
                SetTimer();

                if (triggerOnce)
                    ticking = false;
            }
        }
	}

    [MenuItem("GameObject/Logic Nodes/Logic Timer", false, 10)]
    static void CreateCustomGameObject(MenuCommand menuCommand)
    {
        // Create a custom game object
        GameObject go = new GameObject("Logic_Timer");
        go.AddComponent<logic_timer>();
        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }
}
