using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject ballPrefab;
    public GameObject currentBall;
    public Vector3 ballSpawnPosition;
    public TextMeshProUGUI runText;
    public int totalRuns= 0;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        UpdateRuns(0);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Invoke("ThrowBall", 1.5f);

        }
    }

    public void ThrowBall()
    {
        Instantiate(ballPrefab, ballSpawnPosition, Quaternion.identity);
    }

    public void UpdateRuns(int score)
    {
        totalRuns = totalRuns + score;
        runText.text = "Runs:"+totalRuns;
    }
}
