using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTwo : MonoBehaviour
{
    CapsuleCollider capsule;
    Rigidbody body;
    Camera cam;

    //player's health
    public float HP;
    //the bar that shows the player's health
    public BarController HPBar;
    //how much acceleration will cause how much damage? x axis is acceleration, y axis is the ammount of damage it'll do
    public AnimationCurve AccelDamage;
    //velocity on previous frame
    public Vector3 PVel;

    //camera angle up/down
    float LookAngle = 90;
    //mouse sensitivity
    public Vector2 Sensitivity = Vector2.one;
    //movement buttons
    public Axis Horizontal;
    public Axis Vertical;
    public Axis Jump;
    public Axis Sprint;

    //local velocity to be applied
    Vector3 vel;
    //current local velocity
    Vector3 velocity;
    //is the player on the ground
    public bool isGrounded;
    //do i need to explain?
    public bool isSwimming;
    //what y value is sea level?
    public float WaterLevel;
    //how much drag does the player encounter in the water?
    public float WaterDrag;
    public float maneuverableSpeed;
    //how fast can the player go?
    public float MaxSpeed = 3;
    //how fast does the player go additionally when sprinting? how much slower do they go when sneaking?
    public float SprintAddition = 2;
    //how fast can the player go fast?
    public float Acceleration = 20;
    //how fast is the player's jump
    public float JumpVelocity = 4.24f;

    void Start()
    {
        capsule = gameObject.GetComponent<CapsuleCollider>();
        body = gameObject.GetComponent<Rigidbody>();
        cam = gameObject.GetComponentInChildren<Camera>();

        //confines the cursor to the center of the window and makes it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        PVel = body.velocity;
    }

    void Update()
    {
        /*Player Motion*/

        //rotate the player
        transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * Sensitivity.x, 0);
        //pan the camera
        LookAngle -= Input.GetAxis("Mouse Y") * Sensitivity.y; LookAngle = Mathf.Clamp(LookAngle, 0, 180);
        cam.transform.localEulerAngles = Vector3.right * (LookAngle - 90);
        if (!isSwimming)
        {
            if (Vector3.Magnitude(new Vector3(body.velocity.x, 0, body.velocity.z)) > maneuverableSpeed)
            {
                //get the current local velocity
                velocity = transform.InverseTransformVector(body.velocity);
                //set the change in local acceleration and limit it to the max acceleration magnitude
                vel = new Vector3((Mathf.Abs(velocity.x) < MaxSpeed + (Sprint.getAxis() * SprintAddition)) ? (Horizontal.getAxis() * Acceleration * Time.deltaTime) : 0, 0, (Mathf.Abs(velocity.z) < MaxSpeed + (Sprint.getAxis() * SprintAddition)) ? (Vertical.getAxis() * Acceleration * Time.deltaTime) : 0);
                vel *= (vel.magnitude > Acceleration * Time.deltaTime) ? (Acceleration * Time.deltaTime) / vel.magnitude : 1;
                //insert the jump velocity if the player jumps
                if (Input.GetKeyDown(Jump.positive) && isGrounded)
                    vel.y = JumpVelocity;
                //convert back to global and add the desired acceleration to the global velocity
                body.velocity += transform.TransformVector(vel);
            }
            else
            {
                vel = new Vector3(Horizontal.getAxis(), 0, Vertical.getAxis());
                if (vel.magnitude > 0) vel *= 1 / vel.magnitude;
                body.velocity = Vector3.Lerp(transform.TransformVector(vel * (MaxSpeed + (SprintAddition * Sprint.getAxis()))) + (Vector3.up * body.velocity.y), body.velocity, 0.5f);
                if (Input.GetKeyDown(Jump.positive) && isGrounded)
                    body.velocity += Vector3.up * JumpVelocity;
            }

            if (cam.transform.localPosition.y != 1.5f)
            {
                cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, Vector3.up * 1.5f, 0.1f);
                if (cam.transform.localPosition.y > 1.495f) cam.transform.localPosition = Vector3.up * 1.5f;
            }
        }
        else
        {
            //get the current local velocity from the camera
            velocity = cam.transform.InverseTransformVector(body.velocity);
            //set the change in local acceleration and limit it to the max acceleration magnitude
            vel = new Vector3((Mathf.Abs(velocity.x) < MaxSpeed + (Sprint.getAxis() * SprintAddition)) ? (Horizontal.getAxis() * Acceleration * Time.deltaTime) : 0, 0, (Mathf.Abs(velocity.z) < MaxSpeed + (Sprint.getAxis() * SprintAddition)) ? (Vertical.getAxis() * Acceleration * Time.deltaTime) : 0);
            vel *= (vel.magnitude > Acceleration * Time.deltaTime) ? (Acceleration * Time.deltaTime) / vel.magnitude : 1;
            //convert back to global and add the desired acceleration to the global velocity
            body.velocity += cam.transform.TransformVector(vel);
            //add some gravity above the water line so the player cant just fly around the map
            if (transform.position.y > WaterLevel) body.velocity += Vector3.down * (Acceleration + 5) * Time.deltaTime;

            if (cam.transform.localPosition.y != 0.5f)
            {
                cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, Vector3.up * 0.5f, 0.1f);
                if (cam.transform.localPosition.y < 0.505) cam.transform.localPosition = Vector3.up * 0.5f;
            }
            if (cam.transform.position.y <= WaterLevel) RenderSettings.fogDensity = 0.15f;
            else RenderSettings.fogDensity = 0;
        }

        //update the health bar
        HPBar.value = HP / 10;

        //update the previous velocity to the current velocity so that it'll be different during the next frame
        PVel = body.velocity;
    }

    void LateUpdate()
    {
        //if the player is starting to swim
        if (!isSwimming && transform.position.y < WaterLevel)
        {
            isSwimming = true;
            //make the collider short and re-center it
            capsule.height = 1; capsule.center = Vector3.up / 2;
            //set the rigidbody's drag to the water drag and turn off player gravity
            body.drag = WaterDrag; body.useGravity = false;
        }
        //if the player is leaving the water
        if (isSwimming && transform.position.y > WaterLevel && isGrounded)
        {
            isSwimming = false;
            //make the collider tall and re-center it
            capsule.height = 2; capsule.center = Vector3.up;
            //set the rigidbody's drag to air drag and turn on player gravity
            body.drag = 1; body.useGravity = true;
        }
    }

    //custom input class
    [System.Serializable]
    public class Axis
    {
        //positive keycode
        public string positive;
        //negative keycode
        public string negative;

        //get the combined value of the axi's keys
        public int getAxis()
        {
            if (negative != null) return (Input.GetKey(positive) ? 1 : 0) - (Input.GetKey(negative) ? 1 : 0);
            else return Input.GetKey(positive) ? 1 : 0;
        }
    }

    //we hit something
    void OnCollisionEnter(Collision other)
    {
        //find the magnitude of the acceleration at the time of impact, compare it to the acceleration-damage curve, and apply the corresponding damage to the 
        HP -= AccelDamage.Evaluate(Vector3.Magnitude(body.velocity - PVel));
    }

    //we're touching something
    void OnCollisionStay(Collision other)
    {
        //check where the collider is colliding
        foreach (ContactPoint temp in other.contacts)
        {
            //is it the feet?
            if ((temp.normal.y > .001f))
            {
                //yep, we're grounded
                isGrounded = true;
            }
        }
    }

    //we're no longer touching something
    void OnCollisionExit(Collision other)
    {
        //we're definitely not grounded
        isGrounded = false;
    }
}
