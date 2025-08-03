using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class Movethatcamera : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform playerTransform;
    public static int CurrentRoom = 0;

    public Loop loop;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player?")
        {
            //if player going right, right, else, left. simple!
            if (playerTransform.position.x < transform.position.x)
            {
                CurrentRoom++;
            }
            else
            {
                ResetMap();
            } 
            ResetMap();
        }
    }

    public void ResetMap()
    {
        cameraTransform.DOMoveX(18.29f*CurrentRoom, 0.3f);
        playerTransform.DOMoveX(-7 + 18.29f*CurrentRoom, 1);
        playerTransform.DOMoveY(0, 1);
        playerTransform.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        playerTransform.DOScale(new Vector3(0.65f, 0.65f, 0.65f), 1);
        loop.Start();
    }
}
