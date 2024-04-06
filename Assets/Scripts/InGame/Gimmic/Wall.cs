using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float targetXDistance = 600; // �v���C���[�Ƃ̖ڕW�Ƃ���z������
    [SerializeField] float targetYZDistance = 600; // �v���C���[�Ƃ̖ڕW�Ƃ���z������

    [SerializeField]    float targetZDistance = 600; // �v���C���[�Ƃ̖ڕW�Ƃ���z������
   [SerializeField] float moveSpeed = 5f; // �ǂ̈ړ����x

    void Start()
    {
        if (playerTransform != null)
        {
            // �v���C���[�̈ʒu����ڕW��z�������������ꂽ�ʒu�ɕǂ�z�u
            Vector3 newPosition = playerTransform.position + new Vector3(targetXDistance, targetYZDistance, targetZDistance);
            transform.position = newPosition;
        }
    }

    private void Update()
    {
        if (playerTransform == null) return; // �v���C���[��Transform���ݒ肳��Ă��Ȃ��ꍇ�͏������I��

        // �ǂ̌��݈ʒu
        Vector3 currentPosition = transform.position;

        // �v���C���[�̈ʒu����ڕW��z�������������ꂽ�ʒu���v�Z
        Vector3 targetPosition = playerTransform.position + new Vector3(targetXDistance, targetYZDistance, targetZDistance);

        // �ǂ̌��݈ʒu����ڕW�ʒu�ֈړ�
        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
    }
}
