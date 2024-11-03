using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CioinEnerg : MonoBehaviour
{
    public float speedRotation = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,speedRotation * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("PickUp");
            PlayerManager.numberOfCoinEnerg += 3;
           // Debug.Log(PlayerManager.numberOfCoinEnerg++);
            Destroy(gameObject);
        }
    }
}
