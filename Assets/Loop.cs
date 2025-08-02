using UnityEngine;
using UnityEngine.UI;

public class Loop : MonoBehaviour
{
    public GameObject loopyBoi;
    private bool _rotate = false;

    public Rigidbody2D player;

    [SerializeField] private float force;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.transform.position = Input.mousePosition;
            this.GetComponent<Image>().enabled = true;
            loopyBoi.GetComponent<Image>().enabled = true;
            _rotate = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            //player movement logic 
            this.GetComponent<Image>().enabled = false;
            loopyBoi.GetComponent<Image>().enabled = false;
            _rotate = false;
            player.AddForce(transform.right * force);
        }

        if (_rotate)
        {
           // Quaternion rotation = Quaternion.LookRotation(
           //     Input.mousePosition - transform.position,
           //     transform.TransformDirection(Vector3.up)
           //     );
           // transform.rotation = new Quaternion( 0 , 0 , rotation.z , rotation.w ); 
           transform.right = Input.mousePosition - transform.position;
        }
        
    }
}
