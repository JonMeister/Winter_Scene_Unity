using UnityEngine;

public class SirenRotation : MonoBehaviour
{
    public float rotationSpeed = 250f;

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}

