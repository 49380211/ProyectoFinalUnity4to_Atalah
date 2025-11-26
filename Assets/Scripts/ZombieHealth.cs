using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int golpesParaMorir = 3;
    private int golpesActuales = 0;

    public Rigidbody rbZombie;
    public Rigidbody silla;

    public bool usarFuerzaAlMorir = true;
    public float fuerzaZombie = 5f;
    public Vector3 direccionZombie = new Vector3(0, 1, -1);

    public bool sillaUsaFuerza = false;
    public float fuerzaSilla = 3f;
    public Vector3 direccionSilla = new Vector3(0, 1, -1);

    private bool muerto = false;
    public bool estaMuerto { get { return muerto; } }

    public System.Action onDeath;

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

        onDeath?.Invoke();

        if (rbZombie != null)
        {
            rbZombie.isKinematic = false;

            Vector3 dirGlobal = transform.TransformDirection(direccionZombie.normalized);
            rbZombie.AddForce(dirGlobal * fuerzaZombie, ForceMode.Impulse);
        }

        if (silla != null)
        {
            silla.isKinematic = false;

            if (sillaUsaFuerza)
            {
                Vector3 dirSillaGlobal = transform.TransformDirection(direccionSilla.normalized);
                silla.AddForce(dirSillaGlobal * fuerzaSilla, ForceMode.Impulse);
            }
        }
    }
}
