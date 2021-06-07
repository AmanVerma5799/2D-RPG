using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothing = 0.1f;

    public Transform target;

    public Vector2 minPosition, maxPosition;
    public VectorValue camMin, camMax;

    private Animator cameraAnimator;

    private void Awake()
    {
        cameraAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        minPosition = camMin.initialValue;
        maxPosition = camMax.initialValue;
    }

    void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }

    public void CameraKick()
    {
        cameraAnimator.SetBool("kickActive", true);
        StartCoroutine(KickCoroutine());
    }

    public IEnumerator KickCoroutine()
    {
        yield return null;

        cameraAnimator.SetBool("kickActive", false);
    }
}
