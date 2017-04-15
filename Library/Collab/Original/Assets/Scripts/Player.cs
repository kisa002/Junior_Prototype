using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float upDownRange = 90;
    public float jumpSpeed = 5;
    public float downSpeed = 5;

    private Vector3 speed;

    private float forwardSpeed;
    private float sideSpeed;
    private float rotLeftRight;
    private float rotUpDown;
    private float verticalRotation = 0f;
    private float verticalVelocity = 0f;

    public int fullMagzine = 150;
	public int remainingMagazine = 30;

    private CharacterController cc;
    
    void Start()
    {
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        FPMove();
        FPRotate();
        PlayerShoot();
    }
    
    void FPMove()
    {
        forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
        speed = transform.rotation * speed;

        cc.Move(speed * Time.deltaTime);
    }
    
    void FPRotate()
    {
        rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0f, rotLeftRight, 0f);
        
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
    void PlayerShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (remainingMagazine > 0)
            {
                Attack();
            }
            else if (fullMagzine <= 0)
            {
                Debug.Log("탄창부족");
            }
            else
            {
                Debug.Log("장전필요");
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Reload()
    {
        fullMagzine -= 30;
        remainingMagazine = 30;
    }

    void Attack()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        EnemyScript ES = null;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Enemy")
            {
                GameObject hitObject = hit.transform.gameObject;

                Debug.DrawRay(Camera.main.transform.position, Input.mousePosition, Color.red);

                ES = hitObject.GetComponent<EnemyScript>();

                ES.hp--;

                Debug.Log("남은 적 체력 : " + ES.hp);
            }
        }

        remainingMagazine--;
        Debug.Log("잔여 탄창수 : " + remainingMagazine + " 전체 탄창수 : " + fullMagzine);
    }

}
