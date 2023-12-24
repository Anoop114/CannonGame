using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 1;
    public float BlastPower = 5;

    public GameObject Cannonball;
    public Transform ShotPoint;

    public GameObject Explosion;

    [SerializeField] private Slider xAxisRotation;
    [SerializeField] private Slider yAxisRotation;
    
    
    private void Start()
    {
        xAxisRotation.onValueChanged.AddListener(RotateCannonXAxis);
        yAxisRotation.onValueChanged.AddListener(RotateCannonYAxis);
    }

    private void RotateCannonYAxis(float angle)
    {
        var rot = transform.eulerAngles;
        rot.z = angle;
        transform.eulerAngles = rot;
    }

    private void RotateCannonXAxis(float angle)
    {
        var rot = transform.eulerAngles;
        rot.y = angle;
        transform.eulerAngles = rot;
    }

    private void Update()
    {
        // float HorizontalRotation = Input.GetAxis("Horizontal");
        // float VericalRotation = Input.GetAxis("Vertical");
        //
        // transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + 
        //     new Vector3(0, HorizontalRotation * rotationSpeed, VericalRotation * rotationSpeed));

        if (!Input.GetKeyDown(KeyCode.Space)) return;
        var CreatedCannonball = Instantiate(Cannonball, ShotPoint.position, ShotPoint.rotation);
        CreatedCannonball.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * BlastPower;
            
        // Added explosion for added effect
        Destroy(Instantiate(Explosion, ShotPoint.position, ShotPoint.rotation), 2);

        // Shake the screen for added effect
        Screenshake.ShakeAmount = .2f;
    }


}
