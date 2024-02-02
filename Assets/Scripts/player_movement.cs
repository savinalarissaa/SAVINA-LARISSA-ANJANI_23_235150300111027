using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;
    public GameObject TopRightLimit;
    public GameObject BottomLeftLimit;

    private Camera _camera;

    Vector2 movement;
    Vector2 mousePos;

    Vector3 topRightLimit;
    Vector3 bottomLeftLimit;


    private void Awake()
    {
        _camera = Camera.main;
    }

    void Start()
    {
        topRightLimit = TopRightLimit.transform.position;
        bottomLeftLimit = BottomLeftLimit.transform.position;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {

        if ((transform.position.x <= bottomLeftLimit.x && movement.x == -1) || 
            (transform.position.x >= topRightLimit.x && movement.x == 1))
        {
            movement.x = 0;
        }

        if ((transform.position.y <= bottomLeftLimit.y && movement.y == -1) ||
            (transform.position.y >= topRightLimit.y && movement.y == 1))
        {
            movement.y = 0;
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }

}
