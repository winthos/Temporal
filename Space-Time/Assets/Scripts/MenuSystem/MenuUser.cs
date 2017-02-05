using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuUser : MonoBehaviour
{
  private string loadCandidate = null;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}


  public void LoadScene(string msg)
  {
    MenuHelper.Instance.LoadScene(msg);
  }

  public void OverlayScene(string msg)
  {
    MenuHelper.Instance.OverlayScene(msg);
  }

  public void RewindScene()
  {
    MenuHelper.Instance.RewindScene();
  }

  public void DestructiveLoadAsk(string msg)
  {
    MenuHelper.Instance.DestructiveLoadScene(msg);
  }
  public void DestructiveLoadConfirm()
  {
    MenuHelper.Instance.ConfirmDestructiveLoad();
  }
  public void DestructiveLoadDeny()
  {
    MenuHelper.Instance.DenyDestructiveLoad();
  }

  public void QuitGameAsk()
  {
    MenuHelper.Instance.ApplicationQuitAttempt();
  }

  public void QuitGameConfirm()
  {
    MenuHelper.Instance.ConfirmQuit();
  }

  public void QuitGameDeny()
  {
    MenuHelper.Instance.DenyQuit();
  }

  public void Pause()
  {
    MenuHelper.Instance.Pause();
  }
}
