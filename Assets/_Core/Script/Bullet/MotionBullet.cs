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
    /// </summary>
    /// <param name="start"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public Vector2 ComputeInitialSpeed(Vector2 origin, Vector2 target) {
        float gravity = Physics2D.gravity.magnitude; // Lấy độ lớn gia tốc trọng trường
        float distance = Mathf.Abs(target.x - origin.x); // Khoảng cách ngang
        float deltaY = target.y - origin.y; // Chênh lệch độ cao (âm nếu target thấp hơn)

        // Giả định một góc bắn hoặc tốc độ ban đầu cố định, ở đây ta chọn cách tính trực tiếp
        // Dùng phương trình quỹ đạo để tính vận tốc ban đầu
        float speedX, speedY;

        // Tính thời gian bay dựa trên khoảng cách ngang và vận tốc x (giả định vận tốc x cố định)
        // Hoặc tính toán dựa trên góc bắn tối ưu, nhưng ở đây ta đơn giản hóa
        float arbitrarySpeedX = distance / 1.0f; // Điều chỉnh hằng số này để thay đổi độ "cong" của quỹ đạo
        float time = distance / arbitrarySpeedX;

        // Tính vận tốc y ban đầu dựa trên phương trình chuyển động thẳng đứng
        speedY = (deltaY + 0.5f * gravity * time * time) / time;
        speedX = arbitrarySpeedX;

        // Chọn hướng dựa trên vị trí tương đối của target
        if (target.x < origin.x) {
            speedX = -speedX; // Hướng trái
        }

        return new Vector2(speedX, speedY);
    }

    protected override void HideBullet() {
        gameObject.SetActive(false);
    }
}