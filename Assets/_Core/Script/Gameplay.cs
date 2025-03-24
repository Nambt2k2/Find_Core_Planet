using UnityEngine;

public class Gameplay : MonoBehaviour {
    [SerializeField][RequireReference] Bullet[] arr_bullet;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) 
            for (int i = 0; i < arr_bullet.Length; i++)
                arr_bullet[i].FireBullet();
    }

    void FixedUpdate() {
        for (int i = 0; i < arr_bullet.Length; i++)
            arr_bullet[i].Move();
    }
}
