using UnityEngine;

public class Moveground : MonoBehaviour
{
    private Vector3 startPosition; // ���̏����ʒu
    public Vector3 offset = new Vector3(-3, 0, 0); // �������͈͂��w��
    public float speed = 2.0f; // �����X�s�[�h
    private bool movingToB = true; // B�����Ɉړ������ǂ���

    void Start()
    {
        // ���̏����ʒu��ۑ�
        startPosition = transform.position;
    }

    void Update()
    {
        // �����^�[�Q�b�g�ʒu���v�Z
        Vector3 targetPosition = movingToB ? startPosition + offset : startPosition;

        // ���݂̈ʒu���^�[�Q�b�g�ʒu�Ɍ������Ĉړ�
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // �^�[�Q�b�g�ʒu�ɓ��B�����������؂�ւ���
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            movingToB = !movingToB;
        }
    }
}
