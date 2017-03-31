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
  
  public static bool TutorialRead = true;
  
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
    if (TutorialRead)
    {
      TutorialIndex = 99;
      ToggleTutorialBox(false);
    }
    else
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
    print(TutorialIndex > ActivationIndices[index].GetIndex());
    return (TutorialIndex > ActivationIndices[index].GetIndex());
    
  }
  
  public void OpenTutorial()
  {
    if (TutorialIndex >= TutorialText.Length)
      return;
    ToggleTutorialBox(true);
    TutorialTextBox.text = TutorialText[TutorialIndex];
    TutorialOccuring = true;
    //depending on the thing, spawn something here
    if (TutorialIndex == ActivationIndices[0].GetIndex()) //tutorial 1: Rifts
    {
      RiftSpawner.riftSpawner.LaunchRift(100);
    }
    else if (TutorialIndex == ActivationIndices[1].GetIndex()) //tutorial 2: Small / Medium Hazards
    {
      AsteroidSpawner.asteroidSpawner.LaunchAsteroid(0, 100);
    }
    else if (TutorialIndex == ActivationIndices[2].GetIndex()) //tutorial 3: Bomb / Spacer
    {
      EnemySpawner.enemySpawner.SpawnEnemy();  
    }
    else if (TutorialIndex == ActivationIndices[3].GetIndex()) //tutorial 4: TimeStop Activation
    {
      AsteroidSpawner.asteroidSpawner.LaunchAsteroid(3, 100);
    }
    else if (TutorialIndex == ActivationIndices[4].GetIndex()) //tutorial 5: Big Hazard, Timestop Rotation
    {
      AsteroidSpawner.asteroidSpawner.LaunchAsteroid(3, 100);
    }
    
  }
  
  public void AdvanceTutorial()
  {
    IncrementTutorialIndex();
    ToggleTutorialBox(false);
    TutorialOccuring = false;
    print("Tutorial Index is at " + TutorialIndex);
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
