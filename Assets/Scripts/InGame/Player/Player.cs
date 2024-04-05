using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject redPlayer,bluePlayer, yellowPlayer, greenPlayer;
   // [SerializeField] GameObject wall, frame, cameraObj;
    // 円運動周期
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
        // 中心点の位置
        Vector3 center = transform.position;

        // 円運動の半径
        float radius = 20f;

        // 各オブジェクトの配置
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
            float moveTime = 0.025f; // 移動にかける時間

            //中心が赤なら青と入れ替え
            if(type == MAINPLAYER_TYPE.RED)
            {
                // 赤いプレイヤーを青いプレイヤーの位置に移動させる
                StartCoroutine(MovePlayer(redPlayer.transform, bluePlayer.transform.position, moveTime));

                // 青いプレイヤーを中心に戻す
                StartCoroutine(MovePlayer(bluePlayer.transform, gameObject.transform.position, moveTime));
                type = MAINPLAYER_TYPE.BLUE;
            }else if(type == MAINPLAYER_TYPE.BLUE)
            {
                // 青いプレイヤーを緑プレイヤーの位置に移動させる
                StartCoroutine(MovePlayer(bluePlayer.transform, greenPlayer.transform.position, moveTime));

                // 緑プレイヤーを中心に戻す
                StartCoroutine(MovePlayer(greenPlayer.transform, gameObject.transform.position, moveTime));
                type=MAINPLAYER_TYPE.GREEN;
            }
            else if (type == MAINPLAYER_TYPE.GREEN)
            {
                // 青いプレイヤーを緑プレイヤーの位置に移動させる
                StartCoroutine(MovePlayer(greenPlayer.transform, yellowPlayer.transform.position, moveTime));

                // 緑プレイヤーを中心に戻す
                StartCoroutine(MovePlayer(yellowPlayer.transform, gameObject.transform.position, moveTime));
                type = MAINPLAYER_TYPE.YELLOW;
            }
            else if (type == MAINPLAYER_TYPE.YELLOW)
            {
                // 青いプレイヤーを緑プレイヤーの位置に移動させる
                StartCoroutine(MovePlayer(yellowPlayer.transform, redPlayer.transform.position, moveTime));

                // 緑プレイヤーを中心に戻す
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
