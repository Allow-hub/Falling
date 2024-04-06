using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject redPlayer,bluePlayer, yellowPlayer, greenPlayer;
   // [SerializeField] GameObject wall, frame, cameraObj;
    // �~�^������
    [SerializeField] private float period = 2;
    [SerializeField] float count=0.7f;
    [SerializeField] string mainTag = "MainPlayer";
    [SerializeField] string subTag = "SubPlayer";
    public float startTime;
    public Vector3 move { get; private set; }
    [SerializeField] float speed;
    float time;
    private GameObject[] colorGimmic;
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
        if(Input.GetKeyDown(KeyCode.R))
        {
            FadeManager.FadeOut(0);
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
        SetTag(mainTag, redPlayer);
        SetTag(subTag, bluePlayer);
        SetTag(subTag, greenPlayer);
        SetTag(subTag, yellowPlayer);

    }
    private void RotationMove(GameObject target)
    {
        
        time += Time.deltaTime;

        //redPlayer.transform.RotateAround(target.transform.position, Vector3.forward, 360 / period * Time.deltaTime);
        if (time < count + count)
        {

            bluePlayer.transform.RotateAround(target.transform.position, Vector3.forward, 360 / period * Time.deltaTime);
            if (time > count)
                yellowPlayer.transform.RotateAround(target.transform.position, Vector3.forward, 360 / period * Time.deltaTime);

        }
        if (time > count + count)
        {
            if (type == MAINPLAYER_TYPE.RED)
            {
                bluePlayer.transform.RotateAround(target.transform.position, Vector3.forward, 360 / period * Time.deltaTime);
                yellowPlayer.transform.RotateAround(target.transform.position, Vector3.forward, 360 / period * Time.deltaTime);
                greenPlayer.transform.RotateAround(target.transform.position, Vector3.forward, 360 / period * Time.deltaTime);
            }
            else if (type == MAINPLAYER_TYPE.BLUE)
            {
                redPlayer.transform.RotateAround(target.transform.position, Vector3.forward, 360 / period * Time.deltaTime);
                yellowPlayer.transform.RotateAround(target.transform.position, Vector3.forward, 360 / period * Time.deltaTime);
                greenPlayer.transform.RotateAround(target.transform.position, Vector3.forward, 360 / period * Time.deltaTime);
            }
            else if (type == MAINPLAYER_TYPE.GREEN)
            {
                redPlayer.transform.RotateAround(target.transform.position, Vector3.forward, 360 / period * Time.deltaTime);
                bluePlayer.transform.RotateAround(target.transform.position, Vector3.forward, 360 / period * Time.deltaTime);
                yellowPlayer.transform.RotateAround(target.transform.position, Vector3.forward, 360 / period * Time.deltaTime);
            }
            else if (type == MAINPLAYER_TYPE.YELLOW)
            {
                redPlayer.transform.RotateAround(target.transform.position, Vector3.forward, 360 / period * Time.deltaTime);
                bluePlayer.transform.RotateAround(target.transform.position, Vector3.forward, 360 / period * Time.deltaTime);
                greenPlayer.transform.RotateAround(target.transform.position, Vector3.forward, 360 / period * Time.deltaTime);
            }
        }
        
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
            colorGimmic = GameObject.FindGameObjectsWithTag("ColorGimmic");

            foreach (var c in colorGimmic)
            {
                ColorBlock colorBlock = c.GetComponent<ColorBlock>();
                colorBlock.DistanceEvent();
            }
            //���S���ԂȂ�Ɠ���ւ�
            if (type == MAINPLAYER_TYPE.RED)
            {
                // �Ԃ��v���C���[����v���C���[�̈ʒu�Ɉړ�������
                StartCoroutine(MovePlayer(redPlayer.transform, bluePlayer.transform.position, moveTime));

                // ���v���C���[�𒆐S�ɖ߂�
                StartCoroutine(MovePlayer(bluePlayer.transform, gameObject.transform.position, moveTime));
                type = MAINPLAYER_TYPE.BLUE;
                SetTag(mainTag, bluePlayer);
                SetTag(subTag, redPlayer);
            }
            else if(type == MAINPLAYER_TYPE.BLUE)
            {
                // ���v���C���[��΃v���C���[�̈ʒu�Ɉړ�������
                StartCoroutine(MovePlayer(bluePlayer.transform, greenPlayer.transform.position, moveTime));

                // �΃v���C���[�𒆐S�ɖ߂�
                StartCoroutine(MovePlayer(greenPlayer.transform, gameObject.transform.position, moveTime));
                type=MAINPLAYER_TYPE.GREEN;
                SetTag(mainTag, greenPlayer);
                SetTag(subTag, bluePlayer);
            }
            else if (type == MAINPLAYER_TYPE.GREEN)
            {
                // ���v���C���[��΃v���C���[�̈ʒu�Ɉړ�������
                StartCoroutine(MovePlayer(greenPlayer.transform, yellowPlayer.transform.position, moveTime));

                // �΃v���C���[�𒆐S�ɖ߂�
                StartCoroutine(MovePlayer(yellowPlayer.transform, gameObject.transform.position, moveTime));
                type = MAINPLAYER_TYPE.YELLOW;
                SetTag(mainTag, yellowPlayer);
                SetTag(subTag, greenPlayer);
            }
            else if (type == MAINPLAYER_TYPE.YELLOW)
            {
                // ���v���C���[��΃v���C���[�̈ʒu�Ɉړ�������
                StartCoroutine(MovePlayer(yellowPlayer.transform, redPlayer.transform.position, moveTime));

                // �΃v���C���[�𒆐S�ɖ߂�
                StartCoroutine(MovePlayer(redPlayer.transform, gameObject.transform.position, moveTime));
                type = MAINPLAYER_TYPE.RED;
                SetTag(mainTag, redPlayer);
                SetTag(subTag, yellowPlayer);
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
        move=new Vector3(0,-speed,0);
        rb.velocity = move;
    }
    // �Q�[���I�u�W�F�N�g�̃^�O��ύX����
    public void SetTag(string newTag,GameObject obj)
    {
        obj.tag = newTag;
    }
}
