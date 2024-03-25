using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float maxSpeed;
    public float speed;
    public float rotationSpeed;
    public float jumpForce;
    private float horizontal;
    private float vertical;
    private float mouseX;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");

        /*
        float rotation = mouseX * rotationSpeed;
        Quaternion deltaRotation = Quaternion.Euler(0, rotation, 0);
        rb.MoveRotation(rb.rotation * deltaRotation);
        */
        
        float rotation = mouseX * rotationSpeed;
        transform.Rotate(Vector3.up, rotation * Time.deltaTime);
        
        // print(rb.velocity.magnitude);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce/*, ForceMode.Impulse*/);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * vertical * speed * Time.deltaTime);
        rb.AddForce(transform.right * horizontal * speed * Time.deltaTime);

        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
