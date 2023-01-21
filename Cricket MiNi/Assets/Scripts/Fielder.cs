using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fielder : MonoBehaviour
{
    private CapsuleCollider CapsuleCollider;
    // Start is called before the first frame update
    private Rigidbody rb;
    public float speed = 10f;
    public float desiredDistance = 1f;
    public void Start()
    {
        CapsuleCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
    }

    public void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Ball")
        {
            // Calculate the distance to the ball
            float distanceToBall = Vector3.Distance(transform.position, other.transform.position);

            // Check if the distance to the ball is greater than the desired distance
            if (distanceToBall > desiredDistance)
            {
                // Calculate the direction to the ball
                Vector3 moveDirection = other.transform.position - transform.position;

                // Normalize the direction to ensure consistent speed
                moveDirection = moveDirection.normalized;

                // Move the fielder towards the ball
                rb.position = Vector3.MoveTowards(transform.position, other.transform.position, speed * Time.deltaTime);
            }
        }
    }
}
