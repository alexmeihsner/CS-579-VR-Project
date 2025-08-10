using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// Attach this to the button / trigger object.
/// Drag the plane (or any GameObject you want to reveal) into “infoPlane”.
/// Works with XR Simple Interactable out of the box.
public class ShowInfoPlane : MonoBehaviour
{
    [SerializeField] private GameObject infoPlane;  // assign in Inspector

    private XRBaseInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();      // XR Simple Interactable, XR Grab Interactable, etc.
        interactable.selectEntered.AddListener(OnSelect);       // hook the event
    }

    private void OnSelect(SelectEnterEventArgs _)
    {
        infoPlane.SetActive(!infoPlane.activeSelf);              // toggle; swap to “true” if you only want to show
    }

    void OnDestroy() => interactable.selectEntered.RemoveListener(OnSelect);
}