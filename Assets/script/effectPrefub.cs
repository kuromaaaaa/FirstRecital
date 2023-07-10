using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectPrefub : MonoBehaviour
{

    [SerializeField] GameObject m_effectPrefab = default;
    [SerializeField] float beens = 4;

    void Start()
    {


        for (int i = 1; i <= beens; i++)
        {
            float ranX = Random.Range(0, 10);
            float ranY = Random.Range(0, 5);
            ranX -= 5;
            ranX *= 0.1f; ranY *= 0.1f;
            var VecX = transform.position.x + ranX;
            var VecY = transform.position.y + ranY;
            if (m_effectPrefab)
            {
                var p = new Vector2(VecX, VecY);
                GameObject been = Instantiate(m_effectPrefab, p, this.transform.rotation);
                been.transform.parent = transform;
            }
        }
        Destroy(this.gameObject, 1);
    }

}
