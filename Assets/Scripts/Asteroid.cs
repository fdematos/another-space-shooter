using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float speed;
    private float rotateSpeed;

    private Animator animator;
    private AudioSource explodeAudioSource;

    private bool canMove = true;
    // Start is called before the first frame update
    void Start() {
      animator = GetComponent<Animator>();
      explodeAudioSource =  GetComponent<AudioSource>();

      speed = Random.Range(2, 4);
      if (Random.Range(1, 4) > 2) {
        rotateSpeed = speed * 50;
      }  else {
        rotateSpeed = speed * -50;
      }
    }

    // Update is called once per frame
    void Update() {
      Move();
      Rotate();
    }

    void Move() {
      if (canMove == true) {
        Vector2 position = transform.position;
        position.y += -1 * speed * Time.deltaTime;
        transform.position = position;

        if (position.y < -6.0f) {
          Deactivate();
        }
      }
    }

    void Rotate() {
      transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime), Space.World);
    }

    void OnTriggerEnter2D(Collider2D target) {
        if ( canMove && (target.tag == "ammo" || target.tag == "Player")) {
          canMove = false;
          animator.Play("Explode");
          explodeAudioSource.Play();
          Invoke("Deactivate", 0.8f);
          GameController.instance.AddToScore(100);
        }
    }

    void Deactivate() {
       gameObject.SetActive(false);
    }
}
