using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] float minX, maxX, minY, maxY, followspeed;
    [SerializeField] Transform target;
    void FixedUpdate()
    {
        if(!target) return;
        transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(target.position.x, minX, maxX),
        Mathf.Clamp(target.position.y, minY, maxY), -10), followspeed * Time.deltaTime);
    }
}
