using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    // movement
    public float speed = 10.0f; // was 10.0f
    private float translation;
    private float strafe;
    private bool PressedEscape = false;
    private bool playerHasHorizontalSpeed = false;

    // Raycast Collisions
    private float numCols = 0f;
    private float RayDist = 1f;
    private bool TouchingFwd = false;
    private bool TouchingBckwd = false;
    private bool TouchingRight = false;
    private bool TouchingLeft = false;

    // Rigidbody Collisions
    Rigidbody rb;

    public GameObject CamPos;
    public GameObject PlayerCam;
    [SerializeField] Rigidbody PlayerBody;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Locked; // turns off cursor
        //Cursor.lockState = CursorLockMode.Confined;
        Application.targetFrameRate = 60;

    }

    // Update is called once per frame
    void Update()
    {
        //translation = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        //strafe = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        MoveSetVelocity();

        if  (Input.GetKeyDown("escape"))
        {
            // turns on cursor
            PressedEscape = true;
            Cursor.lockState = CursorLockMode.None;
        }

        //Rotate();
    }

    private void FixedUpdate()
    {
        
    }

    private void MoveSetVelocity()
    {
        strafe = Input.GetAxisRaw("Horizontal");
        translation = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = transform.forward * translation * speed + transform.right * strafe * speed;
        moveDirection.y = PlayerBody.velocity.y;
        //rb.velocity = new Vector3(strafe * speed, rb.velocity.y, translation * speed);
        //rb.AddForce()
        PlayerBody.velocity = moveDirection; // could use addforce() instead
        //print(rb.velocity.y);
    }

    private void MoveAddForce()
    {
        strafe = Input.GetAxisRaw("Horizontal");
        translation = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = transform.forward * translation + transform.right * strafe;
        rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Acceleration);
        

    }

    /*private void Rotate()
    {
        
        //transform.localRotation = Quaternion.Euler(0, PlayerCam.transform.localRotation.y, 0);
        transform.localRotation = PlayerCam.transform.localRotation;
    }*/


}
