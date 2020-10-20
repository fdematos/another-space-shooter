using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public float speed = 6.0f;

    public float minX, maxX;
    public float minY, maxY;

    public float attackDelay = 0.35f;
    private float currentAttackTime;


    [SerializeField]
    private GameObject playerPlasma;

    [SerializeField]
    private Transform attackPoint;

    // Start is called before the first frame update
    void Start() {
      currentAttackTime = attackDelay;
    }

    // Update is called once per frame
    void Update()
    {
      Move();
      Attack();
    }

    void Attack() {

      attackDelay += Time.deltaTime;

      if (attackDelay > currentAttackTime && Input.GetKeyDown(KeyCode.Space)) {
          attackDelay = 0;
          Instantiate(playerPlasma, attackPoint.position, Quaternion.identity);
        }
    }


    void Move() {
      float horizontal = Input.GetAxis("Horizontal");
      float vertical = Input.GetAxis("Vertical");

      Vector2 position = transform.position;

      float newX = position.x + speed * horizontal * Time.deltaTime;
      if (newX < maxX && newX > minX) {
        position.x = newX;
      }

      float newY = position.y + speed * vertical * Time.deltaTime;
      if (newY < maxY && newY > minY) {
        position.y = newY;
      }

      transform.position = position;
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "ennemy" || target.tag == "ammo") {
          gameObject.SetActive(false);
        }
    }
}
