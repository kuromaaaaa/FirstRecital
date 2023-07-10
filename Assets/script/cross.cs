using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cross : MonoBehaviour
{
    [SerializeField] bool mouseCursor = true;
    bool controller = true;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = mouseCursor;
        player = GameObject.Find("ÉvÉåÉCÉÑÅ[");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("start"))
        {
            controller = true;
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            controller = false;
        }
        if (controller == false)
        {
            Vector3 mousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosi.z = 0;
            this.transform.position = mousePosi;
        }
        if(controller == true)
        {
            this.transform.position = new Vector3(Input.GetAxisRaw("RHorizontal") *3 +player.transform.position.x , -Input.GetAxisRaw("RVertical") *3 +player.transform.position.y ,0);
        }
    }
}
