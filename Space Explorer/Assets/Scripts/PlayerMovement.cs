using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float forceMagnitude = 10f;
    [SerializeField] private float maxForce = 100f;
    [SerializeField] private float rotationSpeed = 10f;
    private Vector3 movementDirection;

    private Camera mainCamera;
    private Rigidbody rigidBody;

    private SpaceExplorer spaceExplorer;
    private InputAction move;


    private void Awake()
    {
        spaceExplorer = new SpaceExplorer();
        spaceExplorer.Player.Enable();        
    }

    void Start()
    {
        mainCamera = Camera.main;
        rigidBody = GetComponent<Rigidbody>();
        move = spaceExplorer.Player.Move;
        move.performed += PlayerInput;
    }

    public void PlayerInput(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
    }


    void Update()
    {
        ScreenLoop();        
    }
    

    void FixedUpdate()
    {
        MovePlayer();

        RotatePlayer();
    }

    private void MovePlayer()
    {
        if (movementDirection == Vector3.zero) { return; }

        movementDirection = move.ReadValue<Vector2>();

        rigidBody.AddForce(movementDirection * forceMagnitude * Time.deltaTime, ForceMode.Force);
        rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, maxForce);
    }

    

    private void ScreenLoop()
    {
        Vector3 viewPortPosition = transform.position;
        Vector3 viewPortPoint = mainCamera.WorldToViewportPoint(transform.position);

        if(viewPortPoint.x > 1f)
        {
            viewPortPosition.x = -viewPortPosition.x + 0.1f;
        }
        else if(viewPortPoint.x < 0f)
        {
            viewPortPosition.x = -viewPortPosition.x - 0.1f;
        }

        if (viewPortPoint.y > 1f)
        {
            viewPortPosition.y = -viewPortPosition.y + 0.1f;
        }
        else if (viewPortPoint.y < 0f)
        {
            viewPortPosition.y = -viewPortPosition.y - 0.1f;
        }

        transform.position = viewPortPosition;
    }

    private void RotatePlayer()
    {
        if(rigidBody.velocity == Vector3.zero) { return; }

        Quaternion targetRotation = Quaternion.LookRotation(rigidBody.velocity, Vector3.back);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

}
