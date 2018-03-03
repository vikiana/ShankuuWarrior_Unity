using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    SpriteRenderer sprite;
    Vector2 screenBounds;
    Vector2 screenOrigo;
    Vector3 pos;

    // Use this for initialization
    void Start () {
        sprite = transform.gameObject.GetComponent<SpriteRenderer>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        screenOrigo = Camera.main.ScreenToWorldPoint(Vector2.zero);
    }
	
	// Update is called once per frame
	void Update () {
        pos = transform.position;
        //infinity horizonal boundaries
        if (pos.x > screenBounds.x)
        {
            transform.position = new Vector3(screenOrigo.x, pos.y, pos.z);
        }
        if (pos.x < screenOrigo.x)
        {
            transform.position = new Vector3(screenBounds.x, pos.y, pos.z);
        }
    }

    public void orientWarrior(float X)
    {
        GetComponent<SpriteRenderer>().flipX = X > transform.position.x ? true : false;
    }
}
