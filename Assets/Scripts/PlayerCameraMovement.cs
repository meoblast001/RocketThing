using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCameraMovement : MonoBehaviour {
  public float speed = 2f;

  private Rigidbody rb;

  void Start() {
    this.rb = this.GetComponent<Rigidbody>();
  }

  void FixedUpdate() {
    var horizontal = Input.GetAxis("Horizontal") * this.speed;
    var vertical = Input.GetAxis("Vertical") * this.speed;
    if (horizontal != 0f || vertical != 0f) {
      var movement = new Vector3(horizontal, vertical, 0f);
      movement = Vector3.ClampMagnitude(movement, this.speed);

      this.rb.velocity = movement;
    }
  }
}
