using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float moveSpeed;
    public CharacterController characterController;
    public Transform cam;
    public float lookSensivity;
    public float maxXRot;
    public float minXRot;
    bool oyunDevam = true;


    private float curXRot;




    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Move();
        Look();


        }
        void Move()
        {
        if (oyunDevam)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            Vector3 dir = transform.right * x + transform.forward * z;
            dir.Normalize();

            dir *= moveSpeed * Time.deltaTime;
            characterController.Move(dir);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

        }

        }
    void Look()
        {
            float x = Input.GetAxis("Mouse X") * lookSensivity;
            float y = Input.GetAxis("Mouse Y") * lookSensivity;

            transform.eulerAngles += Vector3.up * x;

            curXRot += y;
            curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot);
            cam.localEulerAngles = new Vector3(-curXRot, 0.0f, 0f);
        }
    
        
    }
  
