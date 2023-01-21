using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{

    // The target position where the ball will be thrown
    public Transform target;

    // The force with which the ball will be thrown
    public float throwForce = 20f;

    GameObject ClickToMove;

    // The ball prefab to instantiate when the ball is thrown
    public GameObject ballPrefab;

    // The position from which the ball will be instantiated
    public Transform spawnPosition;

    // Update is called once per frame
    void Update()
    {


    }
 
    public void ButtonThrow()
    {
        StartCoroutine(Delay());

        IEnumerator Delay()
        {

            yield return new WaitForSeconds(1f);
            // Instantiate a new ball at the spawn position
            GameObject ball = Instantiate(ballPrefab, spawnPosition.position, Quaternion.identity);

            // Calculate the direction of the throw based on the position of the target
            Vector3 throwDirection = (target.position - spawnPosition.position).normalized;

            // Add force to the ball in the desired direction
            ball.GetComponent<Rigidbody>().AddForce(throwDirection * throwForce, ForceMode.Impulse);
        }
      /*  // Instantiate a new ball at the spawn position
        GameObject ball = Instantiate(ballPrefab, spawnPosition.position, Quaternion.identity);

            // Calculate the direction of the throw based on the position of the target
            Vector3 throwDirection = (target.position - spawnPosition.position).normalized;

            // Add force to the ball in the desired direction
            ball.GetComponent<Rigidbody>().AddForce(throwDirection * throwForce, ForceMode.Impulse);*/
    }

}
