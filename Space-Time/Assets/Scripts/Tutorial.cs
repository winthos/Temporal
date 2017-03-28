using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour 
{
  public static Tutorial tutorial;
  
  [SerializeField]
  string[] TutorialText;
  
  [SerializeField]
  GameObject TutorialBox;
  
  [SerializeField]
  Text TutorialTextBox;
  
  [SerializeField]
  public static bool TutorialOccuring;
  
  int TutorialIndex;
  
  [SerializeField]
  ActivationIndex[] ActivationIndices;
  /*
  0 = rifts
  1 = small & medium hazards
  2 = bombs/spacers
  3 = TimeStop (no rotating)
  4 = Big Hazards and Arrow Key Movement
  
  */
  

	// Use this for initialization
	void Start () 
  {
    tutorial = GetComponent<Tutorial>();
    OpenTutorial();
	}
	
	// Update is called once per frame
	void Update () 
  {
    if (TutorialOccuring && Input.GetKeyDown(KeyCode.Return))
    {
      AdvanceTutorial();
    }
	}
  
  public int GetTutorialIndex()
  {
    return TutorialIndex;
  }
  
  public bool IsActivatedMechanic(int index)
  {
    return (TutorialIndex > ActivationIndices[index].GetIndex());
  }
  
  public void OpenTutorial()
  {
    if (TutorialIndex >= TutorialText.Length)
      return;
    ToggleTutorialBox(true);
    TutorialTextBox.text = TutorialText[TutorialIndex];
    TutorialOccuring = true;
  }
  
  public void AdvanceTutorial()
  {
    IncrementTutorialIndex();
    ToggleTutorialBox(false);
    TutorialOccuring = false;
  }
  
  public void IncrementTutorialIndex()
  {
    Mathf.Clamp(TutorialIndex++, 0, TutorialText.Length - 1);
  }
  
  public void ToggleTutorialBox(bool set)
  {
    TutorialBox.SetActive(set);
  }
}

[System.Serializable]
public class ActivationIndex
{
  [SerializeField]
  string Name;
  
  [SerializeField]
  int Index;
  
  public int GetIndex()
  {
    return Index;
  }
}
