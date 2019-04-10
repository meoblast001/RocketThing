using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscHitTracker : MonoBehaviour {
  public bool Passed { get; set; }

  void Start() {
    this.Passed = false;
  }

  void OnTriggerEnter(Collider other) {
    if (other.CompareTag(Tags.DiscEnd)) {
      if (this.Passed)
        GameManager.Singleton.PassedDisc();
      else
        GameManager.Singleton.StopGame();

      this.gameObject.SetActive(false);
      Object.Destroy(this.gameObject);
    }
  }
}
