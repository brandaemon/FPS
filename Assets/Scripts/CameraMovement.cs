using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 800.0f;
    private float vertical;
    public float offset = 0.5f;
    public int ammo = 10;
    public int raycastDistance;

    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.right, -vertical * speed *  Time.deltaTime);

        if (Input.GetButtonDown("Fire1") && ammo > 0)
        {
            Instantiate(bulletPrefab, transform.position + transform.forward * offset, Quaternion.LookRotation(transform.forward) * Quaternion.Euler(90, 90, 90));
            ammo--;
        }

        if (Input.GetKeyDown("e"))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Interactable"))
                {
                    Debug.Log("interacted with: " + hit.collider.gameObject.name);
                }
            }
        }
    }
}
