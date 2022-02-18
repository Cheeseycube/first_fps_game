using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamLook : MonoBehaviour
{
    [SerializeField] public float sensitivity = 5.0f; // 5 for smoothing, 20 for no smoothing
    [SerializeField] public float smoothing = 2f; // normally 2

    public GameObject Player;
    // gets the incremental value of the mouse moving
    private Vector2 mouseLook;
    // smooths the mouse moving
    private Vector2 smoothV; // may remove smoothing if it feels necessary

    public bool PlayerFlipped = false;
    public float Rotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Player = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // md is mouse delta
        var md = new Vector2(Input.GetAxisRaw("Mouse X") * sensitivity, Input.GetAxisRaw("Mouse Y") * sensitivity);
       // md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing)); // start commenting here
        // the interpolated float result between the two float values
        //smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        //smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        //incrementally adds to the camera look
        //mouseLook += smoothV; // end comments here
        mouseLook += md;

        //vector3.right means x-axis // uncomment this for everything to work
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        Player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Player.transform.up);

        // trying to remove smoothing
        //transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        //Player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Player.transform.up);
    }

    private void Update()
    {
        /*Rotation = Player.transform.localRotation.eulerAngles.y;
        if (Rotation > 100 && Rotation < 250) // need to make this more accurate
        {
            PlayerFlipped = true;  // flip gun
            print(PlayerFlipped);
        }

        if (PlayerFlipped && Rotation > 225)
        {
            PlayerFlipped = false; // flip gun
            print(PlayerFlipped);
        }*/
    }
}
