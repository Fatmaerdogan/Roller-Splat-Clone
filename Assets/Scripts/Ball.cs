using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{
    public float _moveSpeed;
    Vector2 _firstPos;
    Vector2 _secondPos;
    Vector2 _currentPos;
    float _currentGroundNumber;
    Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Swipe();
    }

    private void Swipe() {
        if(Input.GetMouseButtonDown(0)) {
            _firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if(Input.GetMouseButtonUp(0)) {
            _secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            _currentPos = new Vector2(
                _secondPos.x - _firstPos.x,
                _secondPos.y - _firstPos.y
            );

            _currentPos.Normalize();
        }

        if(_currentPos.y > 0 && _currentPos.x > -0.5f && _currentPos.x < 0.5f) { // Forward
            _rb.velocity = Vector3.forward * _moveSpeed;
        }
        else if(_currentPos.y < 0 && _currentPos.x > -0.5f && _currentPos.x < 0.5f) { // Back
            _rb.velocity = Vector3.back * _moveSpeed;
        }
        else if(_currentPos.x > 0 && _currentPos.y > -0.5f && _currentPos.y < 0.5f) {// Right
            _rb.velocity = Vector3.right * _moveSpeed;
        }
        else if(_currentPos.x < 0 && _currentPos.y > -0.5f && _currentPos.y < 0.5f) { // Left
            _rb.velocity = Vector3.left * _moveSpeed;
        }
    }
}
