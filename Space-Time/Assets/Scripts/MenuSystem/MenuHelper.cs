using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using UnityEditor;
#endif

/*
 * Sort orders:
 * MainMenu: 0
 * Game: 1 and 2
 * BackPanel: 3
 * PauseLevel and confirmation: 4
 * All other Overlays: 5
 */

public class PausableBehavior : MonoBehaviour
{ }

public class MenuHelper : SingletonBehavior<MenuHelper>
{
  public float ActiveTimeScale = 1.0f;
  public bool CanPause = false;

  //////////////////////////////
  public string BackPanelLevel { get { return bpLevel_p; } set { bpLevel_p = value; } }
  [HideInInspector]
  public string bpLevel_p; //There's got to be a cleaner way to do this...

  public string PauseLevel { get { return pauseLevel_p; } set { pauseLevel_p = value; } }
  [HideInInspector]
  public string pauseLevel_p; //There's got to be a cleaner way to do this...

  public string ConfirmationLevel { get { return confirmationLevel_p; } set { confirmationLevel_p = value; } }
  [HideInInspector]
  public string confirmationLevel_p; //... Maybe not...

  public string QuitLevel { get { return quitLevel_p; } set { quitLevel_p = value; } }
  [HideInInspector]
  public string quitLevel_p; //... Definitely not...
  //////////////////////////////

  private bool paused = false;
  private string loadCandidate = null;
  private List<string> LevelStack = new List<string>();
  private string lastPopped;
  private bool canQuit = false;
  private bool tryingQuit = false;

  void Start()
  {
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      this.Pause();
    }
  }

  public void ConfirmQuit()
  {
    this.canQuit = true;
    Application.Quit();
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#endif
  }

  // Quit levels are not part of the level stack.
  public void DenyQuit()
  {
    SceneManager.UnloadScene(this.QuitLevel);
    this.mangleCanvases(true);
    this.tryingQuit = false;
    this.canQuit = false;
  }

  public void ApplicationQuitAttempt()
  {
    if (!this.tryingQuit)
    {
      this.tryingQuit = true;
      this.mangleCanvases(false);
      SceneManager.LoadScene(this.QuitLevel, LoadSceneMode.Additive);
    }
  }

  void OnApplicationQuit()
  {
    if (!this.canQuit)
    {
      Application.CancelQuit();
      this.ApplicationQuitAttempt();
      //Debug.Log("We were told to quit, but refused.");
    }
  }

  public void LoadScene(string msg)
  {
    this.lastPopped = null;
    this.loadCandidate = null;
    SceneManager.LoadScene(msg);
    this.LevelStack.Clear();
  }

  // Expect bad things if this is not used as a "Return" button.
  // Expect worse things if the level stack is empty.
  // TODO: What exception should I throw in the "worse things" case?
  public void RewindScene()
  {
    this.mangleCanvases(true);
    if (this.LevelStack.Count > 0)
    {
      string newLastPopped = this.LevelStack[this.LevelStack.Count - 1];
      SceneManager.UnloadScene(this.LevelStack[this.LevelStack.Count - 1]);
      this.LevelStack.RemoveAt(this.LevelStack.Count - 1);

      SceneManager.LoadScene(this.lastPopped, LoadSceneMode.Additive);
      this.LevelStack.Add(this.lastPopped);
      if(newLastPopped != this.QuitLevel)
        this.lastPopped = newLastPopped;
    }
    else
    {
      SceneManager.LoadScene(this.lastPopped);
      this.lastPopped = null;
    }
  }

  public void OverlayScene(string msg, bool withUnload = true)
  {
    this.mangleCanvases(false);
    if (withUnload && this.LevelStack.Count > 0)
    {
      try
      {
        SceneManager.UnloadScene(this.LevelStack[this.LevelStack.Count - 1]);
      }
      catch(ArgumentException)
      {
        
      }
      this.lastPopped = this.LevelStack[this.LevelStack.Count - 1];
      this.LevelStack.RemoveAt(this.LevelStack.Count - 1);
    }

    SceneManager.LoadScene(msg, LoadSceneMode.Additive);
    this.LevelStack.Add(msg);
  }

  public void DestructiveLoadScene(string msg)
  {
    this.loadCandidate = msg;
    if (this.LevelStack.Count > 0)
    {
      SceneManager.UnloadScene(this.LevelStack[this.LevelStack.Count - 1]);
      this.lastPopped = this.LevelStack[this.LevelStack.Count - 1];
      this.LevelStack.RemoveAt(this.LevelStack.Count - 1);
    }

    SceneManager.LoadScene(this.ConfirmationLevel, LoadSceneMode.Additive);
    this.LevelStack.Add(this.ConfirmationLevel);
  }

  public void ConfirmDestructiveLoad()
  {
    this.reset();
    if (this.loadCandidate != null)
    {
      SceneManager.LoadScene(this.loadCandidate);
      this.LevelStack.Clear();
    }
    this.lastPopped = null;
    this.loadCandidate = null;
  }

  public void DenyDestructiveLoad()
  {
    SceneManager.UnloadScene(this.ConfirmationLevel);
    this.LevelStack.Remove(this.ConfirmationLevel);

    SceneManager.LoadScene(this.lastPopped, LoadSceneMode.Additive);
    this.LevelStack.Add(this.lastPopped);
    this.lastPopped = this.ConfirmationLevel;
  }

  private void reset()
  {
    Time.timeScale = this.ActiveTimeScale;
    this.paused = false;
  }

  public bool IsPaused()
  {
     return this.paused;
  }

  public bool Pause()
  {
    if (this.tryingQuit)
    {
      //NO!
      return false;
    }
      Input.ResetInputAxes();
    //this.mangleCanvases();
    if (this.paused)
    {
      Debug.Log("Unpausing, but verifying stack first");
        // We're paused, but don't want to unpause. This is an edge case. It's hard coding is intentional.
      if (this.LevelStack[this.LevelStack.Count - 1] != this.PauseLevel)
      {
        Debug.Log("Verify fail. Unpopping/unloading: " + this.LevelStack[this.LevelStack.Count - 1]);
        this.RewindScene();
        //if (this.LevelStack[this.LevelStack.Count - 1] != this.QuitLevel)
        {
          return true;
        }
        //else
        {
          
        }
      }
      // somewhat obviously, if it was possible to pause, then we should still be able to pause.
      // less obviously, english in the context of a game engine is hard.
      this.CanPause = true;
      //SoundManager.Instance.PauseEffectsOff();
      Time.timeScale = this.ActiveTimeScale;
      if (UnityEngine.EventSystems.EventSystem.current)
      {
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
        MenuSettings es = UnityEngine.EventSystems.EventSystem.current.GetComponent<MenuSettings>();
        if (es != null)
        {
          es.StopSelection();
        }
        SceneManager.UnloadScene(this.BackPanelLevel);
        SceneManager.UnloadScene(this.PauseLevel);
        this.lastPopped = this.PauseLevel;
        this.LevelStack.Remove(this.PauseLevel);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
      }
    }
    else if (!this.paused && this.CanPause)
    {
      Debug.Log("Pausing");
      //SoundManager.Instance.PauseEffectsOn();
      Time.timeScale = 0.0f;
      if (!this.tryingQuit)
      {
        SceneManager.LoadScene(this.BackPanelLevel, LoadSceneMode.Additive);
        this.LevelStack.Add(this.BackPanelLevel);

        SceneManager.LoadScene(this.PauseLevel, LoadSceneMode.Additive);
        this.LevelStack.Add(this.PauseLevel);
      }
    }
    else
    {
      return false;
    }
    this.paused = !this.paused;
    this.manglePausables();
    return false;
  }

  private void mangleCanvases(bool enabled)
  {
    GameObject[] allObjects = Object.FindObjectsOfType<GameObject>();
    foreach (GameObject gObj in allObjects)
    {
      // Only look at our current scene.
      Button[] dbgbList = gObj.GetComponents<Button>();
      foreach (Button dbgb in dbgbList)
      {
        if (dbgb.gameObject.GetComponentInParent<MenuSettings>())
        {
          dbgb.enabled = enabled;
          if(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject == dbgb.gameObject)
            dbgb.OnSelect(null);
        }
      }
    }
  }

  private void manglePausables()
  {
    GameObject[] allObjects = Object.FindObjectsOfType<GameObject>();
    foreach (GameObject gObj in allObjects)
    {
      // Only look at our current scene.
      if (gObj.activeInHierarchy)
      {
        PausableBehavior[] dbgbList = gObj.GetComponents<PausableBehavior>();
        foreach (PausableBehavior dbgb in dbgbList)
        {
          dbgb.enabled = !this.paused;
        }
      }
    }
  }
}

#if UNITY_EDITOR
[CustomEditor(typeof (MenuHelper))]
[CanEditMultipleObjects]
class MenuHelperGUI : Editor
{
  private List<string> choices; 
  private SerializedProperty PauseLevel_P;

  void OnEnable()
  {
    List<string> knownScenes = new List<string>();
    foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
    {
      if (S.enabled)
      {
        string name = S.path.Substring(S.path.LastIndexOf('/') + 1); //no trailing
        name = name.Substring(0, name.Length - 6); //".unity"
        knownScenes.Add(name);
      }
    }
    this.choices = knownScenes;
  }

  public override void OnInspectorGUI()
  {
    this.DrawDefaultInspector();
    MenuHelper component = target as MenuHelper;

    EditorGUILayout.PrefixLabel("BackPanel");
    EditorGUILayout.LabelField("(What gets drawn underneathe overlay levels)");
    int panelChoice = this.choices.IndexOf(component.BackPanelLevel);
    if (panelChoice < 0)
    {
      panelChoice = 0;
    }
    panelChoice = EditorGUILayout.Popup(panelChoice, this.choices.ToArray());

    EditorGUILayout.PrefixLabel("PauseLevel");
    int pauseChoice = this.choices.IndexOf(component.PauseLevel);
    if (pauseChoice < 0)
    {
      pauseChoice = 0;
    }
    pauseChoice = EditorGUILayout.Popup(pauseChoice, this.choices.ToArray());

    EditorGUILayout.PrefixLabel("ConfirmationLevel");
    int confirmChoice = this.choices.IndexOf(component.ConfirmationLevel);
    if (confirmChoice < 0)
    {
      confirmChoice = 0;
    }
    confirmChoice = EditorGUILayout.Popup(confirmChoice, this.choices.ToArray());

    EditorGUILayout.PrefixLabel("QuitLevel");
    int quitChoice = this.choices.IndexOf(component.QuitLevel);
    if (quitChoice < 0)
    {
      quitChoice = 0;
    }
    quitChoice = EditorGUILayout.Popup(quitChoice, this.choices.ToArray());

    if (component.BackPanelLevel != this.choices[panelChoice] ||
        component.PauseLevel != this.choices[pauseChoice] ||
        component.ConfirmationLevel != this.choices[confirmChoice] ||
        component.QuitLevel != this.choices[quitChoice])
    {
      Undo.RecordObject(target, "Changed Scene Selection on " + target.name);
    }
    component.BackPanelLevel = this.choices[panelChoice];
    component.PauseLevel = this.choices[pauseChoice];
    component.ConfirmationLevel = this.choices[confirmChoice];
    component.QuitLevel = this.choices[quitChoice];
  }
}
#endif