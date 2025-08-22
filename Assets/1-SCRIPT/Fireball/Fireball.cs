using UnityEngine;
using UnityEngine.Pool;

public class Fireball : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public float speed = 10f;

    private IObjectPool<Fireball> pool;
    private void Start()
    {
        Invoke(nameof(Release), 8);
    }

    public void Launch(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        transform.forward = direction;
        gameObject.SetActive(true);
        rb.linearVelocity = direction * speed;
    }

    public void SetPool(IObjectPool<Fireball> pool)
    {
        this.pool = pool;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Fireball collides with " + collision.collider.name);
        if (collision.collider.TryGetComponent(out DragonCollider dragonCollider))
        {

            dragonCollider.dragonCmp.TakeDamage();
        }

        Release();
    }

    void Release()
    {
        // Reset velocity & release back to pool
        rb.linearVelocity = Vector3.zero;

        // Animation / Explosion

        // Reset pool
        pool.Release(this);
    }
}
