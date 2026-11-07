using System.Reflection.Metadata;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public static Player Instance {get ; private set;}
    [Header("Opciones")]
    private bool freeze;
    [Header("Movimiento")]
    public float walkSpeed = 5f;
    public float SprintSpeed = 8f;
    public float CrouchSpeed = 3f;

    [Header("Salto y gravedad")]
    public float jumpForce = 6f;
    public float gravity = 20f;


    [Header("Cámara y Ratón")]
    public float mouseSensitivity= 2f;
    public float upDownRange = 85.0f;

    [Header("Referencias")]
    public Camera playerCamera;

    //Variables internas
    CharacterController characterController;
    private Vector3 moveDirection;
    private float verticalRotation;

    //Variables de Cámara}
    private float defaultCameraY;
    private float CurrentCameraY;
    private float timer = 0f;
    private bool isCrouching = false;

    private void awake()
    {
        if (Instance == null){Instance = this;}
        else{Destroy(gameObject);}
    }
    void start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (playerCamera != null)
        {
            defaultCameraY = playerCamera.transform.localPosition.y;
        }
        //characterController.height = standingHeight;


    }
    void update()
    {
        if (!freeze)
        {
            handleMouseLock();
            handleMovement();
        }
    }

    private void handleMouseLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isLocked = Cursor.lockState == CursorLockMode.Locked;
            Cursor.lockState = isLocked ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isLocked;
        }

        if (Cursor.lockState != CursorLockMode.Locked)
        {
            return;
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);
        verticalRotation = Mathf.Clamp(verticalRotation - mouseY, -upDownRange, upDownRange);
        if (playerCamera != null)
        {
            playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        }
    }

    private void handleMovement()
    {
        if (characterController == null)
        {
            return;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 inputDirection = transform.right * horizontal + transform.forward * vertical;
        inputDirection = Vector3.ClampMagnitude(inputDirection, 1f);

        isCrouching = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.C);
        float speed = isCrouching
            ? CrouchSpeed
            : Input.GetKey(KeyCode.LeftShift) ? SprintSpeed : walkSpeed;

        moveDirection.x = inputDirection.x * speed;
        moveDirection.z = inputDirection.z * speed;

        if (characterController.isGrounded)
        {
            if (moveDirection.y < 0f)
            {
                moveDirection.y = -2f;
            }

            if (!isCrouching && Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }
    
}
