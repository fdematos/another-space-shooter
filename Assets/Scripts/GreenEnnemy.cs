using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnnemy : MonoBehaviour
{
    // Start is called before the first frame update

    private bool canMove = true;

    private float speed = 2f;

    private Animator animator;
    private float attackDelay = 2.0f;
    private float currentAttackTime;

    private AudioSource explodeAudioSource;

    [SerializeField]
    private GameObject ennemyBullet;

     [SerializeField]
    private Transform attackPoint;

    void Start(){
        explodeAudioSource =  GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        currentAttackTime = attackDelay;
    }

    // Update is called once per frame
    void Update(){
        Move();
        Attack();
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

    void Attack() {
       attackDelay += Time.deltaTime;

      if (attackDelay > currentAttackTime && canMove) {
          attackDelay = 0;
          Instantiate(ennemyBullet, attackPoint.position, Quaternion.Euler(new Vector3(0, 0, 180)));
        }
    }

    void OnTriggerEnter2D(Collider2D target) {
        if ( canMove && (target.tag == "ammo" || target.tag == "Player")) {
          canMove = false;
          animator.Play("EnnemyExplode");
          explodeAudioSource.Play();
          Invoke("Deactivate", 0.8f);
          GameController.instance.AddToScore(200);
        }
    }

    void Deactivate() {
       gameObject.SetActive(false);
    }
}
