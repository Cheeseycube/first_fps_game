using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JetPack : MonoBehaviour
{
    private Rigidbody rb;
    private JetpackFuelBar JetpackBar;
    //Animator myAnim;

    [SerializeField] float thrust = 8f; // 10f // 8f when using addforce
    float jetpackTimeCounter = 0f;
    float maxJetpackTime = 1f; // 0.3f 0.7
    [SerializeField] float maxVerticalSpeed = 3f; // 3f
    public static bool isFlying = false;
    float maxAccel = 3f;
    float terminalVelocity = 13f;
    float idealDrag;
    float canJump;
    bool isGrounded = false;
    
    // turn off gravity when button is pressed to fix build issues perhaps?

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //myAnim = GetComponent<Animator>();

        if (GetComponent<JetpackFuelBar>())
        {
            JetpackBar = GetComponent<JetpackFuelBar>();
        }
        //idealDrag = maxAccel / terminalVelocity; // may remove if it poses a problem later
        //rb.drag = idealDrag / (idealDrag * Time.fixedDeltaTime + 1);
    }

    // Update is called once per frame
    void Update()
    {
        fly();
        GroundCheck();
       // print(isGrounded);
    }

    IEnumerator RefuelWait() // was called TakeLife()
    {
        yield return new WaitForSecondsRealtime(3f);
        jetpackTimeCounter -= Time.deltaTime;
    }

    IEnumerator FuelSetWait()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        jetpackTimeCounter = 0f;
    }

   private void GroundCheck()
    {
        RaycastHit hit;
        float distance = 2f;
        Vector3 dir = new Vector3(0, -1);

        Debug.DrawRay(transform.position, dir * distance, Color.green); // drawing the ray
        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    private void fly()
    {
        if (Input.GetButtonDown("Jump") && jetpackTimeCounter <= 0.9) // let's you jump with low fuel
        {
            if (canJump < 0)
            {
                jetpackTimeCounter += 0.1f; // did this to prevent player from spamming jetpack 
            }
            else
            {
                // nothing for now
            }
        }


        if (Input.GetButton("Jump"))
        {
            if (jetpackTimeCounter < maxJetpackTime)
            {
                if (canJump < 0)
                {
                    jetpackTimeCounter += Time.deltaTime;
                }
                else
                {
                    // nothing for now
                }

                if (rb.velocity.y < maxVerticalSpeed)
                {
                    //Physics2D.gravity = new Vector2(0, -38); // added this check to make sure grav is normal
                    rb.AddForce(transform.up * (thrust * Time.deltaTime * 100f)); // no more time.deltatime
                    isFlying = true;
                    canJump -= Time.deltaTime;
                }
            }
        }
        else
        {
            if ((jetpackTimeCounter > 0f) && isGrounded)
            {
                jetpackTimeCounter -= Time.deltaTime;
                //Physics2D.gravity = new Vector2(0, -38);

                //StartCoroutine(RefuelWait());

            }
            else if (isGrounded)
            {
                jetpackTimeCounter = 0f;
            }
            
        }

        

        if (isGrounded)
        {
            isFlying = false;
            canJump = 0.08f;
        }


        if (JetpackBar)
        {
            JetpackBar.UpdateFuelBar(1f - jetpackTimeCounter / maxJetpackTime);
        }



    }

}
