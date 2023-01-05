using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballhit : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bat"))
        {
            float ballForce = Random.Range(5f, 30f);
            float ballHeight = Random.Range(1f, 15f);
            float ballPosition = Random.Range(-5f, 5f);

            Vector3 BallDirection = new Vector3(-ballForce, ballHeight, ballPosition);
            rb.AddForce(BallDirection, ForceMode.Impulse);
        }
    }
}
