using UnityEngine;
using System.Collections.Generic;

public class WallProximityDetector : MonoBehaviour
{
    [Header("Pengaturan Deteksi")]
    public float detectionRadius = 3f;
    public LayerMask wallLayer;

    // Public data yang bisa diakses oleh script lain
    [HideInInspector] public float leftStrength;
    [HideInInspector] public float rightStrength;
    [HideInInspector] public bool isNearWall;

    void Update()
    {
        // Reset
        leftStrength = 0f;
        rightStrength = 0f;
        isNearWall = false;

        Collider[] walls = Physics.OverlapSphere(transform.position, detectionRadius, wallLayer);

        foreach (var wall in walls)
        {
            Vector3 closestPoint = wall.ClosestPoint(transform.position);
            Vector3 direction = (closestPoint - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, closestPoint);

            if (distance > detectionRadius) continue;

            isNearWall = true;

            float strength = Mathf.Lerp(0.7f, 0.1f, distance / detectionRadius);

            float sideDot = Vector3.Dot(direction, transform.right);

            if (sideDot > 0.1f)
                rightStrength = Mathf.Max(rightStrength, strength);
            else if (sideDot < -0.1f)
                leftStrength = Mathf.Max(leftStrength, strength);
            else
            {
                leftStrength = Mathf.Max(leftStrength, strength * 0.7f);
                rightStrength = Mathf.Max(rightStrength, strength * 0.7f);
            }
        }
    }
}
