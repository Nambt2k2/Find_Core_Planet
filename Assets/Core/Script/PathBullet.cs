using UnityEngine;

public class Bullet : MonoBehaviour {
    public Transform tf_posStart;
    public Transform tf_posTarget;
    public Rigidbody rb;

    void StartBullet() {
        Vector2 m_veloStart = ComputeInitialSpeed(tf_posStart.position, tf_posTarget.position);
        rb.velocity = m_veloStart;
    }

    Vector2 ComputeInitialSpeed(Vector2 posStart, Vector2 posTarget) {
        Vector2 velocity = Vector2.zero;
        return velocity;
    }
}