using UnityEngine;

public class BallSpine : MonoBehaviour
{

    GameManager GM;

    public Vector3 LegSpine = new Vector3(10, 10, 10);
    public Vector3 OffSpine = new Vector3(10, 10, 10);
    private void Start()
    {
        GM = GameObject.FindObjectOfType<GameManager>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && GM.LegSpineB)
        {
            
            GetComponent<Rigidbody>().AddForce(LegSpine, ForceMode.Impulse);
            GM.LegSpineB = false;

        }
        if (collision.gameObject.CompareTag("Ground") && GM.OffSpineB)
        {

            GetComponent<Rigidbody>().AddForce(OffSpine, ForceMode.Impulse);
            GM.OffSpineB = false;

        }
    }


}
