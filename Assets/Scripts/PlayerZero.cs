using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZero : MonoBehaviour {

    [SerializeField]
    private TerrainController terrainController;

    [SerializeField]
    public float distance;

    private void Start()
    {
        distance = terrainController.TerrainSize.z * terrainController.radiusToRender;
    }

    private void Update() {
        if (Vector3.Distance(Vector3.zero, transform.position) > distance) {
            terrainController.Level.position -= transform.position;
            transform.position = Vector3.zero;
            
            EventManager.CallCrossing();
        }
    }

}