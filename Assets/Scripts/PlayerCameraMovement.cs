using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCameraMovement : MonoBehaviour {
  public float speed = 2f;

  private Rigidbody rb;
  private Vector3 startPosition;

  private float Horizontal {
    get {
      var axis = Input.GetAxis("Horizontal");
      var mouse = Input.GetAxis("Mouse X");
      return axis + mouse;
    }
  }

  private float Vertical {
    get {
      var axis = Input.GetAxis("Vertical");
      var mouse = Input.GetAxis("Mouse Y");
      return axis + mouse;
    }
  }

  void Start() {
    this.rb = this.GetComponent<Rigidbody>();
    this.startPosition = this.rb.position;

    EventSystem.Subscribe(
      GameManager.GameStateChangeEvent,
      this.OnGameStateChangeEvent);
  }

  void OnDestroy() {
    EventSystem.Unsubscribe(
      GameManager.GameStateChangeEvent,
      this.OnGameStateChangeEvent);
  }

  void FixedUpdate() {
    var horizontal = this.Horizontal * this.speed;
    var vertical = this.Vertical * this.speed;
    if (horizontal != 0f || vertical != 0f) {
      var movement = new Vector3(horizontal, vertical, 0f);
      movement = Vector3.ClampMagnitude(movement, this.speed);

      this.rb.velocity = movement;
    }
  }

  private void OnGameStateChangeEvent(object sender, EventArgs e) {
    this.rb.velocity = new Vector3(0f, 0f, 0f);
    this.rb.MovePosition(startPosition);
  }
}
