using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    public Vector2 turn;
    [SerializeField] public float GunSens = 20;

    [SerializeField] public GameObject Player;

    private float Rotation = 0f;
    private bool PlayerFlipped = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //turn.x += Input.GetAxisRaw("Mouse X");
        turn.y += Input.GetAxisRaw("Mouse Y");
        transform.localRotation = Quaternion.Euler(-turn.y * GunSens * 20, /*turn.x * GunSens * 0.5f*/0, 0);
    }

    /*private void Update()
    {
        Rotation = Player.transform.localRotation.eulerAngles.y;
        if (Rotation > 100 && Rotation < 250 && PlayerFlipped == false) // need to make this more accurate
        {
            PlayerFlipped = true;  // flip gun
            print(PlayerFlipped);
            turn.x = 0f;  // better solution would probably be to limit how far it can rotate, as opposed to just setting it's rotation to zero which can be quite jarring
        }

        if (PlayerFlipped && Rotation > 300)
        {
            PlayerFlipped = false; // flip gun
            print(PlayerFlipped);
            turn.x = 0f;
        }
    }*/
}
