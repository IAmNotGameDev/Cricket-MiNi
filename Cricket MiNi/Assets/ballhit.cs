using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ballhit : MonoBehaviour
{
    public Rigidbody rb;
    private int ballTounchCount = 0;
    BatsmanControl bt;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBall", 5f);
        bt = GameObject.FindObjectOfType<BatsmanControl>();
        Physics.gravity = new Vector3(0, -0.0F, 0);
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
            if (bt.sl == true) {
            float ballForce = Random.Range(1f, 10f);
            float ballHeight = Random.Range(1f, 15f);
            float ballPosition = Random.Range(-5f, 5f);

            Vector3 BallDirection = new Vector3(-ballForce, ballHeight, ballPosition);
            rb.AddForce(BallDirection, ForceMode.Impulse);
            }
            if (bt.sf == true)
            {
                float ballForce = Random.Range(1f, 3f);
                float ballHeight = Random.Range(1f, 15f);
                float ballPosition = Random.Range(-5f, 5f);

                Vector3 BallDirection = new Vector3(-ballForce, ballHeight, ballPosition);
                rb.AddForce(BallDirection, ForceMode.Impulse);
            }
            if (bt.sr == true)
            {
                float ballForce = Random.Range(-5f, -15f);
                float ballHeight = Random.Range(1f, 15f);
                float ballPosition = Random.Range(-5f, 5f);

                Vector3 BallDirection = new Vector3(-ballForce, ballHeight, ballPosition);
                rb.AddForce(BallDirection, ForceMode.Impulse);
            }
            if (bt.sb == true)
            {
                float ballForce = Random.Range(-1f, -3f);
                float ballHeight = Random.Range(1f, 15f);
                float ballPosition = Random.Range(-5f, 5f);

                Vector3 BallDirection = new Vector3(-ballForce, ballHeight, ballPosition);
                rb.AddForce(BallDirection, ForceMode.Impulse);
            }
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
            Physics.gravity = new Vector3(0, -9.8F, 0);
        }
    }
}

