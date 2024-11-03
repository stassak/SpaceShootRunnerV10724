using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 1000;
    private float lowerBound = -1000;
    public float TimeToLive = 5f;

    // Start is called before the first frame update
   
    private void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
            Destroy(gameObject);
       
    }
}
