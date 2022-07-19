using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 1. 시작 시 출발
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(-2000, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
