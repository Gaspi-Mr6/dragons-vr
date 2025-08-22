using UnityEngine;
using UnityEngine.Pool;

public class FireballThrower : MonoBehaviour
{
    
    private IObjectPool<Fireball> fireballPool;
    public Fireball fireballPrefab;
    public Transform rightHandTransform;
    public Transform leftHandTransform;

    private void Awake()
    {
        fireballPool = new ObjectPool<Fireball>(
            CreateFireball,
            OnGetFromPool,
            OnReleaseToPool,
            OnDestroyPoolObject,
            collectionCheck: false,
            defaultCapacity: 6,
            maxSize: 10
        );
    }

    public void Fire(bool rightHand)
    {
        Fireball fireball = fireballPool.Get();
        Transform hand = (rightHand) ? rightHandTransform : leftHandTransform;
        fireball.Launch(hand.position, hand.forward);
    }

    Fireball CreateFireball()
    {
        Fireball fireball = Instantiate(fireballPrefab);
        fireball.SetPool(fireballPool);
        return fireball;
    }

    void OnGetFromPool(Fireball fireball)
    {
        fireball.gameObject.SetActive(true);
    }

    void OnReleaseToPool(Fireball fireball)
    {
        fireball.gameObject.SetActive(false);
    }

    void OnDestroyPoolObject(Fireball fireball)
    {
        Destroy(fireball.gameObject);
    }
}
