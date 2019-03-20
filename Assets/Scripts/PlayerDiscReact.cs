using UnityEngine;

public class PlayerDiscReact : MonoBehaviour {
  void OnTriggerEnter(Collider other) {
    var passage = other.GetComponent<DiscPassage>();
    if (passage != null) {
      passage.Tracker.Passed = true;
    }
  }
}
