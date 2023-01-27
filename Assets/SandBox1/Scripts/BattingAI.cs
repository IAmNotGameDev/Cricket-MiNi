using UnityEngine;
using System.Collections;

public class BattingAI : MonoBehaviour
{
    public BatsmanControl batmanControl;
    private bool canShoot = false;

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
            batmanControl._ShotLeft();
            canShoot = false;
        }
    }
}
