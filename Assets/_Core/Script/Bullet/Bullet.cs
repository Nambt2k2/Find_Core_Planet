using UnityEngine;

public abstract class Bullet : MonoBehaviour {
    [SerializeField] protected E_TypePathBullet typePathBullet;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("HideBullet")) {
            HideBullet();
        }
    }

    public abstract void FireBullet();
    public virtual void Move() { }
    public abstract void HideBullet();
}

public enum E_TypePathBullet {
    None,
    Motion,
    Follow,
}