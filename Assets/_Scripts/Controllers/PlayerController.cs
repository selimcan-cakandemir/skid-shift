using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static GameManager;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed, _turnSpeed, _gravityMultiplier;
    [SerializeField] private Rigidbody _rb;

    [SerializeField] TrailRenderer _trailRenderer;
    [SerializeField] BoxCollider _boxcollider;
    
    private bool _flag = false;

    [SerializeField] private Vector3 scaleOne;
    [SerializeField] private Vector3 scaleTwo;

    private bool _isScaleOne = true;

    void Update()
    {
        
        // Turn is an input so I call it in Update
        
        Turn();

        ShiftScale();

        // Checks to see if player has fallen 

        if (transform.position.y < -5 && _flag == false) GameManager.Instance.UpdateGameState(GameState.OutOfBound);
    }


    void FixedUpdate()
    {

        // Physics operations like accelearation and applied gravity are called in FixedUpdate

        Accelerate();

        Fall();

        if (IsGrounded()) _trailRenderer.emitting = true;
        else _trailRenderer.emitting = false;
    }

    void Accelerate()
    {
        if (IsGrounded())
        {
            Vector3 forceToAdd = transform.forward;
            forceToAdd.y = 0;
            _rb.AddForce(forceToAdd * _speed * 10);
        }
    }

    public Transform localTrans;

    void Turn()
    {
        // Clamping rotation

        //Vector3 playerEulerAngles = localTrans.rotation.eulerAngles;
        //playerEulerAngles.y = Mathf.Clamp(playerEulerAngles.y, -90f, 90f);
        //localTrans.rotation = Quaternion.Euler(playerEulerAngles);

        if (Input.GetKeyDown(KeyCode.A) && IsGrounded()){transform.Rotate(0, -90, 0);}
        if (Input.GetKeyDown(KeyCode.D) && IsGrounded()){transform.Rotate(0, 90, 0);}   
    }

    void ShiftScale()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if(_isScaleOne) { StartCoroutine(ScaleEnumerator(scaleTwo, .2f)); }
            if (!_isScaleOne) { StartCoroutine(ScaleEnumerator(scaleOne, .2f));  }
        }     
    }

    IEnumerator ScaleEnumerator(Vector3 endValue, float duration)
    {
        float time = 0;
        Vector3 startScale = transform.localScale;
        while (time < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        if (_isScaleOne == false) _isScaleOne = true;
        else _isScaleOne = false;
    }


    void Fall()
    {
        _rb.AddForce(Vector3.down * _gravityMultiplier * 10);
    }

    bool IsGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(_boxcollider.bounds.center, Vector3.down, out hit, _boxcollider.bounds.extents.y + .1f))
        {
            Debug.DrawRay(_boxcollider.bounds.center, Vector3.down * (_boxcollider.bounds.extents.y + .1f), Color.green);
            return true;
        }
        else
        {
            Debug.DrawRay(_boxcollider.bounds.center, Vector3.down * (_boxcollider.bounds.extents.y + .1f), Color.red);
            return false;
        }
    }
}