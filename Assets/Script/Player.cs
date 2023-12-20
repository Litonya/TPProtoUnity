using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField]
    private float speed = 10f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        //LookMouse();
    }

    private void LateUpdate()
    {
        LookMouse();
    }


    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        characterController.SimpleMove(moveDirection * speed * Time.deltaTime);
    }

    private void LookMouse()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay,out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Default"), QueryTriggerInteraction.Ignore))
        { 
            Vector3 pos = hit.point;
            Debug.DrawLine(pos, transform.position, Color.red);
            
            pos.y = transform.position.y;

            Debug.DrawLine(pos, transform.position, Color.green);
            transform.rotation = Quaternion.LookRotation(pos - transform.position);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }

}
