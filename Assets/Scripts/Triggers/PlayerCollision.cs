using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        var responders = collision.gameObject.GetComponents<IColliding>();
        foreach (var responder in responders)
        {
            responder.Trigger();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IColliderTrigger trigger = other.GetComponent<IColliderTrigger>();
        if (trigger != null)
        {
            trigger.ColliderTrigger();
        }
    }
}
