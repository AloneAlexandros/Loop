using System.Collections;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
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

    [SerializeField] private int overrideLevel;

    private float _timeSinceLastClick = 1;

    private bool _doNotShoot = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        LoopsLeft = loopsPerRound[Movethatcamera.CurrentRoom];
        #if UNITY_EDITOR
        if (overrideLevel != 0)
        {
            Movethatcamera.CurrentRoom = overrideLevel;
            LoopsLeft = 0;
            overrideLevel = 0;
            player.transform.Translate(18.29f * Movethatcamera.CurrentRoom, 0, 0);
        }
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        _timeSinceLastClick += Time.deltaTime;
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
            if (_timeSinceLastClick < 0.3f)
            {
                movethatcamera.ResetMap();
                _doNotShoot = true;
                _timeSinceLastClick = 0;
                return;
            }
            _timeSinceLastClick = 0;
            this.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.2f);
            this.transform.position = Input.mousePosition;
            this.GetComponent<Image>().enabled = true;
            loopyBoi.GetComponent<Image>().enabled = true;
            loopText.enabled = true;
            _rotate = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (_doNotShoot)
            {
                _doNotShoot = false;
                return;
            }
            //player movement logic 
            this.GetComponent<Image>().enabled = false;
            loopyBoi.GetComponent<Image>().enabled = false;
            _rotate = false;
            loopText.enabled = false;
            if (LoopsLeft > 0)
            {
                player.AddForce(loopyBoi.transform.right * force);
                player.transform.localScale = new Vector3(0.65f,0.65f,0.65f);
                player.transform.DOPunchScale(new Vector3(-0.2f, 0.2f, 0.1f), 0.3f);
                LoopsLeft--;
                _resetable = false;
                StartCoroutine(QuickWait());
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            movethatcamera.ResetMap();
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
    }
    IEnumerator QuickWait()
    {
        yield return new WaitForSeconds(0.5f);
        _resetable = true;
    }
}
