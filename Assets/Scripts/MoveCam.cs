using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform cameraPosition;

    void Update()
    {
        Debug.Log("Running MoveCam");
        transform.position = cameraPosition.position;
        
    }
}
