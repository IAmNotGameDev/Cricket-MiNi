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
    public int totalRuns= 0;

    public bool applyForce = false;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        UpdateRuns(0);
    }
    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            applyForce = true;
        }

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
        runText.text = "Runs:"+totalRuns;
    }
}
