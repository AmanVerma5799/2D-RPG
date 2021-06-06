using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMapChange : MonoBehaviour
{
    public Vector2 minCameraChange, maxCameraChange;
    public Vector3 playerChange;

    private CameraFollow mainCamera;

    void Start()
    {
        mainCamera = Camera.main.GetComponent<CameraFollow>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            mainCamera.minPosition += minCameraChange;
            mainCamera.maxPosition += maxCameraChange;

            other.transform.position += playerChange;
        }
    }
}
