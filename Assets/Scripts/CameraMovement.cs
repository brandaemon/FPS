using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    private float vertical;
    public float offset;
    public int ammo;
    public int maxAmmo;
    public int reserves;
    public int raycastDistance;

    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Vertical look
        vertical = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.right, -vertical * speed *  Time.deltaTime);

        // Shoot
        if (Input.GetButtonDown("Fire1") && ammo > 0)
        {
            Instantiate(bulletPrefab, transform.position + transform.forward * offset, Quaternion.LookRotation(transform.forward) * Quaternion.Euler(90, 90, 90));
            ammo--;
        }

        // Reload
        if (Input.GetKeyDown("r"))
        {
            while(ammo < maxAmmo && reserves > 0)
            {
                ammo++;
                reserves--;
            }
        }

        // Interact
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
