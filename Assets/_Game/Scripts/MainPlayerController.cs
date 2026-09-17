using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class MainPlayerController : MonoBehaviour
{

    // all fields related to the Input Actions
    private InputAction moveAction;
    private CharacterController characterController;
    private Vector2 move;
    [SerializeField]
    private float speed = 5f;

    // all fields related to animation 
    private Animator animator;


    // a method design to track each time the camera does a transformation within the game i.e when the app goes behind the Boss to the Side 
    [SerializeField]
    private Transform cameraTransform;


    // on awake find the move input action 
    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();


        //if the postion of the camera is not set and there is a main camera set it 
        if (cameraTransform == null && Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
            Debug.Log(cameraTransform);
        }

        moveAction.Enable();
    }

    // check if there is a move action and move based on the postion of the camera 
    void Update()
    {
        move = moveAction.ReadValue<Vector2>();

        Vector3 deltaMove = CameraRelative(move) * speed * Time.deltaTime;

        characterController.Move(deltaMove);
    }

    // Used to move character based on Camera rather then world 
    private Vector3 CameraRelative(Vector2 input)
    {

        // if no camera is assigned for whatever reason just moved based on the direction of the world 
        if (cameraTransform == null)
        {
            return new Vector3(input.x, 0f, input.y);
        }

        // how far forward should we move 
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;


        // return how the character should move based on the camera and the input values 
        return right * input.x + forward * input.y;
    }
}
