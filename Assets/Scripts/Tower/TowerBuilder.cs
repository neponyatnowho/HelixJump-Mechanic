using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private int _platformOffset;
    [SerializeField] private float _additionalScale;
    [SerializeField] private GameObject _beam;      
    [SerializeField] private SpawnPlatform _spawnPlatform;      
    [SerializeField] private FinishPlatform _finishPlatform;      
    [SerializeField] private Platform[] _platforms;

    private float BeamScaleY;
    private float _platformAdditionalScale;
    private float curentRotate = 0f;


    private void Awake()
    {
        _platformAdditionalScale = _platforms[0].transform.localScale.y;
        BeamScaleY = ((_levelCount + 1) * _platformOffset / 2f) + _additionalScale / 2f;
        Build();
    }

    private void Build()
    {
        GameObject beam =  Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(_beam.transform.localScale.x, BeamScaleY, _beam.transform.localScale.z);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale;

        SpawnPlatform(_spawnPlatform, ref spawnPosition, transform);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], ref spawnPosition, transform);
        }

        SpawnPlatform(_finishPlatform, ref spawnPosition, transform);

    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnposition, Transform parent)
    {
        Instantiate(platform, spawnposition, Quaternion.Euler(0, curentRotate, 0), parent);
        spawnposition.y -= _platformOffset;
        curentRotate += 10;
    }
}
