using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int golpesParaMorir = 3;
    private int golpesActuales = 0;

    public Rigidbody rb;

    public float fuerzaMuerte = 5f;
    public Vector3 direccionFuerza = new Vector3(0, 1, -1);

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

        if (rb == null)
            return;

        rb.isKinematic = false;
        rb.AddForce(direccionFuerza.normalized * fuerzaMuerte, ForceMode.Impulse);
    }
}
