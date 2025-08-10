using UnityEngine;

/// Put this on the object you want to act as the “beacon”.
/// Drag the player head (CenterEyeAnchor) into “player”.
/// Drag the object you want to appear into “objectToShow”.
public class ProximityReveal : MonoBehaviour
{
    [SerializeField] private Transform player;       // usually OVRCameraRig/CenterEyeAnchor
    [SerializeField] private GameObject objectToShow;
    [SerializeField] private float showDistance = 2f; // metres
    [SerializeField] private bool hideWhenFar = true; // toggle off again when you walk away

    void Start() => objectToShow?.SetActive(false);

    void Update()
    {
        if (!player || !objectToShow) return;

        bool close =
            (player.position - transform.position).sqrMagnitude <= showDistance * showDistance;

        if (close && !objectToShow.activeSelf)         objectToShow.SetActive(true);
        else if (!close && hideWhenFar && objectToShow.activeSelf) objectToShow.SetActive(false);
    }
}