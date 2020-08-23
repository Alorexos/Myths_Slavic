using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public float turnSpeed = 10.0f;
    //public float moveSpeed = 10.0f;
    //public float mouseTurnMultiplier = 1;

    //private float x;
    //private float z ;
    //void Update()
    //{
    //    // x is used for the x axis.  set it to zero so it doesn't automatically rotate
    //    x = 0;

    //    // check to see if the W or S key is being pressed.  
    //    z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

    //    // Move the character forwards or backwards
    //    transform.Translate(0, 0, z);

    //        // Get the A or S key (-1 or 1)
    //        x = Input.GetAxis("Horizontal");

    //    // Check to see if the right mouse button is pressed
    //    if (Input.GetMouseButton(1))
    //    {
    //        // Get the difference in horizontal mouse movement
    //        x = Input.GetAxis("Mouse X") * turnSpeed * mouseTurnMultiplier;
    //    }

    //    // rotate the character based on the x value
    //    transform.Rotate(0, x, 0);
    //}

    Rigidbody Rigidbody;
    public GameObject PlayerCamera;

    ////// Animator playeranim;
    //////public float speed = 10.0f;
    public float CameraFolllow = 10.0f;
    public float speed = 10.0f;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 2.0f;
    private bool grounded = false;

    private float CameraY;

    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.freezeRotation = true;
        Rigidbody.useGravity = false;
    }

    void FixedUpdate()
    {
        Vector3 targetVelocity = Vector3.zero;
        Vector3 velocity;
        Vector3 velocityChange;
        Quaternion CameraRotation = Quaternion.identity;

        // Character movement
        if (grounded)
        {
            // Calculate how fast we should be moving
            if (Input.GetAxis("Vertical") != 0)
            {
                targetVelocity = new Vector3(0, 0, Mathf.Abs(Input.GetAxis("Vertical")));
            }

            if (Input.GetAxis("Horizontal") != 0)
            {
                targetVelocity = new Vector3(0, 0, Mathf.Abs(Input.GetAxis("Horizontal")));
            }

            //targetVelocity = new Vector3(0, 0, Mathf.Abs(Input.GetAxis("Vertical")));
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;

            // Apply a force that attempts to reach our target velocity
            velocity = Rigidbody.velocity;
            velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            Rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

            // Jump
            if (canJump && Input.GetButton("Jump"))
            {
                Rigidbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
            }
        }

        // Character rotation
        if (targetVelocity != Vector3.zero)
        {
            // Rotate player to follow camera forward view
            CameraY = PlayerCamera.transform.rotation.eulerAngles.y;
            
            if(Input.GetAxis("Vertical") < 0 )
            {
                CameraY = ClampAngle(CameraY - 180.0f);
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                CameraY = ClampAngle(CameraY - 90.0f);
            }

            if (Input.GetAxis("Horizontal") > 0)
            {
                CameraY = ClampAngle(CameraY + 90.0f);
            }

            CameraRotation.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, CameraY, transform.rotation.eulerAngles.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, CameraRotation, CameraFolllow * Time.deltaTime);
        }


        // We apply gravity manually for more tuning control
        Rigidbody.AddForce(new Vector3(0, -gravity * Rigidbody.mass, 0));
        grounded = false;
    }

    void OnCollisionStay()
    {
        grounded = true;
    }

    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }

    static float ClampAngle(float angle)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return angle;
    }
    //// Start is called before the first frame update
    //void Start()
    //{

    //    //if (rb)
    //    //    rb.freezeRotation = true;
    //    //playeranim = GetComponent<Animator>();
    //    //originalRotation = transform.localRotation;
    //}
}
