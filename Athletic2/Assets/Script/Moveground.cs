using UnityEngine;

public class Moveground : MonoBehaviour
{
    private Vector3 startPosition; // 床の初期位置
    public Vector3 offset = new Vector3(-3, 0, 0); // 動かす範囲を指定
    public float speed = 2.0f; // 動くスピード
    private bool movingToB = true; // B方向に移動中かどうか

    void Start()
    {
        // 床の初期位置を保存
        startPosition = transform.position;
    }

    void Update()
    {
        // 動くターゲット位置を計算
        Vector3 targetPosition = movingToB ? startPosition + offset : startPosition;

        // 現在の位置をターゲット位置に向かって移動
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // ターゲット位置に到達したら方向を切り替える
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            movingToB = !movingToB;
        }
    }
}
