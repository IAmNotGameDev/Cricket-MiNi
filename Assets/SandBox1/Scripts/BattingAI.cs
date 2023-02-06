using UnityEngine;
using System.Collections;

public class BattingAI : MonoBehaviour
{
    public BatsmanControl batmanControl;
    private bool canShoot = false;
    public Transform targetP;

    void Start()
    {

    }

    void Update()
    {
        if (GameObject.FindWithTag("Ball"))
        {
            canShoot = true;
        }
        if (canShoot)
        {
            if (targetP.position.x >= 0.5)
            {
                batmanControl._ShotRight();
                canShoot = false;
            }
            if (targetP.position.x <= 1)
            {
                batmanControl._ShotLeft();
                canShoot = false;
            }
        }
    }
}
