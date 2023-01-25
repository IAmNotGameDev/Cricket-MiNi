using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlerAI : MonoBehaviour
{
    public GameManager GM;
    public ThrowBall throwBall;
    public BallSpine spineBall;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Randomly select between FastBall and SlowBall
            int randomNum = Random.Range(0, 2);
            if (randomNum == 0)
            {
                GM.FastBall = true;
            }
            else
            {
                GM.SlowBall = true;
            }

            // Randomly select between LegSpin and OffSpin
            int spinType = Random.Range(0, 2);
            if (spinType == 0)
            {
                GM.LegSpineB = true;
            }
            else
            {
                GM.OffSpineB = true;
            }

            // Throw the ball
            throwBall.ButtonThrow();
        }
    }
}
