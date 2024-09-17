using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    public float minPositionX;
    public float maxPositionX;
    public float currentPositionX;

    // Update is called once per frame
    void Update()
    {
        currentPositionX = Mathf.Clamp(player.transform.position.x, minPositionX, maxPositionX);
        transform.position = new Vector3(currentPositionX, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
