using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    float CurrentGroundNumber;
    Material _material;
    Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _material = GetComponent<MeshRenderer>().material;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            if (other.gameObject.GetComponent<MeshRenderer>().material.color != _material.color)
            {
                Constraints();
                other.gameObject.GetComponent<MeshRenderer>().material.color = _material.color;
                CurrentGroundNumber++;
                Events.LevelSliderChange?.Invoke(CurrentGroundNumber);
            }
        }
    }
    private void Constraints()
    {
        _rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }
}
