using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject redPlayer,bluePlayer, yellowPlayer, greenPlayer;
   // [SerializeField] GameObject wall, frame, cameraObj;
    // �~�^������
    [SerializeField] private float period = 2;
    [SerializeField] float count=0.7f;
    public float startTime;
    public Vector3 move { get; private set; }
    float time;

    private enum MAINPLAYER_TYPE
    {
        RED,
        BLUE,
        GREEN,
        YELLOW
    }
    private MAINPLAYER_TYPE type;
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        RotationMove(gameObject);
        if (CanMove())
        {
            Area();
            ChangeMainPlayer();

        }
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

        type = MAINPLAYER_TYPE.RED;
    }
    private void RotationMove(GameObject target)
    {
        
        time += Time.deltaTime;

        redPlayer.transform.RotateAround(target.transform.position, Vector3.forward, 360 / period * Time.deltaTime);

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
        if (Input.GetMouseButtonDown(0))
        {
            float moveTime = 0.025f; // �ړ��ɂ����鎞��

            //���S���ԂȂ�Ɠ���ւ�
            if(type == MAINPLAYER_TYPE.RED)
            {
                // �Ԃ��v���C���[����v���C���[�̈ʒu�Ɉړ�������
                StartCoroutine(MovePlayer(redPlayer.transform, bluePlayer.transform.position, moveTime));

                // ���v���C���[�𒆐S�ɖ߂�
                StartCoroutine(MovePlayer(bluePlayer.transform, gameObject.transform.position, moveTime));
                type = MAINPLAYER_TYPE.BLUE;
            }else if(type == MAINPLAYER_TYPE.BLUE)
            {
                // ���v���C���[��΃v���C���[�̈ʒu�Ɉړ�������
                StartCoroutine(MovePlayer(bluePlayer.transform, greenPlayer.transform.position, moveTime));

                // �΃v���C���[�𒆐S�ɖ߂�
                StartCoroutine(MovePlayer(greenPlayer.transform, gameObject.transform.position, moveTime));
                type=MAINPLAYER_TYPE.GREEN;
            }
            else if (type == MAINPLAYER_TYPE.GREEN)
            {
                // ���v���C���[��΃v���C���[�̈ʒu�Ɉړ�������
                StartCoroutine(MovePlayer(greenPlayer.transform, yellowPlayer.transform.position, moveTime));

                // �΃v���C���[�𒆐S�ɖ߂�
                StartCoroutine(MovePlayer(yellowPlayer.transform, gameObject.transform.position, moveTime));
                type = MAINPLAYER_TYPE.YELLOW;
            }
            else if (type == MAINPLAYER_TYPE.YELLOW)
            {
                // ���v���C���[��΃v���C���[�̈ʒu�Ɉړ�������
                StartCoroutine(MovePlayer(yellowPlayer.transform, redPlayer.transform.position, moveTime));

                // �΃v���C���[�𒆐S�ɖ߂�
                StartCoroutine(MovePlayer(redPlayer.transform, gameObject.transform.position, moveTime));
                type = MAINPLAYER_TYPE.RED;
            }
        }
    }

    private IEnumerator MovePlayer(Transform playerTransform, Vector3 targetPosition, float moveTime)
    {
        float elapsedTime = 0f;

        Vector3 startingPosition = playerTransform.position;

        while (elapsedTime < moveTime)
        {
            playerTransform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / moveTime);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        playerTransform.position = targetPosition;
    }
    private void Area()
    {
        GameObject root = transform.root.gameObject;
        Rigidbody rb = root.GetComponent<Rigidbody>();
        move=new Vector3(0,-10,0);
        rb.velocity = move;
    }
}
