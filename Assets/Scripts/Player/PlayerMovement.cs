using UnityEngine;
using NullFrameworkException.Mobile.InputHandling;

public class PlayerMovement : MonoBehaviour
{
    [Header("Computer")]
    public Health healthScript;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float animationSmoothness;
    private Vector3 moveDirection;
    private CharacterController controller;
    private Animator playerAnimation;
    [Header("Mobile")]
    public JoystickInputHandler joystick;
    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerAnimation = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //Move();
        //Look();
        MobileMove();
        MobileLook();
    }

    #region Computer Controls
    private void Move()
    {
        // store the vertical axis input in moveZ
        float moveZ = Input.GetAxis("Vertical");

        // put moveZ into a Vector3
        moveDirection = new Vector3(0, 0, moveZ);

        // converts the Vector3 from local space to world space
        moveDirection = transform.TransformDirection(moveDirection);

        // if player is moving
        if (moveDirection != Vector3.zero)
        {
            // player is walking
            moveSpeed = walkSpeed;

            // walking animation fades in
            playerAnimation.SetFloat("Speed", 0.5f, animationSmoothness, Time.deltaTime);
        }
        // else if player is standing still
        else if (moveDirection == Vector3.zero && !healthScript.losingHealth)
        {
            // idle animation fades in
            playerAnimation.SetFloat("Speed", 0, animationSmoothness, Time.deltaTime);
        }
        else if (moveDirection == Vector3.zero && healthScript.losingHealth)
        {
            // hurt animation fades in
            playerAnimation.SetFloat("Speed", 1, animationSmoothness, Time.deltaTime);
        }

        // moveDirection is multiplied by moveSpeed
        moveDirection *= moveSpeed;

        // check if character is grounded
        if (controller.isGrounded == false)
        {
            // add gravity vector
            moveDirection += Physics.gravity;
        }

        // moves the player
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void Look()
    {
        // stores info on what ray hits
        RaycastHit hit;

        // ray is shot from the center of the camera to mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // ray is casted
        if (Physics.Raycast(ray, out hit))
        {
            // player looks towards the hit point
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }
    #endregion

    #region Mobile Controls
    private void MobileMove()
    {
        // store the vertical axis input in moveZ
        float moveX = joystick.Axis.x;
        float moveZ = joystick.Axis.y;

        // put moveZ into a Vector3
        moveDirection = new Vector3(-moveX, 0, -moveZ);

        // converts the Vector3 from local space to world space
        moveDirection = transform.TransformDirection(moveDirection);

        // if player is moving
        if (moveDirection != Vector3.zero)
        {
            // player is walking
            moveSpeed = walkSpeed;

            // walking animation fades in
            playerAnimation.SetFloat("Speed", 0.5f, animationSmoothness, Time.deltaTime);
        }
        // else if player is standing still
        else if (moveDirection == Vector3.zero && !healthScript.losingHealth)
        {
            // idle animation fades in
            playerAnimation.SetFloat("Speed", 0, animationSmoothness, Time.deltaTime);
        }
        else if (moveDirection == Vector3.zero && healthScript.losingHealth)
        {
            // hurt animation fades in
            playerAnimation.SetFloat("Speed", 1, animationSmoothness, Time.deltaTime);
        }

        // moveDirection is multiplied by moveSpeed
        moveDirection *= moveSpeed;

        // check if character is grounded
        if (controller.isGrounded == false)
        {
            // add gravity vector
            moveDirection += Physics.gravity;
        }

        // moves the player
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void MobileLook()
    {
        Vector3 relativePos = new Vector3(transform.position.x + joystick.Axis.x, transform.position.y, transform.position.z + joystick.Axis.y) - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime);
    }
    #endregion
}