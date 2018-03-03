using System.Collections;
using UnityEngine;


public class GrapplingHook : MonoBehaviour
{

    public DistanceJoint2D hookJoint;
    public float maxLaunch;
    public LayerMask layermask;
    public float hookForce = 8;
    //seconds for the animation to wait. 
    public float throwWait = 0.5f;

    Vector3 targetPos;
    RaycastHit2D hit;
    float lastHookedPos;
    Rigidbody2D body;
    bool once;
    //bool throwHook;
    private Animator warriorAnimation;
    string currentTrigger;
    float prevY;

    void Start()
    {
        hookJoint = GetComponent<DistanceJoint2D>();
        hookJoint.enabled = false;
        layermask = LayerMask.GetMask("ledges");
        body = GetComponent<Rigidbody2D>();
        warriorAnimation = GetComponent<Animator>();
        currentTrigger = "throw";
        once = false;
        prevY = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GetComponent <PlayerAnimation>().orientWarrior(targetPos.x);
            //Grapple(targetPos);
            StartCoroutine(throwGrapple());

        }
        //mobile controls
        else if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            { 
                targetPos = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position);
                GetComponent <PlayerAnimation>().orientWarrior(targetPos.x);
                //Grapple(targetPos);
                StartCoroutine(throwGrapple());
            }
        }
        if (once == true)
        {
            if (lastHookedPos - transform.position.y <= 0.3)
            {
                Debug.Log("throw!");
                hookJoint.maxDistanceOnly = true;
                hookJoint.distance = 100;
                body.AddForce(hit.normal * hookForce * -1, ForceMode2D.Impulse);
                lastHookedPos = 0;
                warriorAnimation.SetBool("airReady", true);
                currentTrigger = "airThrow";
                once = false;
            }
        }
        //falling?
        //Debug.Log("FALLING?"+warriorAnimation.GetBool("fall") + ", " + prevY + ", " + transform.position.y);
        if (prevY != transform.position.y)
        { 
            warriorAnimation.SetBool("fall", prevY < transform.position.y ? false : true);
            prevY = transform.position.y;
        }
        //on ground?
        GameObject ground = GameObject.FindGameObjectWithTag("ground");
        if (transform.position.y <= ground.transform.position.y + 2f){ warriorAnimation.SetBool("airReady", false); }
            currentTrigger = "throw";
        }

    //Coroutine
    IEnumerator throwGrapple()
    {
        Debug.Log("startCoroutine");
        //Animation
        warriorAnimation.SetTrigger(currentTrigger);
        //wait for animation
        yield return new WaitForSeconds(throwWait);
        //Can only shoot up
        Debug.Log("warrior height:" + GetComponent<SpriteRenderer>().bounds.size.y);
        if (targetPos.y < transform.position.y + GetComponent<SpriteRenderer>().bounds.size.y)
            yield return null;

        targetPos.z = 0;
        hit = Physics2D.Raycast(transform.position,
                                    targetPos - transform.position,
                                    maxLaunch,
                                    layermask);
        Debug.DrawRay(transform.position, targetPos - transform.position, Color.green, 2, false);
        if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            hookJoint.enabled = true;
            hookJoint.maxDistanceOnly = false;
            hookJoint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
            hookJoint.distance = 0.2f;
            lastHookedPos = hookJoint.connectedBody.position.y;
            once = true;
        }
    }


    //NOT IN USE
    /**void Grapple(Vector3 targetPos)
    {
        //Can only shoot up
        Debug.Log("warrior height:"+ GetComponent<SpriteRenderer>().bounds.size.y);
        if (targetPos.y < transform.position.y + GetComponent<SpriteRenderer>().bounds.size.y)
            return;

        targetPos.z = 0;
        hit = Physics2D.Raycast(transform.position,
                                    targetPos - transform.position,
                                    maxLaunch,
                                    layermask);
        Debug.DrawRay(transform.position, targetPos - transform.position, Color.green, 2, false);
        if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            hookJoint.enabled = true;
            hookJoint.maxDistanceOnly = false;
            hookJoint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
            //Vector2 posToVect2 = new Vector2(transform.position.x, transform.position.y);
            hookJoint.distance = 0.2f;// Vector2.Distance( posToVect2, hit.point);
            lastHookedPos = hookJoint.connectedBody.position.y;
            once = true;
        }
    }**/
}
