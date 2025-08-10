using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RevealForSecondsUniversal : MonoBehaviour
{
    public GameObject objectToReveal;
    public float visibleDuration = 20f;

    public void TriggerAction()
    {
        if (objectToReveal != null)
        {
            objectToReveal.SetActive(true);
            CancelInvoke(nameof(HideObject));
            Invoke(nameof(HideObject), visibleDuration);
        }
    }

    private void HideObject()
    {
        objectToReveal.SetActive(false);
    }

    // Handles mouse click in editor or non-VR builds
    private void OnMouseDown()
    {
        TriggerAction();
    }
}
