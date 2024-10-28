
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] float speedRotation;
    SpriteRenderer sprW;
    void Start()
    {
        sprW = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    void FixedUpdate() {
        rotation();
    }

    void rotation()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotate = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, speedRotation * Time.deltaTime);

        if (Mathf.Abs(transform.rotation.z) < 0.7f)
        {
            sprW.flipY = false;
        }
        else
        {
            sprW.flipY = true;
        }
    }
}
