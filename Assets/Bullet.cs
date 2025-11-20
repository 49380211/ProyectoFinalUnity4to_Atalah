using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
      
        ZombieHealth zombie = col.collider.GetComponentInParent<ZombieHealth>();
        LampHealth lamp = col.collider.GetComponentInParent<LampHealth>();

        if (lamp != null)
            lamp.RegistrarImpacto();


        if (zombie != null)
            zombie.RegistrarImpacto();

        Destroy(gameObject);
    }
}
