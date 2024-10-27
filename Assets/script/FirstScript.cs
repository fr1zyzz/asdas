using System.Collections;
using UnityEngine;

public class FirstScript : MonoBehaviour
{ 
  [SerializeField] float speed, speedRotation, timeBtwShoot;
  [SerializeField] GameObject bullet;
  [SerializeField] Transform bulletpos;
  Rigidbody2D rb;
  SpriteRenderer spR;
  float timerShoot;
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    spR = GetComponent<SpriteRenderer>();
  }

  void Update()
  {
    timerShoot += Time.deltaTime;
    if(Input.GetMouseButtonDown(0) && timerShoot > timeBtwShoot){
      Instantiate(bullet, bulletpos.position, bulletpos.rotation);
      timerShoot = 0;
    }
    if(Input.GetKeyDown(KeyCode.Space)){
      StartCoroutine(fade());
    }
    rotation();
  } 
  private void FixedUpdate()
  {
    move();
  }
  void move()
  {
    Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
    rb.MovePosition(rb.position + move * Time.fixedDeltaTime);
  }
  void rotation(){
    Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    Quaternion rotate = Quaternion.AngleAxis(angle, Vector3.forward);
    transform.rotation = Quaternion.Slerp(transform.rotation, rotate, speedRotation * Time.deltaTime);
  }
  IEnumerator fade(){
    if(spR.color.a > 0.9f){
      for(float i = 1; i >= 0; i -= Time.deltaTime){
        spR.color = new Color(0, 0, 1, i);
        yield return null;
      }
    } else if(spR.color.a < 0.1f){
      for(float i = 0; i <= 1; i += Time.deltaTime){
        spR.color = new Color(0, 0, 1, i);
        yield return null;
      }
    }
  }
}