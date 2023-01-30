using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class BallJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigitbody;

    private void Start()
    {
        _rigitbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out PlatformSegment platformSegment))
        {
            _rigitbody.velocity = Vector3.zero;
            _rigitbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
