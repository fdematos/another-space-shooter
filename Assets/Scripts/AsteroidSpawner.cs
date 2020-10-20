using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    public float minX = -4.5f, maxX = 4.5f;

    public float timer = 2.0f;

    public GameObject asteroidPrefab;

    public GameObject ennemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
      Invoke("Spaw", timer);
    }

    void Spaw() {
      float positionX = Random.Range(minX, maxX);
      Vector2 position = new Vector2(positionX, 6f);

      if (Random.Range(1,4) > 1) {
        Instantiate(asteroidPrefab, position, Quaternion.identity);
      } else {
        Instantiate(ennemyPrefab, position, Quaternion.identity);
      }

      Invoke("Spaw", timer);
    }
}
