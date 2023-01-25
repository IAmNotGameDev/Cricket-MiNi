using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BowlerAI : MonoBehaviour
{
    public GameManager GM;
    public ThrowBall throwBall;
    public bool FastBall = false;
    public bool SlowBall = false;
    public BallSpine spineBall;
    public targetobj target;

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
            int randomNum = Random.Range(0, 1);
            if (randomNum == 0)
            {
                GM.LegSpineB = true;
            }
            if (randomNum == 1)
            {
                GM.OffSpineB = true;
            }


            int Spine = Random.Range(0, 1);

            if (Spine == 0)
            {
                GM.SlowBall = true;
            }
            if (Spine == 1)
            {
                GM.FastBall = true;
            }
            // Randomly set the position of the target object
            target.transform.position = new Vector3(
                Random.Range(target.xpositionLimitMin, target.xpositionLimitMax),
                target.transform.position.y,
                Random.Range(target.zpositionLimitMin, target.zpositionLimitMax)
            );
            throwBall.ButtonThrow();
        }

    }



    public void AI()
    {
        int randomNum = Random.Range(0, 5);
        if (randomNum == 0)
        { 

            GM.LegSpineB = true;
            GM.FastBall= true;

        }
        if (randomNum == 1)
        {

            GM.LegSpineB = true;
            GM.SlowBall = true;

        }
        if (randomNum == 2)
        {

            GM.OffSpineB = true;
            GM.FastBall = true;

        }
        if (randomNum == 3)
        {

            GM.OffSpineB = true;
            GM.SlowBall = true;

        }
        if (randomNum == 4)
        {

            GM.SlowBall = true;

        }
        if (randomNum == 5)
        {

            GM.FastBall = true;

        }


        // Randomly set the position of the target object
        target.transform.position = new Vector3(
                Random.Range(target.xpositionLimitMin, target.xpositionLimitMax),
                target.transform.position.y,
                Random.Range(target.zpositionLimitMin, target.zpositionLimitMax)
            );
            throwBall.ButtonThrow();
        }

    }

