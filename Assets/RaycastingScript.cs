using UnityEngine;

public class RaycastingScript : MonoBehaviour
{
    public Transform originTR;
    public float rayLength = 20f;

    [HideInInspector] public bool objetivoDetectado = false;
    [HideInInspector] public Transform objetivo;

    private void Start()
    {
        if (originTR == null)
            originTR = transform;
    }

    private void Update()
    {
        objetivoDetectado = false;
        objetivo = null;

        RaycastHit hit;

        bool hitAlgo = Physics.Raycast(originTR.position, originTR.forward, out hit, rayLength);

        if (hitAlgo)
        {
            if (hit.collider.CompareTag("Target"))
            {
                objetivoDetectado = true;

                // Buscamos la cabeza en el zombie
                Transform head = hit.collider.transform.Find("Armature/master/Bone/body1/neck/head");

                if (head != null)
                {
                    objetivo = head;
                }
                else
                {
                    // fallback a cuerpo pero con offset de cabeza
                    objetivo = hit.collider.transform;
                }
            }
        }

    }

    private void OnDrawGizmos()
    {
        if (originTR == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(originTR.position, originTR.forward * rayLength);
    }
}
