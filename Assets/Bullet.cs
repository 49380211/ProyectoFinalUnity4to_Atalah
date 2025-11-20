using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
      
        ZombieHealth zombie = col.collider.GetComponentInParent<ZombieHealth>();

        if (zombie != null)
            zombie.RegistrarImpacto();

        Destroy(gameObject);
    }
}
