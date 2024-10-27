using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] float speed, timeDeath;
    void Start()
    {
        Invoke(nameof(Death), timeDeath);
    }


    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    void Death(){
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Wall"){
            Death();
        }
    }
}
