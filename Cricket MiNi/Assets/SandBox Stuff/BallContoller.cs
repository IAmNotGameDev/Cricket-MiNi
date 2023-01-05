using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    public float ballSpeed = 1f;

    private int ballTounchCount = 0;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.AddForce(Vector3.back * ballSpeed, ForceMode.Impulse);
        Invoke("DestroyBall", 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestroyBall()
    {
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bat"))
        {
            float ballForce = Random.Range(5f, 30f);
            float ballHeight = Random.Range(1f, 15f);
            float ballPosition = Random.Range(-10f, 10f);

            Vector3 BallDirection = new Vector3(-ballForce, ballHeight, ballPosition);
            rb.AddForce(BallDirection, ForceMode.Impulse);
        }

        if (other.gameObject.CompareTag("Boundary"))
        {
            if (ballTounchCount <= 1)
            {
                GameManager.instance.UpdateRuns(6);
            }
            else
            {
                GameManager.instance.UpdateRuns(4);
            }
        }

        if (other.gameObject.CompareTag("Out"))
        {
            GameManager.instance.totalRuns = 0;
            GameManager.instance.UpdateRuns(0);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ballTounchCount++;
        }
    }
}
