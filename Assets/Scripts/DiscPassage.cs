using UnityEngine;

public class DiscPassage : MonoBehaviour {
  [SerializeField] private DiscHitTracker tracker;

  public DiscHitTracker Tracker {
    get { return this.tracker; }
  }
}
