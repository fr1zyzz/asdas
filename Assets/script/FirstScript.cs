using UnityEngine;

public class FirstScript : MonoBehaviour
{ 
  [SerializeField] float speed, timeBtwShoot;
  [SerializeField] GameObject bullet;
  [SerializeField] Transform bulletpos;
  Rigidbody2D rb;
  SpriteRenderer spR;
  Animator anim;
  float timerShoot;
  float scalePlayer;
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    spR = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();
  }

  void Update()
  {
    timerShoot += Time.deltaTime;
    if(Input.GetMouseButtonDown(0) && timerShoot > timeBtwShoot){
      Instantiate(bullet, bulletpos.position, bulletpos.rotation);
      timerShoot = 0;
    }
  } 
  private void FixedUpdate()
  {
    move();
  }
  void move()
  {
    Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    if(move.x == 1) {
      scalePlayer = 1;
    } else if (move.x == -1) {
      scalePlayer = -1;
    } 

    if(move != Vector2.zero) {
      anim.SetBool("run", true);
    } else {
      anim.SetBool("run", false);
    }

    if(scalePlayer == -1) {
      spR.flipX = true;
    } else {
      spR.flipX = false;
    }

    Vector2 moveVelocity = move.normalized * speed;
    rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
  }
}