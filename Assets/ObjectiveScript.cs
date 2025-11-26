using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveScript : MonoBehaviour
{
    public TextMeshProUGUI textoVictoria;
    public float delayReinicio = 3f;

    private ZombieHealth zombieObjetivo;

    void Start()
    {
        if (textoVictoria != null)
            textoVictoria.gameObject.SetActive(false);

        ZombieHealth[] todosLosZombies = FindObjectsOfType<ZombieHealth>();

        zombieObjetivo = todosLosZombies[Random.Range(0, todosLosZombies.Length)];

        zombieObjetivo.onDeath += OnObjectiveDeath;
    }

    void OnObjectiveDeath()
    {
        if (textoVictoria != null)
        {
            textoVictoria.gameObject.SetActive(true);
            textoVictoria.text = "GANASTE\nReiniciando en " + delayReinicio.ToString("0") + "s...";
        }

        StartCoroutine(ReiniciarConDelay());
    }

    IEnumerator ReiniciarConDelay()
    {
        yield return new WaitForSeconds(delayReinicio);

        Scene escena = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escena.name);
    }
}
