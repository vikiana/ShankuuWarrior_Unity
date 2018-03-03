using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    // the height we want the camera to be above the target. Below 0 to be under
    [SerializeField]
    private float height = -0.3f;
    [SerializeField]
    private float heightDamping = 0.2f;

    //Transform pTransform;
    Vector2 screenBounds;
    float buffer = 3;
    Vector3 oPos;
    //Quaternion oRot;

    //parallax
    public GameObject pBkg;
    [SerializeField]
    private float pFactor = 0.01f;
    private float prevY;



    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        pBkg = GameObject.FindGameObjectWithTag("Background");
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        oPos = transform.position;
        prevY = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //FOLLOW PLAYER
        if (player.transform.position.y > screenBounds.y - buffer)
        {
            float currentHeight = player.transform.position.y;
            // Set the height of the camera
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
            // move parallax background
            parallaxBkg(currentHeight);
        } 
        else
        {
            //camera back
            transform.position = Vector3.MoveTowards(transform.position, oPos, heightDamping);
        }
	}

    void parallaxBkg (float cHeight)
    {
        float wantedHeight = player.transform.position.y + height;
        // Damp the height
        cHeight = Mathf.MoveTowards(cHeight, wantedHeight, heightDamping);
        float direction = prevY < player.transform.position.y ? 1f : -1f;
        //Debug.Log(prevY+", "+pBkg.transform.position.y+", "+direction + ", "+pBkg.transform.position.y + cHeight / pFactor * Time.deltaTime * direction);
        pBkg.transform.position = new Vector3(pBkg.transform.position.x, pBkg.transform.position.y + cHeight / pFactor * Time.deltaTime * direction, pBkg.transform.position.z);
        prevY = player.transform.position.y;
    }
}
