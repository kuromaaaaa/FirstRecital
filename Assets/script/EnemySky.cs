using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemySky : EnemySuperClass
{
    [SerializeField] Sprite image2;
    [SerializeField] Sprite image1;
    [SerializeField] float _nextSprite = 25;
    float _speed = 1;
    [SerializeField] float _helth = 2;
    [SerializeField] float _moveDistance = 15;
    float timer = 1;
    
    bool ue = true;
    bool _move = false;

    SpriteRenderer sp;
    Rigidbody2D rb;
    GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("プレイヤー");

    }

    // Update is called once per frame
    private void Update()
    {
        //プレイヤーとの距離
        float _distance = this.transform.position.x - _player.transform.position.x;
        if (_distance < _moveDistance)
        {
            _move = true;
        }
    }
    private void FixedUpdate()
    {
        timer++;

        //羽ばたき
        if (ue && timer == _nextSprite)
        {
            sp.sprite = image2;
            timer = 0;
            ue = false;
        }
        if (ue ==false && timer ==_nextSprite) 
        {
            sp.sprite=image1;
            timer = 0;
            ue = true;
        }

        if (_move)
        {
            this.rb.AddForce(_player.transform.position - this.transform.position * _speed);
        }
        //画像の反転
        if (_player.transform.position.x - this.transform.position.x > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            this.GetComponent <SpriteRenderer>().flipX = false;
        }

        //体力が0になったらこのオブジェクトを破壊する
        if(_helth == 0)
        {
            Destroy(this.gameObject);
        }
    }



    public override void Damage()
    {
        //プレイヤーから攻撃を受けた時体力を1下げる
        _helth--;
    }

}
