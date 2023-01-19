using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BatsmanControl : MonoBehaviour
{   public Rigidbody rb;
    private static BatsmanControl _instance;
    [SerializeField] Animator playerAnimator;
    public bool sl = false;
    public bool sr = false;
    public bool sf = false;
    public bool sb = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            }
    public static BatsmanControl Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<BatsmanControl>();
            }

            return _instance;
        }
    }
    public void Shot()
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
            sl = true;
            playerAnimator.SetBool("Left", true);
            yield return new WaitForSeconds(2f);

            playerAnimator.SetBool("Left", false);
            sl = false;
        }
    }
    public void _ShotRight()
    {
        StartCoroutine(ShotRight());
        IEnumerator ShotRight()
        {
            sr = true;
            playerAnimator.SetBool("Right", true);
            yield return new WaitForSeconds(2f);

            playerAnimator.SetBool("Right", false);
            sr = false;
        }
    }
    public void _ShotFront()
    {
        StartCoroutine(ShotFront());

        IEnumerator ShotFront()
        {
            sf = true;
            playerAnimator.SetBool("Front", true);
            yield return new WaitForSeconds(2f);

            playerAnimator.SetBool("Front", false);
            sf = false;
        }
    }
    public void _ShotBack()
    {


            StartCoroutine(ShotBack());


        IEnumerator ShotBack()
        {
            sb = true;
            playerAnimator.SetBool("Back", true);
            yield return new WaitForSeconds(2f);

            playerAnimator.SetBool("Back", false);
            sb = false;
        }
    }

}
