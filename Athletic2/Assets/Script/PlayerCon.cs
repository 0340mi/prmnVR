using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerCon : MonoBehaviour
{
    public float speed = 20; // ��������
    public Text goalText;

    private bool isJumping;

    private Vector3 initialPosition;
    private Vector3 currentPosition;
    private Vector3 initialRot;
    private int score;

    private Rigidbody rb; // Rididbody

    void Start()
    {
        // Rigidbody ���擾
        rb = GetComponent<Rigidbody>();
        isJumping = false;
        score = 0;
        SetCountText();
        goalText.text = "";

        // �����ʒu�i�Q�[���X�^�[�g���_�̈ʒu�j
        initialPosition = transform.position;

        // �����p�x�i�Q�[���X�^�[�g���_�̊p�x�j
        initialRot = transform.eulerAngles;

    }

    void Update()
    {
        // �J�[�\���L�[�̓��͂��擾
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        // �J�[�\���L�[�̓��͂ɍ��킹�Ĉړ�������ݒ�
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Ridigbody �ɗ͂�^���ċʂ𓮂���
        rb.AddForce(movement * speed);

        // ���݂̈ʒu
        currentPosition = transform.position;

        // �X�y�[�X�L�[���������Ƃ��ɃW�����v���������s
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.velocity = new Vector3(0, 10, 0);
            isJumping = true;
        }


        if (currentPosition.y < -10f)
        {
            // �����ʒu�ɖ߂��B
            transform.position = initialPosition;

            // �����p�x�ɖ߂��B
            transform.eulerAngles = initialRot;

            score = 0;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up")){
            other.gameObject.SetActive(false);
            score = 1;
            SetCountText();
        }
    }
    void OnCollisionEnter(Collision col)
    {
        // �n�ʂɏՓ˂����Ƃ��̂݃W�����v�\�ɂ���
        if (col.gameObject.CompareTag("ground"))
        {
            isJumping = false;
        }
    }
    void SetCountText()
    {
        if (0 < score)
        {
            goalText.text = "G o a l !!";
        }
        currentPosition = transform.position;
    }

    }