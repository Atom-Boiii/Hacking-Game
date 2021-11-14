using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed, downForce;
    private float speed, xRot;

    CharacterController cc;
    private void Start()
    {
        cc = GetComponent<CharacterController>();

        speed = moveSpeed;
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        float _xMov = Input.GetAxis("Horizontal");
        float _zMov = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(_xMov, downForce, _zMov);

        float _yRot = Input.GetAxis("Mouse X");
        transform.Rotate(0f, _yRot, 0f);

        xRot -= Input.GetAxis("Mouse Y");
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        velocity = transform.rotation * velocity;

        cc.Move(velocity * speed * Time.deltaTime);
    }
}
