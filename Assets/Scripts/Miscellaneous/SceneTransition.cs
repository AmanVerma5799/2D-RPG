using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;

    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;

    public VectorValue playerMemory;

    public float fadeWait;

    public Vector2 newCameraMin, newCameraMax;
    public VectorValue cameraMin, cameraMax;

    private void Awake()
    {
        if(fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity);
            Destroy(panel, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerMemory.initialValue = playerPosition;

            StartCoroutine(FadeCoroutine());
        }
    }

    public IEnumerator FadeCoroutine()
    {
        if (fadeOutPanel != null)
        {
            GameObject panel = Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }

        yield return new WaitForSeconds(fadeWait);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);

        ResetCameraBonds();

        while(!asyncOperation.isDone)
        {
            yield return null;
        }
    }

    public void ResetCameraBonds()
    {
        cameraMax.initialValue = newCameraMax;
        cameraMin.initialValue = newCameraMin;
    }
}
