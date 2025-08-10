using UnityEngine;

/// <summary>
/// Shows a target object for a set number of seconds.
/// Works with:
/// • XR events → call TriggerAction() from an “Activated”/“Select Entered” event
/// • Mouse clicks in Play-in-Editor (OnMouseDown)
/// </summary>
public class Reveal : MonoBehaviour
{
    [Header("Assign in Inspector")]
    public GameObject objectToReveal;   // drag the plane (or any GameObject) here
    public float visibleDuration = 20f; // seconds the object stays visible

    public void TriggerAction()
    {
        if (!objectToReveal) return;
        objectToReveal.SetActive(true);
        CancelInvoke(nameof(HideObject));
        Invoke(nameof(HideObject), visibleDuration);
    }

    private void HideObject() => objectToReveal.SetActive(false);

    // Lets you test in non-VR builds
    private void OnMouseDown() => TriggerAction();
}