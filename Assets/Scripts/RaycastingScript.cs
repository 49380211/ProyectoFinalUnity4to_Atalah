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

                Transform neck = hit.collider.transform.Find("Armature/master/Bone/body1/neck");

                if (neck != null)
                {
                    objetivo = neck;
                }
                else
                {
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
