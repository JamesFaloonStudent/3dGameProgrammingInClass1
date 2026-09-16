using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class MainPlayerController : MonoBehaviour
{



    private InputAction moveAction;
    private CharacterController characterController;
    private Vector2 move;

    [SerializeField]
    private float speed = 5f;


    void Awake()
    {
        // This is a very important line of code. It allows us to access the Input System actions that we created in the Input Actions asset.
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        move = moveAction.ReadValue<Vector2>();

        Vector3 deltaMove = new Vector3(move.x, 0f, move.y) * speed * Time.deltaTime;

        characterController.Move(deltaMove);
    }
}
