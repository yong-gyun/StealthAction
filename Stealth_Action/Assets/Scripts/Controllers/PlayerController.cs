using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    Animator _anim;
    Transform _firePos;
    Rigidbody _rb;
    float _rotSpeed = 30;
    float _currentTime = 0;

    public int _maxCount { get; private set; } = 4;
    public int _currentCount { get; private set; }  = 0;

    public bool IsActionable { get; set; }

    protected override void Init()
    {
        _moveSpeed = 7.5f;
        _firePos = transform.Find("FirePos");
        _currentCount = _maxCount;

        _rb = GetComponent<Rigidbody>();
        _anim = GetComponentInChildren<Animator>();

    }

    protected override void Update()
    {
        if (Managers.Sequnce.IsCinematic || !IsActionable)
            return;

        UpdateAttack();

        if(_currentCount < _maxCount)
        {
            _currentTime += Time.deltaTime;

            if(_currentTime >= 4f)
            {
                _currentTime = 0;
                _currentCount++;
            }
        }

        UpdateMove();
    }

    protected override void UpdateMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = (Vector3.right * horizontal) + (Vector3.forward * vertical);

        if (dir != Vector3.zero)
        {
            if (Physics.Raycast(transform.position + Vector3.up, dir, 2f, LayerMask.GetMask("Wall")))
            {
                _anim.SetBool("IsMove", false);
                return;
            }

            transform.position += dir.normalized * _moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), _rotSpeed * Time.deltaTime);
            _anim.SetBool("IsMove", true);
        }
        else
        {
            _rb.velocity = Vector3.zero;
            _anim.SetBool("IsMove", false);
        }
    }

    //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //Vector3 dir = mousePos - transform.position;
    //dir.y = 0;
    //float theta = Mathf.Atan2(dir.y, dir.x);
    //float degree = theta * Mathf.Rad2Deg; 
    //Quaternion qua = Quaternion.AngleAxis(degree, Vector3.up);
    //transform.rotation = qua;

    protected override void UpdateAttack()
    {
        if (_currentCount == 0)
            return;

        if(Input.GetMouseButtonDown(0))
        {
            //������ �߻�
        }
    }
}