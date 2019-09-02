using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    Transform tr;
    private LaserCaster laserCaster;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        laserCaster = GameObject.FindGameObjectWithTag("RController").GetComponent<LaserCaster>();
    }

    void FixedUpdate()
    {
        if (tr.position.y <= 0.1f)
        {
            laserCaster.Drop();
        }
    } 
}
