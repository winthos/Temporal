using UnityEngine;
using System.Collections;

public class PausableState : MonoBehaviour
{
  public bool CanPause = false;
  // Use this for initialization
  void Start()
  {
    MenuHelper.Instance.CanPause = this.CanPause;
  }

  void Awake()
  {
    MenuHelper.Instance.CanPause = this.CanPause;
  }

    void OnApplicationFocus(bool hasFocus)
    {
        if(!MenuHelper.Instance.IsPaused())
        {
            MenuHelper.Instance.Pause();
        }
    }
}
