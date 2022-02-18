using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMouseCamera : MonoBehaviour
{
    public Vector2 turn;
    [SerializeField] public float sensitivity = 20f;
    public Vector3 deltaMove;
    public float speed = 1;
    public float rotationLimit = 45.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // turns out the issue with the player sliding is caused by the entire capsule rotating.  Just don't rotate at all and go in third person to see what I mean
        //turn.x += Input.GetAxis("Mouse X") * sensitivity; //* Time.deltaTime;
        //turn.y += Input.GetAxis("Mouse Y") * sensitivity; //* Time.deltaTime;
        //Vector3 rotation = Mathf.Clamp()
        //transform.localRotation = Quaternion.Euler(Mathf.Clamp(-turn.y, -rotationLimit, rotationLimit), turn.x, 0);
    }

    private void FixedUpdate()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity; //* Time.deltaTime;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity; //* Time.deltaTime;
        transform.localRotation = Quaternion.Euler(Mathf.Clamp(-turn.y, -rotationLimit, rotationLimit), turn.x, 0);
    }
}
