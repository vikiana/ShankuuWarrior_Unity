using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwhook : MonoBehaviour {

    public GameObject hook;
    private GameObject currHook;
    private Animator warriorAnimation;

	// Use this for initialization
	void Start () {
            currHook = (GameObject) Instantiate (hook, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(throwCoroutine());
        }
	}

    IEnumerator throwCoroutine ()
    {
        Debug.Log("startCoroutine");
        warriorAnimation = GetComponent<Animator>();
        warriorAnimation.SetTrigger("throw");
        //maybe this is not what throws it?
        yield return new WaitForSeconds(10f);
        //Rope Script
        //Vector2 hookDest = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //currHook.GetComponent<RopeScript>().dest = hookDest;
    }
}
