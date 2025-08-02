using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Loop : MonoBehaviour
{
    public GameObject loopyBoi;
    private bool _rotate = false;

    public Rigidbody2D player;

    [SerializeField] private float force;

    public static int LoopsLeft = 1;
    public Movethatcamera movethatcamera;

    public int[] loopsPerRound = {1,1};

    private bool _resetable = true;
    public TextMeshProUGUI loopText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        LoopsLeft = loopsPerRound[Movethatcamera.CurrentRoom];
    }

    // Update is called once per frame
    void Update()
    {
        if (LoopsLeft > 0)
        {
            loopyBoi.GetComponent<Image>().color = Color.green;
        }
        else
        {
            loopyBoi.GetComponent<Image>().color = Color.red;
        }
        loopText.text = LoopsLeft.ToString();
        if (LoopsLeft < 1 && player.GetComponent<Rigidbody2D>().linearVelocity.magnitude < 1 && _resetable)
        {
            movethatcamera.ResetMap();
        }
        if (Input.GetMouseButtonDown(0))
        {
            this.transform.position = Input.mousePosition;
            this.GetComponent<Image>().enabled = true;
            loopyBoi.GetComponent<Image>().enabled = true;
            loopText.enabled = true;
            _rotate = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            //player movement logic 
            this.GetComponent<Image>().enabled = false;
            loopyBoi.GetComponent<Image>().enabled = false;
            _rotate = false;
            loopText.enabled = false;
            if (LoopsLeft > 0)
            {
                player.AddForce(loopyBoi.transform.right * force);
                LoopsLeft--;
                _resetable = false;
                StartCoroutine(QuickWait());
            }
        }

        if (_rotate)
        {
           // Quaternion rotation = Quaternion.LookRotation(
           //     Input.mousePosition - transform.position,
           //     transform.TransformDirection(Vector3.up)
           //     );
           // transform.rotation = new Quaternion( 0 , 0 , rotation.z , rotation.w ); 
           loopyBoi.transform.right = Input.mousePosition - transform.position;
        }

        IEnumerator QuickWait()
        {
            yield return new WaitForSeconds(0.5f);
            _resetable = true;
        }
    }
}
