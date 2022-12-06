using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform characterBody;
    public Transform characterHead;

    public Camera skyCamera;
    public Camera firstPersonCamera;

    float sensitivityX = 3.0f;
    float sensitivityY = 2.0f;

    float rotationX = 0;
    float rotationY = 0;

    float angleYmin = -90;
    float angleYmax = 90;

    float smoothRotx = 0;
    float smoothRoty = 0;

    float smoothCoefx = 0.05f;
    float smoothCoefy = 0.05f;

    public int flag = -1;
    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        transform.position = characterHead.position;
    }
    void Update()
    {



        float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitivityY;
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX;

        smoothRotx = Mathf.Lerp(smoothRotx, horizontalDelta, smoothCoefx);
        smoothRoty = Mathf.Lerp(smoothRoty, verticalDelta, smoothCoefy);

        rotationX += smoothRotx;
        rotationY += smoothRoty;

        rotationY = Mathf.Clamp(rotationY, angleYmin, angleYmax);

        characterBody.localEulerAngles = new Vector3(0, rotationX, 0);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switchCamera();
        }

    }
    //Starta sempre com -1 (significa que é camera do player)
    void switchCamera() {
        this.flag *= -1;
        if (flag == 1)
        {
            //Muda para camera de cima
            this.skyCamera.enabled = true;
        }
        if (flag == -1)
        {
            //Muda pra primeira pessoa
            this.skyCamera.enabled = false;
        }
        
    }
}
