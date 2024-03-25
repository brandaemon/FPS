using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    public CameraMovement cameraMovement; // Reference to the CameraMovement script

    private TMP_Text ammoText; // Reference to the Text component
    // Start is called before the first frame update
    void Start()
    {
        ammoText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "Ammo: " + cameraMovement.ammo + "/ " + cameraMovement.reserves;
    }
}
