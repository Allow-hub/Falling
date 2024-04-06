using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] float sensX;
    [SerializeField] float sensY;

    [SerializeField] Transform orientation;

    float xRotation;
    public float yRotation;
    // Start is called before the first frame update
    void Start()
    {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        if (GameManager.Instance != null)
        {
            sensX = GameManager.Instance.sensX;
            sensY = GameManager.Instance.sensY;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);

        float mouseX =Input.GetAxisRaw("Mouse X")*Time.deltaTime*sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        yRotation += mouseX;
        xRotation -= mouseY;
      //  Debug.Log(mouseX);
        //éãñÏÇÃêßå¿
        xRotation=Mathf.Clamp(xRotation, -90f, 90f);
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
       // Debug.Log(yRotation);
        transform.rotation= Quaternion.Euler(0, 0, yRotation);
        orientation.rotation = Quaternion.Euler(0, 0, yRotation);
    }
}
