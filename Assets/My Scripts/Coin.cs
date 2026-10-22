using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            GameManager.Instance.AddScore();

            float x = Random.Range(1, 40);
            float y = Random.Range(1, 40);
            float z = Random.Range(1, 40);

            GameObject newCoin = Instantiate(gameObject, new Vector3(x,y,z), Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
