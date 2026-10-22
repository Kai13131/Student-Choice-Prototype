using System.Collections;
using UnityEngine;

public class SonarSystem : MonoBehaviour
{
    public float sonarRange = 15f;
    public float sonarReveal = 3f;

    private bool canUseSonar = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canUseSonar)
        {
            StartCoroutine(SonarPulse());
        }
    }

    IEnumerator SonarPulse()
    {
        canUseSonar = false;

        Debug.Log("Sonar started");

        Collider[] colliders = Physics.OverlapSphere(transform.position, sonarRange);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("SonarTarget"))
            {
                Debug.Log("SonarTarget found: " + collider.name);

                Renderer[] renderers = collider.GetComponentsInChildren<Renderer>();

                foreach (Renderer rend in renderers)
                {
                    rend.enabled = true;
                }
            }
        }

        yield return new WaitForSeconds(sonarReveal);
        canUseSonar = true;
    }
}
