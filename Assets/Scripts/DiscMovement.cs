using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DiscMovement : MonoBehaviour {
  public float zMovement = -6f;

  private Rigidbody rb;
  private float zAngularVelocity;

  void Start() {
    this.rb = this.GetComponent<Rigidbody>();
    this.rb.rotation = Quaternion.Euler(0f, 0f, Random.value * 360f);
    this.zAngularVelocity = (Random.value - 0.5f) * 2f;
  }

  void Update() {
    this.rb.velocity = new Vector3(0f, 0f, this.zMovement);
    this.rb.angularVelocity = new Vector3(0f, 0f, this.zAngularVelocity);
  }
}
