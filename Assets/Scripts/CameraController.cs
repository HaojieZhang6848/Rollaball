using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    private Vector3 _offset;

    // Start is called before the first frame update
    private void Start() {
        _offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    private void LateUpdate() {
        // LateUpdate is called after all Update functions have been called. This is useful to order script execution.
        transform.position = player.transform.position + _offset;
    }
}