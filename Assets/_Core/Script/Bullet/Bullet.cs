using UnityEngine;

public abstract class Bullet : MonoBehaviour {
    [SerializeField] protected E_TypePathBullet typePathBullet;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            FireBullet();
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("HideBullet")) {
            HideBullet();
        }
    }

    protected abstract void FireBullet();
    protected abstract void HideBullet();
}

public enum E_TypePathBullet {
    None,
    Motion,
}