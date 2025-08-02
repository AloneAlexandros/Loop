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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentRoom = 0;
    }

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
                CurrentRoom--;
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
        loop.Start();
    }
}
