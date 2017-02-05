using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
  // Magic EventTrigger for button audio
  public class MSButtonTrigger : EventTrigger
  {
    protected MenuSettings owner;

    public void SetOwner(MenuSettings ms)
    {
      this.owner = ms;
    }

    public void PlayOnHighlight()
    {
      this.owner.Play(this.owner.OnHighlight);
    }

    public override void OnPointerEnter(PointerEventData data)
    {
      this.owner.Play(this.owner.OnHighlight);
    }

    public override void OnSelect(BaseEventData data)
    {
      this.owner.Play(this.owner.OnHighlight);
    }

    public override void OnSubmit(BaseEventData data)
    {
      this.owner.Play(this.owner.OnSubmit);
    }
  }

  // Audio
  public AudioClip OnHighlight;
  public AudioClip OnSubmit;
  private bool firstEvent = true;

  // Enforcement
  public bool EnforceSelection = true;
  private GameObject lastSelected = null;

  // Theft
  public bool StealEventSystem = false;
  public GameObject Selection;
  private GameObject wasSelected;

  protected void Play(AudioClip ac)
  {
    if (this.firstEvent)
    {
      this.firstEvent = false;
      return;
    }
    //SoundManager.Instance.PlayOnce(ac);
  }

  void Awake()
  {

  }


  void Start ()
  {
    if (this.StealEventSystem)
    {
      this.wasSelected = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
      UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(this.Selection);
    }


    this.firstEvent = false;
    GameObject[] allObjects = Object.FindObjectsOfType<GameObject>();
    foreach (GameObject gObj in allObjects)
    {
      // Only look at our current scene.
      if (gObj.activeInHierarchy)
      {
        Button[] dbgbList = gObj.GetComponents<Button>();
        foreach (Button dbgb in dbgbList)
        {
          EventTrigger currTrigger = dbgb.GetComponent<MSButtonTrigger>();
          if (currTrigger == null)
          {
            MSButtonTrigger autoTrigger = gObj.AddComponent<MSButtonTrigger>();
            autoTrigger.SetOwner(this);
          }
        }
      }
    }
  }

  public void StopSelection()
  {
    this.lastSelected = null;
  }
	
	// Update is called once per frame
	void Update ()
	{
	  if (this.EnforceSelection && UnityEngine.EventSystems.EventSystem.current)
	  {
	    GameObject currSelect = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
	    GameObject firstSelect = UnityEngine.EventSystems.EventSystem.current.firstSelectedGameObject;
	    if (currSelect != null)
	    {
	      this.lastSelected = currSelect;
	    }

	    if (currSelect == null)
	    {
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(this.lastSelected);
	      if (this.lastSelected == null)
	      {
          UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(firstSelect);
	      }
	    }
	  }
	}

  void OnDestroy()
  {
    if (this.StealEventSystem && UnityEngine.EventSystems.EventSystem.current)
      UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(this.wasSelected);
  }
}
