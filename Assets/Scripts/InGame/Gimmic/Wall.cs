using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float targetXDistance = 600; // プレイヤーとの目標とするz軸距離
    [SerializeField] float targetYZDistance = 600; // プレイヤーとの目標とするz軸距離

    [SerializeField]    float targetZDistance = 600; // プレイヤーとの目標とするz軸距離
   [SerializeField] float moveSpeed = 5f; // 壁の移動速度

    void Start()
    {
        if (playerTransform != null)
        {
            // プレイヤーの位置から目標のz軸距離だけ離れた位置に壁を配置
            Vector3 newPosition = playerTransform.position + new Vector3(targetXDistance, targetYZDistance, targetZDistance);
            transform.position = newPosition;
        }
    }

    private void Update()
    {
        if (playerTransform == null) return; // プレイヤーのTransformが設定されていない場合は処理を終了

        // 壁の現在位置
        Vector3 currentPosition = transform.position;

        // プレイヤーの位置から目標のz軸距離だけ離れた位置を計算
        Vector3 targetPosition = playerTransform.position + new Vector3(targetXDistance, targetYZDistance, targetZDistance);

        // 壁の現在位置から目標位置へ移動
        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
    }
}
