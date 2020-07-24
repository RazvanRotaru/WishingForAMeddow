using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    private TerrainController terrainController;

    [SerializeField]
    private float tileRadius;


    [SerializeField]
    Vector3 minVals;
    [SerializeField]
    Vector3 maxVals;

    public float distanceToPlayer;

    private float _xAxis;
    private float _yAxis;
    private float _zAxis;

    [SerializeField]
    private Vector3 _randomPosition;
    public bool _canInstantiate;

    void Start()
    {
        minVals = new Vector3(distanceToPlayer, 3.0f, distanceToPlayer);
        maxVals = terrainController.TerrainSize * tileRadius;
        maxVals.y = 10;
    }

    void OnEnable()
    {
        EventManager.borderCrossed += Spawn;
    }

    void OnDisable()
    {
        EventManager.borderCrossed -= Spawn;
    }

    Vector3 GetRandomPosition()
    {
        _xAxis = UnityEngine.Random.Range(minVals.x, maxVals.x);
        _yAxis = UnityEngine.Random.Range(minVals.y, maxVals.y);
        _zAxis = UnityEngine.Random.Range(minVals.z, maxVals.z);

        return new Vector3(_xAxis, _yAxis, _zAxis);
    }

    void Spawn()
    {
        _randomPosition = GetRandomPosition();

        while (Physics.CheckBox(_randomPosition, transform.localScale))
            _randomPosition = GetRandomPosition();

        transform.position = _randomPosition;
    }
}
