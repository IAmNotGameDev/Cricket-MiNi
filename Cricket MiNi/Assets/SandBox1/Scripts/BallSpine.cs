using UnityEngine;

public class BallSpine : MonoBehaviour
{

    GameManager GM;

    public Vector3 force = new Vector3(10, 10, 10);
    private void Start()
    {
        GM = GameObject.FindObjectOfType<GameManager>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && GM.applyForce)
        {
            
            GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            GM.applyForce = false;


        }
    }
}
