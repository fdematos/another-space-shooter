using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plasma : MonoBehaviour
{

    public float speed = 10f;
    public float aliveTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
      Invoke("DeactivateGameObject", aliveTime);
    }

    // Update is called once per frame
    void Update()
    {
      Vector2 position = transform.position;
      position.y += Time.deltaTime * speed;

      transform.position = position;
    }

    void OnTriggerEnter2D(Collider2D target) {
      DeactivateGameObject();
    }

    void DeactivateGameObject() {
      gameObject.SetActive(false);
    }
}
