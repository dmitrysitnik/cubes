using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed = 0.2f;
    private Vector3 movement;
    public int playerLifes = 3;
    private float camRayLength = 100f;
    public int floorMask;

	void Start () {
        rb = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
	}
	

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Move(moveHorizontal, moveVertical);
        Turning();
    }

    void Move(float h, float v)
    {
        
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }


    void Turning()
    {
        
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Quaternion rotationValue = new Quaternion(0f, 0f, 0f, 0f);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            if (rotationValue != newRotation)
            {
                rb.MoveRotation(newRotation);
            }           
            rotationValue = newRotation;
        }
    }
}


