using UnityEngine;

public class LampHealth : MonoBehaviour
{
    public int golpesParaRomperse = 1;
    private int golpesActuales = 0;

    public Rigidbody rb;
    public Light lampara;

    public float fuerzaRotura = 2f;
    public Vector3 direccionFuerza = new Vector3(0, 0, -1);

    private bool rota = false;

    public void RegistrarImpacto()
    {
        if (rota)
            return;

        golpesActuales++;

        if (golpesActuales >= golpesParaRomperse)
            Romper();
    }

    void Romper()
    {
        rota = true;

        // Apagar luz si existe
        if (lampara != null)
            lampara.enabled = false;

        // Activar físicas
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.AddForce(direccionFuerza.normalized * fuerzaRotura, ForceMode.Impulse);
        }
    }
}
