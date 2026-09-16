using UnityEngine;
using UnityEngine.Cameras;

public class CameraController : MonoBehaviour
{

    public List<Camera> cameras;

    void Awake()
    {
        cameras = new List<Camera>(GetComponentsInChildren<Camera>());
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
