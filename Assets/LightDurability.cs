using UnityEngine;

public class LightDurability : MonoBehaviour
{
    public int golpesParaRomper = 1;
    private int golpesActuales = 0;

    public Light luz; // Asigná la luz acá
    public GameObject meshRoot; // Objeto padre del mesh

    private bool rota = false;

    void Start()
    {
        Debug.Log("[LightDurability] Iniciado en: " + gameObject.name);

        if (luz == null)
            Debug.LogWarning("[LightDurability] No se asignó una luz.");

        if (meshRoot == null)
            Debug.LogWarning("[LightDurability] No se asignó un meshRoot.");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("[LightDurability] Colisión con: " + collision.gameObject.name);

        if (!collision.gameObject.CompareTag("Bullet"))
            return;

        RegistrarImpacto();
    }

    public void RegistrarImpacto()
    {
        if (rota) return;

        golpesActuales++;

        if (golpesActuales >= golpesParaRomper)
        {
            RomperLuz();
        }
    }

    void RomperLuz()
    {
        rota = true;
        Debug.Log("[LightDurability] Lámpara rota!");

        // Apaga la luz
        if (luz != null)
        {
            luz.enabled = false;
        }

        // Desactiva todos los MeshRenderer
        if (meshRoot != null)
        {
            MeshRenderer[] meshes = meshRoot.GetComponentsInChildren<MeshRenderer>();

            foreach (var m in meshes)
                m.enabled = false;
        }
    }
}
