using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject bluePlayer, yellowPlayer, greenPlayer;
    // �~�^������
    [SerializeField] private float period = 2;
    [SerializeField] float count=0;
    [SerializeField] float startTime;
    float time;
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        RotationMove(gameObject);
        if (CanMove())
            ChangeMainPlayer();
    }
    private void Init()
    {
        // ���S�_�̈ʒu
        Vector3 center = transform.position;

        // �~�^���̔��a
        float radius = 20f;

        // �e�I�u�W�F�N�g�̔z�u
        bluePlayer.transform.position = center + new Vector3(radius, 0f, 0f);
        yellowPlayer.transform.position = center + new Vector3(radius, 0f, 0f);
        greenPlayer.transform.position = center + new Vector3(radius, 0f, 0f);

    }
    private void RotationMove(GameObject target)
    {
        
        time += Time.deltaTime;
        
        bluePlayer.transform.RotateAround(target.transform.position, Vector3.forward, 360/period * Time.deltaTime);
        if(time > count)
            yellowPlayer.transform.RotateAround(target.transform.position, Vector3.forward, 360 / period * Time.deltaTime);
        if (time > count+count)
            greenPlayer.transform.RotateAround(target.transform.position, Vector3.forward, 360 / period * Time.deltaTime);
    }
    private bool CanMove()
    {
        return time > startTime;
    }
    private void ChangeMainPlayer()
    {
        Debug.Log("start");
    }
}
