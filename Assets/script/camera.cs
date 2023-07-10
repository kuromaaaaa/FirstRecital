using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{

    GameObject player;

    Transform m_tf;

    // Start is called before the first frame update
    void Start()
    {
        m_tf = GetComponent<Transform>();

        player = GameObject.Find("ÉvÉåÉCÉÑÅ[");

    }

    // Update is called once per frame
    void Update()
    {

            m_tf.position = new Vector3(player.transform.position.x, 0 , m_tf.localPosition.z);


    }
}
