using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 10f;
    // private float angle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move() {
        Vector3 pos = transform.up;
        Vector3 vec = new Vector3(0,pos.y,0);
        rb.AddForce(vec * speed * Time.deltaTime);

    }
}
