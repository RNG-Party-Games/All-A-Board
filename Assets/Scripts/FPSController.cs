using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class FPSController : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public float moveSpeed = 2.0f;

    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;
    private float rotX;
    private bool locked = true, bullet_time;
    public GameObject cart;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bullet_force;
    private float bullet_current;
    public float bullet_max;
    public BulletMeter bullet_meter;

    private void Start() {
        bullet_current = bullet_max;
        bullet_meter.UpdateTime(bullet_current);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        if(locked && Input.GetButton("Esc")) {
            locked = false;
            Cursor.lockState = CursorLockMode.None;
        }
        else if(!locked && Input.GetMouseButtonDown(0)) {
            locked = true;
            Cursor.lockState = CursorLockMode.Locked;

        }
        MouseAiming();
        Shoot();
    }

    void MouseAiming() {
        // get the mouse inputs
        transform.position = cart.transform.position;
        if (locked) {
            float y = Input.GetAxis("Mouse X") * turnSpeed;
            rotX += Input.GetAxis("Mouse Y") * turnSpeed;

            // clamp the vertical rotation
            rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

            // rotate the camera
            transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
        }
    }

    public void Shoot() {
        if (Input.GetMouseButtonDown(1)) {
            bullet_time = true;
            Time.timeScale = 0.05f;
        }
        else if(bullet_time && Input.GetMouseButtonUp(1)) {
            bullet_time = false;
            Time.timeScale = 1.0f;
        }
        if(bullet_time && Input.GetMouseButtonUp(0)) {
            Vector3 dir = transform.forward.normalized;
            GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
            bulletInstance.GetComponent<Rigidbody>().AddForce(dir * bullet_force, ForceMode.Impulse);
        }
        if(bullet_time) {
            bullet_current = Mathf.Clamp(bullet_current - Time.deltaTime * (1.0f/0.05f), 0, bullet_max);
            if (bullet_current <= 0) {
                bullet_time = false;
                Time.timeScale = 1.0f;
            }
        }
        else {
            if(bullet_current < bullet_max) {
                bullet_current = Mathf.Clamp(bullet_current + Time.deltaTime, 0, bullet_max);
            }
        }
        bullet_meter.UpdateTime(bullet_current);
    }
}

