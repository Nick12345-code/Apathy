using UnityEngine;
using NullFrameworkException.Mobile.InputHandling;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool onComputer;
    [SerializeField] private bool onMobile;
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
        DeviceCheck();

        if (onComputer)
        {
            Move();
            Look(); 
        }

        if (onMobile)
        {
            MobileMove();
            MobileLook(); 
        }
    }

    private void DeviceCheck()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            onComputer = true;
            onMobile = false;
        }

        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            onComputer = false;
            onMobile = true;
        }
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
            // get direction player is facing initially
            Vector3 dir = hit.point - transform.position;

            // get the angle between the original direction and target direction
            float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;

            // set the angle into a usable quaternion
            Quaternion rotation = Quaternion.Euler(new Vector3(0, -angle + 90, 0));

            // rotate player smoothly
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }
    #endregion

    #region Mobile Controls
    private void MobileMove()
    {
        // store the vertical axis input in moveZ
        float moveX = joystick.Axis.x;
        float moveZ = joystick.Axis.y;

        // put moveX and moveZ into a Vector3
        moveDirection = new Vector3(-moveX, 0, -moveZ);

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
        float angle = Mathf.Atan2(joystick.Axis.y, joystick.Axis.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, -angle - 90, 0)), Time.deltaTime * rotationSpeed);
    }
    #endregion
}