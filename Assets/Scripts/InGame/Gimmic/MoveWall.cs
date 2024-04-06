using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Renderer targetRenderer;
    PlayerCam cam;
    [SerializeField] float power = 2f;
    [SerializeField] float limitPosX=60f;
    Rigidbody rb;
    private float inclination;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam=Camera.main.GetComponent<PlayerCam>();
    }

    private void Update()
    {
        Move();
    }
    private void Move()
    {
        //Scene上でこのオブジェクトが映っていてもtrueになるので注意
        if (targetRenderer == null || !targetRenderer.isVisible) return;

        inclination = cam.yRotation;
        inclination = inclination/10 * speed;
        rb.velocity=new Vector3(inclination, 0, 0);
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, -limitPosX, limitPosX), rb.position.y, rb.position.z);
        // Xが0の方向に弱い力を加える
        if (rb.position.x < 0)
        {
            rb.AddForce(Vector3.right * power, ForceMode.Impulse); // ここでは例として強さ2の力を加えていますが、適切な値に調整してください
        }
        else if (rb.position.x > 0)
        {
            rb.AddForce(Vector3.left * power, ForceMode.Impulse); // ここでは例として強さ2の力を加えていますが、適切な値に調整してください
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainPlayer"))
        {
            Debug.Log("ぶつかった");
        }
    }
}
