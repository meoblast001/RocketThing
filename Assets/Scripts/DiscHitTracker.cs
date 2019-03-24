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
        GameManager.Singleton.PassedDisc();
      else
        GameManager.Singleton.StopGame();

      this.gameObject.SetActive(false);
      Object.Destroy(this.gameObject);
    }
  }
}
