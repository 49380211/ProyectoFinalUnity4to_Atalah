using UnityEngine;

public class LightDurability : MonoBehaviour
{
    public int golpesParaRomper = 1;
    private int golpesActuales = 0;

    public Light luz; // Asigná la luz acá
    public GameObject meshRoot; // Objeto padre del mesh

    private bool rota = false;
    public ParticleSystem glassExplosion;
    public AudioSource glassBreaking; 



    private void OnCollisionEnter(Collision collision)
    {

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
        glassExplosion.Play();
        glassBreaking.Play();
    }
}
