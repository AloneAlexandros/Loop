using UnityEngine;
using DG.Tweening;

public class PlayerCollideAnimation : MonoBehaviour
{
    public GameObject particles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        transform.localScale = new Vector3(0.65f,0.65f,0.65f);
        transform.DOPunchScale(new Vector3(-0.1f, 0.1f, 0.1f), 0.3f);
        Instantiate(particles, transform.position, Quaternion.identity);
    }
}
