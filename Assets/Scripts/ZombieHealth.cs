using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    [Header("Vida del zombie")]
    public int golpesParaMorir = 3;
    private int golpesActuales = 0;

    [Header("Referencias")]
    public Rigidbody rbZombie;
    public Rigidbody silla;

    [Header("Física al morir")]
    public bool usarFuerzaAlMorir = true;
    public float fuerzaZombie = 5f;
    public Vector3 direccionZombie = new Vector3(0, 1, -1);

    public bool sillaUsaFuerza = false;
    public float fuerzaSilla = 3f;
    public Vector3 direccionSilla = new Vector3(0, 1, -1);
    public ParticleSystem bloodExplosion;

    private bool muerto = false;

    public void RegistrarImpacto()
    {
        if (muerto)
            return;

        golpesActuales++;

        if (golpesActuales >= golpesParaMorir)
            Morir();
    }

    void Morir()
    {
        muerto = true;

        // --- ZOMBIE ---
        if (rbZombie != null)
        {
            rbZombie.isKinematic = false;

            // Dirección global
            Vector3 dirGlobal = transform.TransformDirection(direccionZombie.normalized);

            rbZombie.AddForce(dirGlobal * fuerzaZombie, ForceMode.Impulse);
        }
        
    bloodExplosion.Play();

        // --- SILLA ---
        if (silla != null)
        {
            silla.isKinematic = false;

            if (sillaUsaFuerza)
            {
                // Dirección global de la silla
                Vector3 dirSillaGlobal = transform.TransformDirection(direccionSilla.normalized);
                silla.AddForce(dirSillaGlobal * fuerzaSilla, ForceMode.Impulse);
            }
        }
    }

}
