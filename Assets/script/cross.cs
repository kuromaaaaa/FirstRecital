using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class cross : MonoBehaviour
{
    [SerializeField] bool mouseCursor = true;
    bool controller = true;

    [SerializeField] bool _godMode;
    GameObject _auto = default;

    GameObject _player;
    List<GameObject> _enemys = new List<GameObject>();
    public List<GameObject> Enemy
    {
        get { return _enemys; }
        set { _enemys = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = mouseCursor;
        _player = GameObject.Find("ƒvƒŒƒCƒ„[");
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_enemys.Count);
        _auto = _enemys.OrderBy(x => Vector2.Distance(_player.transform.position, x.transform.position)).FirstOrDefault();
        if (_godMode)
        {
            this.transform.position = _auto.transform.position;
            this.transform.position = new Vector3(transform.position.x,transform.position.y,0);
            return;
        }
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
            this.transform.position = new Vector3(Input.GetAxisRaw("RHorizontal") *3 +_player.transform.position.x , -Input.GetAxisRaw("RVertical") *3 +_player.transform.position.y ,0);
        }
    }
}
