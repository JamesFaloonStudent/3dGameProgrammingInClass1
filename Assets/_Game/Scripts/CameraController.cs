using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

 
public class CameraController : MonoBehaviour
{



    // Each Cinemachine camera 
    public List<CinemachineCamera> cameras;
    private int currentCameraIndex = 0; 
    
    // the camera input actions used 
    private InputActionMap cameraActionMap;
    private InputAction switchAction;


    // on awake set find the switchAction from the Camera Action Map and enable it 
    void Awake()
    {
        cameraActionMap = InputSystem.actions.FindActionMap("Camera");
        switchAction = cameraActionMap.FindAction("Switch");
        switchAction?.Enable();
    }

    // adjust Piroirty of cameras so the follow camera is first 
    void Start()
    {
        foreach (var camera in cameras) 
        {
            camera.Priority = 0;
        }
        if(cameras.Count > 0)
        {
            cameras[currentCameraIndex % cameras.Count].Priority = 10;
        }

    }

    // if the switch action button was pressed that frame switch cameras 
    void Update()
    {

        if (cameras.Count == 0 || switchAction == null) return;

        // Only on the frame the button goes down. Reading the value instead
        // would cycle the cameras every frame the button is held.
        bool switched = switchAction.WasPressedThisFrame();

        if (switched)
        {
            cameras[currentCameraIndex].Priority = 0;
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Count;
            cameras[currentCameraIndex].Priority = 10;
        }


    }
}
