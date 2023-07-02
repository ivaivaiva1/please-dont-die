using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim : MonoBehaviour
{

    private Rigidbody2D aimRB;

    private Vector2 mousePosition;

    public Camera sceneCamera;

    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        aimRB = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePosition - aimRB.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 180f;
        aimRB.rotation = aimAngle;
    }
}
