using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    private float bulletSpeed = 10f;
    public MeshRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend.enabled = false;
        StartCoroutine(lifetimer());
        StartCoroutine(VisibilityTimer());
    }

    // Update is called once per frame
    

    private void Update()
    {
        //transform.Translate(0.01f*0f, 0.01f*0f, 0.03f *1f);
    }

    private void FixedUpdate()
    {
        transform.Translate(0.01f * 0f, 0.01f * 0f, 0.5f * 1f);  // was 0.03 * 1 // currently 0.5f * 1f
    }
    IEnumerator VisibilityTimer()
    {
        yield return new WaitForSeconds(0.05f);  // This is a bit of a temporary fix
        rend.enabled = true;

    }
    IEnumerator lifetimer()
    {
        yield return new WaitForSeconds(3f);
        if (gameObject != null)
        {
            Destroy(this.gameObject);
        }
    }

    
}
