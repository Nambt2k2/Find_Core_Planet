using UnityEngine;

public sealed class MotionBullet : Bullet {
    [SerializeField][RequireReference] Transform tf_start;
    [SerializeField][RequireReference] Transform tf_target;
    [SerializeField][RequireReference] Rigidbody2D rb;

    void OnValidate() {
        typePathBullet = E_TypePathBullet.Motion;
    }

    protected override void FireBullet() {
        rb.simulated = true;
        rb.velocity = Vector2.zero;
        gameObject.SetActive(true);
        transform.position = tf_start.position;
        rb.velocity = ComputeInitialSpeed(tf_start.position, tf_target.position);
    }

    /// <summary>
    /// Hàm tính vận tốc ban đầu của chuyển động ném xiên
    /// Từ start tới target với góc ném tối ưu đạt tầm xa lớn nhất 45 deg
    /// </summary>
    /// <param name="start"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    Vector2 ComputeInitialSpeed(Vector2 start, Vector2 target) {
        float gravity = Physics2D.gravity.magnitude;
        float distance = Mathf.Abs(target.x - start.x);
        //maxHeight = (v₀² * sin²θ) / (2g)
        //distance = (v₀² * sin2θ) / g
        //maxHeight / distance = 1 / 4 * tanθ
        //Khi θ = 45°: tỷ lệ maxHeight / distance = 1/4.
        float maxHeight = distance / 4;
        //khi start thế năng bằng 0, khi đạt độ cao tối đa vận tốc = 0
        float startSpeedY = Mathf.Sqrt(2 * gravity * maxHeight);
        float time = (startSpeedY + Mathf.Sqrt(startSpeedY * startSpeedY - 2 * gravity * (target.y - start.y))) / gravity;
        float startSpeedX = distance / time;
        //chọn hướng
        if (target.x - start.x > 0) {
            //hướng phải
            return new Vector2(startSpeedX, startSpeedY);
        } else {
            //hướng trái
            return new Vector2(-startSpeedX, startSpeedY);
        }
    }

    protected override void HideBullet() {
        gameObject.SetActive(false);
    }
}