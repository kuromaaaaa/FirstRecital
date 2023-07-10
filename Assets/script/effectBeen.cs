using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectBeen : MonoBehaviour
{
    private Transform Transform;
    //public GameObject target;

    private float scaleX;
    private float scaleY;
    [SerializeField] float inoti = 0.1f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Transform = GetComponent<Transform>();

        scaleX = Transform.localScale.x;
        scaleY = Transform.localScale.y;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scaleX -= inoti;
        scaleY -= inoti;
        transform.position = Vector2.MoveTowards(transform.position, transform.parent.transform.position, -2 * Time.deltaTime);
        Transform.localScale = new Vector2(scaleX, scaleY);
        if (scaleX <= 0)
        {
            Destroy(gameObject);
        }
    }
}
