using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tama : MonoBehaviour
{
    [SerializeField] float m_speed = 5f;
    [SerializeField] float m_life = 150;
    [SerializeField] GameObject m_effect;
    [SerializeField] Color m_color;
    [SerializeField] GameObject m_audioprefub;

    GameObject cross;
    
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        cross = GameObject.Find("crosshair");
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Transform tf = GetComponent<Transform>();
        //Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shotForward = Vector3.Scale((cross.transform.position - transform.position), new Vector3(1, 1, 0)).normalized;

        rb.velocity = shotForward * m_speed;
        Instantiate(m_audioprefub).transform.position = transform.position;





    }
    private void FixedUpdate()
    {
        i++;
        if(i >= m_life)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(m_effect,this.transform.position,this.transform.rotation);
        Destroy(this.gameObject);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
