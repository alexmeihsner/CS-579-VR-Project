using UnityEngine;

public class GlobeRotation : MonoBehaviour
{
    public float rotationSpeed = 10f; // degrees per second

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}