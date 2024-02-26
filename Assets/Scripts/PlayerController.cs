using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    private Rigidbody _rb;
    private float _movementX;
    private float _movementY;
    public float speed = 0.0f;
    public float deceleration = 0.0f;
    private Keyboard _keyboard;
    private static string PICKUP_TAG = "PickUp";

    // Start is called before the first frame update
    private void Start() {
        _rb = GetComponent<Rigidbody>();
        _keyboard = Keyboard.current;
    }

    // Update is called once per frame
    private void Update() {
    }

    private void FixedUpdate() {
        if (_keyboard.spaceKey.isPressed) {
            _rb.AddForce(-_rb.velocity * deceleration);
        }

        var movement = new Vector3(_movementX, 0.0f, _movementY);
        _rb.AddForce(movement * speed);
    }

    private void OnMove(InputValue movementValue) {
        var movementVector = movementValue.Get<Vector2>();
        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }

    private void OnTriggerEnter(Collider other) {
        // `OnTriggerEnter`是Unity引擎中的一个方法，它在一个游戏对象的碰撞器（Collider）首次进入另一个游戏对象的触发器（Trigger）时被调用。
        // 这个方法通常用于处理游戏对象之间的交互，例如收集物品、触发事件等。
        // 需要将`Is Trigger`属性设置为`true`的碰撞器才能触发`OnTriggerEnter`方法。
        // 如果一个碰撞器的`Is Trigger`属性被设置为`true`，那么它将不会对其他碰撞器产生物理效果，但是它可以触发其他碰撞器的`OnTriggerEnter`方法。
        var go = other.gameObject;
        if (go.CompareTag(PICKUP_TAG)) {
            go.SetActive(false);
        }
    }
}