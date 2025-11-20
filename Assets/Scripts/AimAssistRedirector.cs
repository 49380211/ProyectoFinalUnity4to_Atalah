using UnityEngine;
using System.Collections;

public class AimAssistRedirector : MonoBehaviour
{
    public RaycastingScript raycast;
    public float tiempoRequerido = 1.5f;

    float contador = 0f;
    bool apuntando = false;

    void Update()
    {
        if (!raycast.objetivoDetectado)
        {
            if (contador > 0)
            contador = 0;
            return;
        }

        contador += Time.deltaTime;
        if (apuntando) return;

        if (contador >= tiempoRequerido)
        {
            StartCoroutine(Apuntar(raycast.objetivo));
        }
    }

    IEnumerator Apuntar(Transform objetivo)
    {
        apuntando = true;

        Quaternion rotInicial = transform.rotation;

        // posición objetivo: si es HEAD, perfecto; si no tiene HEAD, levantamos un poco
        Vector3 targetPos = objetivo.position;

        if (objetivo.name != "Neck")
        {
            targetPos += new Vector3(0, 1.5f, 0); // altura de la cabeza fallback
        }

        Quaternion rotFinal = Quaternion.LookRotation(targetPos - transform.position);

        float t = 0;
        float duracion = 0.25f;

        while (t < duracion)
        {
            t += Time.deltaTime;

            transform.rotation = Quaternion.Slerp(rotInicial, rotFinal, t / duracion);

            yield return null;
        }

        apuntando = false;
        contador = 0;
    }
}
