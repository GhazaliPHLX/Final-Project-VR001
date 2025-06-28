using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    public GameObject player;
    public float collisionValue = 0f;
    public float fadeSpeed = 1f;
    private bool isColliding = false;

    private void Awake()
    {
        if (isColliding)
        {
            collisionValue = 1f;
        }
        else 
        {
            collisionValue -= Time.deltaTime * fadeSpeed;
            collisionValue = Mathf.Clamp01(collisionValue);
        }

        isColliding = false;
    }
    private void OnCollisionStay(Collision collision)
    {
        isColliding = true;
    }

    private void Update()
    {
        
    }
}
