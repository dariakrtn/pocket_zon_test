using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float dirX, dirY;
    public float speed;
    public Joystick joystick;
    private Rigidbody2D rb;


    [SerializeField]
    float leftLimit;

    [SerializeField]
    float rightLimit;

    [SerializeField]
    float bottomLimit;

    [SerializeField]
    float upperLimit;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dirX = joystick.Horizontal * speed;
        dirY = joystick.Vertical * speed;

        transform.position = new Vector3
   (
   Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
   Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
   transform.position.z);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
    }



    private void OnDrawGizmos()
{
    Gizmos.color = Color.green;
    Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(rightLimit, upperLimit));
    Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
    Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(leftLimit, bottomLimit));
    Gizmos.DrawLine(new Vector2(rightLimit, upperLimit), new Vector2(rightLimit, bottomLimit));

}
}
