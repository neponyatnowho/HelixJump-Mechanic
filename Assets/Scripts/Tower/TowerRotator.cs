using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;


[RequireComponent(typeof(Rigidbody))]
public class TowerRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                float torque  = -touch.deltaPosition.x * _rotateSpeed * Time.deltaTime;
                transform.Rotate(0, torque, 0);
            }
        }
    }
}
