using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float fuerzaDisparo = 20f;
    public ParticleSystem muzzleFlash;
    public AudioSource gunShot;
    private int shots = 0;
    private int maxShots = 3;
    private bool canShoot = true;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);

        Rigidbody rb = bala.GetComponent<Rigidbody>();

        rb.AddForce(puntoDisparo.forward * fuerzaDisparo, ForceMode.Impulse);

        muzzleFlash.Play();
        gunShot.Play();

    }
}
