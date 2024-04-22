using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header ("Movement")]
    Rigidbody rb;
    public float moveSpeed = 5f;

    [Header ("Game Objects")]
    GameObject FocalPoint;

    // Start is called before the first frame update
    void Start()
    {
     //accessn to rigidbody.
      rb = GetComponent<Rigidbody>();

        //access to Focal Point
        FocalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        // move forward using vertical input.
        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(FocalPoint.transform.forward * forwardInput * moveSpeed);
    }
}
