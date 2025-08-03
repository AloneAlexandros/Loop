using Unity.VisualScripting;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform destination;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player?")
        {
            other.transform.position = destination.position;
        }
    }
}
