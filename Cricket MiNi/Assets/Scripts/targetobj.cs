using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetobj : MonoBehaviour
{
    // The force with which the ball will be thrown
    public float throwForce = 20f;

    // The joystick used to control the direction of the throw
    public Joystick joystick;

    // The damping factor to apply to the movement of the target
    public float damping = 0.1f;

    // The minimum and maximum positions for the target in the x and z directions
    public float xpositionLimitMin = 1f;
    public float xpositionLimitMax = 2f;

    public float zpositionLimitMin = 1f;
    public float zpositionLimitMax = 2f;
    // Update is called once per frame
    void Update()
    {
        // Check if the joystick is being used
        if (joystick.Horizontal != 0f || joystick.Vertical != 0f)
        {
            // Calculate the direction of the throw based on the joystick input
            Vector3 throwDirection = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);
            throwDirection.x *= -1;
            throwDirection.z *= -1;

            // Normalize the direction to ensure consistent force
            throwDirection = throwDirection.normalized;

            // Update the position of the target based on the joystick input
            transform.position += (throwDirection * throwForce) * damping;

            // Clamp the position of the target to the specified limits
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, xpositionLimitMin, xpositionLimitMax),
                transform.position.y,
                Mathf.Clamp(transform.position.z, zpositionLimitMin, zpositionLimitMax)
            );
        }
    }
}
