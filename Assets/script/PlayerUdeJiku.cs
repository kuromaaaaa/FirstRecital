using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUdeJiku : MonoBehaviour
{
    //クロスヘアのオブジェクト取得
    [SerializeField] GameObject m_crosshair;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //クロスヘアに銃を向ける
        this.transform.up = m_crosshair.transform.position - transform.position;

            //this.transform.rotation = Quaternion.Euler(0, 0 ,this.transform.rotation.z);


    }
}
