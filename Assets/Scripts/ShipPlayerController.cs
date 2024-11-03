using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPlayerController : MonoBehaviour
{
    private Rigidbody rB;
    [SerializeField] private GameObject planeBody;
    [SerializeField] private GameObject leftTurn;
    [SerializeField] private GameObject rightTurn;

    [SerializeField] private float turnSpeed = 100f;
    [SerializeField] private float smoothnessTurn = 0.03f;
    [SerializeField] private float forwardSpeed = 200f;

    public GameObject projectilePrefab;

    public float xRangeLeft = -200;
    public float xRangeRight = 200;
    public float yRangeUp = 100;
    public float yRangeDown = -30;
    void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        /* if (!PlayerManager.isGameStarted)
         {
             return;
         }*/
        // Launch a projectile from the player
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        if (transform.position.x < xRangeLeft)
            transform.position = new Vector3(xRangeLeft, transform.position.y, transform.position.z);
        if (transform.position.x > xRangeRight)
            transform.position = new Vector3(xRangeRight, transform.position.y, transform.position.z);

        if (transform.position.y > yRangeUp)
            transform.position = new Vector3(transform.position.x, yRangeUp, transform.position.z);
        if (transform.position.y < yRangeDown)
            transform.position = new Vector3(transform.position.x, yRangeDown, transform.position.z);
    }

    void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
        {
            return;
        }
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        rB.velocity = new Vector3(x * turnSpeed, y * turnSpeed, forwardSpeed);

        // Smooth rotation with turn
        if (x < 0)
        {
            planeBody.transform.rotation = Quaternion.Slerp(planeBody.transform.rotation, leftTurn.transform.rotation, smoothnessTurn);
        }
        else if (x > 0)
        {
            planeBody.transform.rotation = Quaternion.Slerp(planeBody.transform.rotation, rightTurn.transform.rotation, smoothnessTurn);
        }
        else if (x == 0)
        {
            planeBody.transform.rotation = Quaternion.Slerp(planeBody.transform.rotation, transform.rotation, smoothnessTurn);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
       /* else if (other.CompareTag("Exit"))
        {
            Application.Quit();

            // If you are testing this in the Unity editor, use this line:
            // UnityEditor.EditorApplication.isPlaying = false;
        }*/
    }
}
