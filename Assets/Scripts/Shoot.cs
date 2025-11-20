using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float fuerzaDisparo = 20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        // Crear bala
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);

        // Obtener Rigidbody
        Rigidbody rb = bala.GetComponent<Rigidbody>();

        // Aplicar fuerza hacia adelante
        rb.AddForce(puntoDisparo.forward * fuerzaDisparo, ForceMode.Impulse);
    }
}
