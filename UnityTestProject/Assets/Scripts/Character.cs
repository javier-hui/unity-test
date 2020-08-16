using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // saved for efficiency
    float colliderHalfWidth, colliderHalfHeight;

    // movement support
    const float MoveUnitsPerSecond = 5;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        colliderHalfWidth = collider.size.x / 2;
        colliderHalfHeight = collider.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // move based on input
        Vector3 position = transform.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0) position.x += horizontalInput * MoveUnitsPerSecond * Time.deltaTime;
        if (verticalInput != 0) position.y += verticalInput * MoveUnitsPerSecond * Time.deltaTime;

        //Vector3 position = Input.mousePosition;
        //position.z = -Camera.main.transform.position.z;
        //position = Camera.main.ScreenToWorldPoint(position);

        // move to new position
        transform.position = position;
        ClampInScreen();
    }

    void ClampInScreen() {
        // clamp position as necessary
        Vector3 position = transform.position;
        if (position.x - colliderHalfWidth < ScreenUtils.ScreenLeft) position.x = ScreenUtils.ScreenLeft + colliderHalfWidth;
        else if (position.x + colliderHalfWidth > ScreenUtils.ScreenRight) position.x = ScreenUtils.ScreenRight - colliderHalfWidth;
        if (position.y - colliderHalfHeight < ScreenUtils.ScreenBottom) position.y = ScreenUtils.ScreenBottom + colliderHalfHeight;
        else if (position.y + colliderHalfHeight > ScreenUtils.ScreenTop) position.y = ScreenUtils.ScreenTop - colliderHalfHeight;
        transform.position = position;
    }
}
