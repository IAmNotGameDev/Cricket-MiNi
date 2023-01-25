using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject ballPrefab;
    public GameObject currentBall;
    public Vector3 ballSpawnPosition;
    public TextMeshProUGUI runText;
    public int totalRuns = 0;

    public bool LegSpineB = false;
    public bool OffSpineB = false;


    public bool FastBall = false;
    public bool SlowBall = false;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        UpdateRuns(0);
    }
    // Update is called once per frame
    public void Update()
    {


    }

    public void FB()
    {
        FastBall = true;
    }

    public void SB()
    {
        SlowBall = true;
    }

    public void LS()
    {
        LegSpineB = true;
    }
    public void FS()
    {
        OffSpineB = true;
    }
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();
            }

            return instance;
        }
    }

    public void UpdateRuns(int score)
    {
        totalRuns = totalRuns + score;
        runText.text = "Runs:" + totalRuns;
    }
}