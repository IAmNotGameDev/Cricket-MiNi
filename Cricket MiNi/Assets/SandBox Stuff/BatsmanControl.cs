using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatsmanControl : MonoBehaviour
{   public Rigidbody rb;
    [SerializeField] Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            }

        private void Shot()
    {
        _ShotLeft();
        _ShotRight();
        _ShotFront();
        _ShotBack();
    }
    public void _ShotLeft()
    {
        StartCoroutine(ShotLeft());
        IEnumerator ShotLeft()
        {
            playerAnimator.SetBool("Left", true);
            yield return new WaitForSeconds(2f);

            playerAnimator.SetBool("Left", false);
        }
    }
    public void _ShotRight()
    {
        StartCoroutine(ShotRight());
        IEnumerator ShotRight()
        {
            playerAnimator.SetBool("Right", true);
            yield return new WaitForSeconds(2f);

            playerAnimator.SetBool("Right", false);
        }
    }
    public void _ShotFront()
    {
        StartCoroutine(ShotFront());

        IEnumerator ShotFront()
        {
            playerAnimator.SetBool("Front", true);
            yield return new WaitForSeconds(2f);

            playerAnimator.SetBool("Front", false);
        }
    }
    public void _ShotBack()
    {


            StartCoroutine(ShotBack());


        IEnumerator ShotBack()
        {
            playerAnimator.SetBool("Back", true);
            yield return new WaitForSeconds(2f);

            playerAnimator.SetBool("Back", false);
        }
    }

}
