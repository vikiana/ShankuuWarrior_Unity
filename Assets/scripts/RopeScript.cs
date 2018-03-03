using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOT IN USE

public class RopeScript : MonoBehaviour {

    public Vector2 dest;
    public float speed;

    public GameObject nodePrefab;
    public GameObject player;
    public float nodeDistance;
    GameObject lastNode;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        lastNode = transform.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, dest, speed);//Vector2.Lerp (transform.position, dest, Time.deltaTime*speed);
        if ((Vector2)transform.position != dest)
        {
            if (Vector2.Distance(transform.position, dest) >= nodeDistance)
            {
                //createNode();
            }
        }
    }

    void createNode ()
    {
        Debug.Log(lastNode.transform.position+" - ");
        Debug.Log(player.transform.position+" = ");
        Vector2 nodePos = lastNode.transform.position - player.transform.position;
        Debug.Log(nodePos);
        nodePos.Normalize();
        Debug.Log("normalize"+nodePos);
        nodePos *= nodeDistance;
        nodePos += (Vector2)lastNode.transform.position;
        Debug.Log("adding"+(Vector2)lastNode.transform.position+":"+nodePos);
        lastNode = Instantiate(nodePrefab, new Vector3 (nodePos.x, nodePos.y), Quaternion.identity);
    }
}
;