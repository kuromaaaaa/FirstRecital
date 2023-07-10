using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyGrand : EnemySuperClass
{
    [SerializeField] float _speed = 0.1f;
    [SerializeField] float _moveDistance = 10;
    [SerializeField] float _attackDistance = 5;
    [SerializeField] GameObject _attackPrefub;

    bool _move = false;
    float m_timer = 1;
    GameObject _player;
    bool attack = false;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("�v���C���[");
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�Ƃ̋���
        float _distance = this.transform.position.x - _player.transform.position.x;
        if (_distance < _moveDistance)
        {
            _move = true;
        }
        if (this.transform.position.x - _player.transform.position.x < _attackDistance)
        {
            attack = true;
        }
    }
    private void FixedUpdate()
    {
        if (attack == false && _move == true)
        {
            this.transform.Translate(-_speed, 0, 0);
        }


        if(attack)
        {
            m_timer++;
            if(m_timer == 50)
            {
                if(_attackPrefub)
                {
                    var hLef = new Vector2(transform.position.x - 0.1f, transform.position.y);
                    GameObject uniH1 = Instantiate(_attackPrefub, hLef, this.transform.rotation);
                    uniH1.transform.parent = transform;
                    var hRig = new Vector2(transform.position.x + 0.1f, transform.position.y);
                    GameObject uniH2 = Instantiate(_attackPrefub, hRig, this.transform.rotation);
                    uniH2.transform.parent = transform;
                }

                //Debug.Log("�U��");
                m_timer = 0;
            }
        }
    }
    public override void Damage()
    {
        //�v���C���[����U�����󂯂������̃I�u�W�F�N�g��j�󂷂�
        Destroy(this.gameObject);
    }
}
