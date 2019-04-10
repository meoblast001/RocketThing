using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DiscMovement : MonoBehaviour {
  public float zMovement = -6f;
  public float maxAngularVelocityMagnitude = 1.5f;

  private Rigidbody rb;
  private float zAngularVelocity;

  void Start() {
    this.rb = this.GetComponent<Rigidbody>();
    this.rb.rotation = Quaternion.Euler(0f, 0f, Random.value * 360f);
    this.zAngularVelocity
      = ((Random.value * 2f) - 1f) * this.maxAngularVelocityMagnitude;
  }

  void Update() {
    this.rb.velocity = new Vector3(0f, 0f, this.zMovement);
    this.rb.angularVelocity = new Vector3(0f, 0f, this.zAngularVelocity);
  }
}
