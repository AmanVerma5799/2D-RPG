using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChange : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;

    private CameraFollow mainCamera;

    void Start()
    {
        mainCamera = Camera.main.GetComponent<CameraFollow>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            mainCamera.minPosition += cameraChange;
            mainCamera.maxPosition += cameraChange;

            other.transform.position += playerChange; 
        }
    }
}
