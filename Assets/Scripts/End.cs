using DG.Tweening;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject endText;
    public GameObject particles;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player?")
        {
            endText.SetActive(true);
            endText.transform.DOPunchScale(new Vector3(0.005f,0.005f,0.005f),0.5f);
            Instantiate(particles, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            this.GetComponent<AudioSource>().Play();
        }
    }
}