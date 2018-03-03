using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameControllerScript : MonoBehaviour {

    /*protected GameObject hook;
    protected LineRenderer rope;
    protected StandaloneInputModule inputModule;

    protected Vector2 lineEndPos;

    private void Awake()
    {
        hook = GameObject.FindGameObjectWithTag("hook");
        rope = hook.GetComponent<LineRenderer>();
        lineEndPos = hook.transform.position;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        drawLine();
	}

    public void handleLedgeClicks (PointerEventData pData)
    {
        lineEndPos = pData.position;
    }

    void drawLine ()
    {
        if (!lineEndPos.Equals (hook.transform.position))
        {
            rope.enabled = true;
            rope.startWidth = 0.1f;
            rope.startColor = Color.yellow;
            rope.endColor = Color.yellow;
            rope.sortingLayerName = "Default";
            rope.SetPosition(0, hook.transform.position);
            rope.SetPosition(1, lineEndPos);
        }
    }*/

    
}
