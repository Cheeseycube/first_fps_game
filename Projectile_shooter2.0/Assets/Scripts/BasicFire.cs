using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject FirePoint;
    public GameObject CameraPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireGun();
            //print("Fire!");
        }
        //print(CameraPoint.transform.rotation);
    }

    private void FireGun()
    {
        Instantiate(bulletPrefab, FirePoint.transform.position, CameraPoint.transform.rotation);
    }
}
