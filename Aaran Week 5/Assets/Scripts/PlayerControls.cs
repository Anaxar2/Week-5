using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    float lowerBound = -3;

    [Header ("PowerUps")]
    public bool hasRepel;
    public bool hasJump;
    public float powerUpStrength;
    public GameObject powerUpIndicator;

    [Header ("Jump")]
    public float jumpForce;
    public float GravityMod;

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
        if (Input.GetKeyDown(KeyCode.B) && timer <= 0)
        {
            Destroy(Instantiate(Wall, transform.position - FocalPoint.transform.forward, FocalPoint.transform.rotation), 3);
            timer = 1;
        }
        //Power Up Indicator
        {
            powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
            powerUpIndicator.SetActive(hasRepel);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Repel")) // checks if player has collided with object with tag PowerUp.
        {
         hasRepel = true; // makes has powerup true.
         Destroy(other.gameObject); // Destroys powerUp Icon after colliding with it.
         powerUpIndicator.gameObject.SetActive(true);
         StartCoroutine(PowerUpCoolDown());
        }
        if (other.CompareTag("Jump")) // checks if player has collided with object with tag PowerUp.
        {
         hasJump = true; // makes has powerup true.
         Destroy(other.gameObject); // Destroys powerUp Icon after colliding with it.
         powerUpIndicator.gameObject.SetActive(true);
         StartCoroutine(ShockWaveCoolDown());
        }
        if(Input.GetKeyDown(KeyCode.Space) && hasJump)
        {//jump
         rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") &&hasRepel)
        {
         Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
         Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
         enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
    IEnumerator PowerUpCoolDown()
    {
     yield return new WaitForSeconds(10);
     powerUpIndicator.gameObject.SetActive(false);
     hasRepel = false;
    }
    IEnumerator ShockWaveCoolDown()
    {
     yield return new WaitForSeconds(10);
     powerUpIndicator.gameObject.SetActive(false);
     hasJump = false;
    }

}