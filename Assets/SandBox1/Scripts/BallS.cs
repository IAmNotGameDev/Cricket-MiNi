using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallS : MonoBehaviour
{
    public Rigidbody rb;
    private int ballTounchCount = 0;
    BatsmanControl bt;


    public float LeftForceMin = 0;
    public float LeftForceMax = 0;
    public float LeftHeightMin = 0;
    public float LeftHeightMax = 0;
    public float LeftPositionMin = 0;
    public float LeftPositionMax = 0;





    public float RightForceMin = 0;
    public float RightForceMax = 0;
    public float RightHeightMin = 0;
    public float RightHeightMax = 0;
    public float RightPositionMin = 0;
    public float RightPositionMax = 0;




    public float FrontForceMin = 0;
    public float FrontForceMax = 0;
    public float FrontHeightMin = 0;
    public float FrontHeightMax = 0;
    public float FrontPositionMin = 0;
    public float FrontPositionMax = 0;




    public float BackForceMin = 0;
    public float BackForceMax = 0;
    public float BackHeightMin = 0;
    public float BackHeightMax = 0;
    public float BackPositionMin = 0;
    public float BackPositionMax = 0;



    // Start is called before the first frame update
    void Start()
    {

        Invoke("DestroyBall", 3f);
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

                float ballForceL = Random.Range(LeftForceMin, LeftForceMax);
                float ballHeightL = Random.Range(LeftHeightMin, LeftHeightMax);
                float ballPositionL = Random.Range(LeftPositionMin, LeftPositionMax);
                Vector3 BallDirection = new Vector3(-ballForceL, ballHeightL, ballPositionL);
            rb.AddForce(BallDirection, ForceMode.Impulse);
            }
            if (bt.sf == true)
            {


                float ballForceF = Random.Range(FrontForceMin, FrontForceMax);
                float ballHeightF = Random.Range(FrontHeightMin, FrontHeightMax);
                float ballPositionF = Random.Range(FrontPositionMin, FrontPositionMax);

                Vector3 BallDirection = new Vector3(-ballForceF, ballHeightF, ballPositionF);
                rb.AddForce(BallDirection, ForceMode.Impulse);
            }
            if (bt.sr == true)
            {


                float ballForceR = Random.Range(RightForceMin, RightForceMax);
                float ballHeightR = Random.Range(RightHeightMin, RightHeightMax);
                float ballPositionR = Random.Range(RightPositionMin, RightPositionMax);

                Vector3 BallDirection = new Vector3(-ballForceR, ballHeightR, ballPositionR);
                rb.AddForce(BallDirection, ForceMode.Impulse);
            }
            if (bt.sb == true)
            {


                float ballForceB = Random.Range(BackForceMin, BackForceMax);
                float ballHeightB = Random.Range(BackHeightMin, BackHeightMax);
                float ballPositionB = Random.Range(BackPositionMin, BackPositionMax);

                Vector3 BallDirection = new Vector3(-ballForceB, ballHeightB, ballPositionB);
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

