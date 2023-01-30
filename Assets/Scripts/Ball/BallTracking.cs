using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallTracking : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _length;


    private Ball _ball;
    private Beam _beam;
    private Vector3 _minimumBallPosition;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _beam= FindObjectOfType<Beam>();

        _minimumBallPosition = _ball.transform.position;
        TrackBall();
    }

    private void Update()
    {
        if(_ball.transform.position.y < _minimumBallPosition.y)
        {
            TrackBall();
            _minimumBallPosition = _ball.transform.position;
        }
    }

    private void TrackBall()
    {
        Vector3 beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y - .5f;
        Vector3  _cameraPosition = _ball.transform.position;
        Vector3 direction = (beamPosition - _ball.transform.position) + _directionOffset;
        _cameraPosition -= direction * _length;
        transform.position = _cameraPosition;
        transform.LookAt( _ball.transform );
    }

}
