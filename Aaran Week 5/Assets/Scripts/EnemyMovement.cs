using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header ("Movement")]
    Rigidbody rb;
    public float speed;

    [Header("Game Objects")]
    private GameObject player;

    public float lowerBound = -3;

    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody>(); // get access to RigidBody

        player = GameObject.Find("Player"); // gets access to Game Object with tag Player.
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 lookDirection = (player.transform.position - transform.position).normalized;  // moves enemy to player baased on player position.

     rb.AddForce( lookDirection * speed);
    }

}
