using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    public Image splashImage; // assign in inspector
    public float displayTime = 10f;

    private void Start()
    {
        StartCoroutine(ShowSplash());
    }

    private System.Collections.IEnumerator ShowSplash()
    {
        splashImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        splashImage.gameObject.SetActive(false);
    }
}