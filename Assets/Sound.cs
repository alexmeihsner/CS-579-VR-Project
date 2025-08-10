using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Collider))]
public class AudioZone : MonoBehaviour
{
    void Reset()
    {
        // Make sure this collider is a trigger
        var col = GetComponent<Collider>();
        col.isTrigger = true;
    }

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        // full 3D sound
        audioSource.spatialBlend = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        // play when the object named "camera" enters
        if (other.gameObject.name == "Player")
        {
            audioSource.Play();
            Debug.Log($"[AudioZone] Playing clip «{audioSource.clip?.name}»");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            audioSource.Stop();
            Debug.Log("[AudioZone] Stopped");
        }
    }
}