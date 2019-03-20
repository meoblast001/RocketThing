using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscHitTracker : MonoBehaviour {
  public const string DiscEndTag = "DiscEnd";

  public bool Passed { get; set; }

  void Start() {
    this.Passed = false;
  }

  void OnTriggerEnter(Collider other) {
    if (other.CompareTag(DiscEndTag)) {
      if (this.Passed)
        Debug.Log("Passed!");
      else
        Debug.Log("Failed!");

      Object.Destroy(this.gameObject);
    }
  }
}
