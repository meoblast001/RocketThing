using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DiscMovement : MonoBehaviour {
  private Rigidbody rb;

  void Start() {
    this.rb = this.GetComponent<Rigidbody>();
  }

  void Update() {
    this.rb.velocity = new Vector3(0f, 0f, -6f);
    this.rb.angularVelocity = new Vector3(0f, 0f, -1f);
  }
}
