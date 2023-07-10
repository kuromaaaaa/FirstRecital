using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uniAttack : MonoBehaviour
{
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.parent.transform.position, -30 * Time.deltaTime);
        timer++;
        if(timer > 60)
        {
            Destroy(gameObject);
        }
    }
}
