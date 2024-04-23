using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header ("Movement")]
    Rigidbody rb;
    public float moveSpeed = 5f;
    
   [Header ("Game Objects")]
    GameObject FocalPoint;
    GameObject Player;
    public GameObject Wall;
    public GameManager gm;

    [Header("Boundries")]
    public float lowerBound = -3;

    private float timer = 5;


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

        // if player goes below -3 on the y axis respwn at start position.


        if (transform.position.y < lowerBound)
        {
            transform.position = new Vector3(0, 0, -1);

        }
        // lose 1 left when player goes below -3 on the y axis.
        if (transform.position.y < lowerBound)
        {
            gm.Lives -= 1;
        }

        // spawn walls on left mouse click
        timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && timer <= 0)
        {
            Destroy(Instantiate(Wall, transform.position + FocalPoint.transform.forward, FocalPoint.transform.rotation), 3);
            timer = 1;
        }
    }
}