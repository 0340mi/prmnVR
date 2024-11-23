using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerCon : MonoBehaviour
{
    public float speed = 20; // 動く速さ
    public Text goalText;

    private bool isJumping;

    private Vector3 initialPosition;
    private Vector3 currentPosition;
    private Vector3 initialRot;
    private int score;

    private Rigidbody rb; // Rididbody

    void Start()
    {
        // Rigidbody を取得
        rb = GetComponent<Rigidbody>();
        isJumping = false;
        score = 0;
        SetCountText();
        goalText.text = "";

        // 初期位置（ゲームスタート時点の位置）
        initialPosition = transform.position;

        // 初期角度（ゲームスタート時点の角度）
        initialRot = transform.eulerAngles;

    }

    void Update()
    {
        // カーソルキーの入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        // カーソルキーの入力に合わせて移動方向を設定
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Ridigbody に力を与えて玉を動かす
        rb.AddForce(movement * speed);

        // 現在の位置
        currentPosition = transform.position;

        // スペースキーを押したときにジャンプ処理を実行
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.velocity = new Vector3(0, 10, 0);
            isJumping = true;
        }


        if (currentPosition.y < -10f)
        {
            // 初期位置に戻す。
            transform.position = initialPosition;

            // 初期角度に戻す。
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
        // 地面に衝突したときのみジャンプ可能にする
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