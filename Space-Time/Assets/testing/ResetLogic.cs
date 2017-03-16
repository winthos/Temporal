using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLogic : MonoBehaviour
{
    [SerializeField]
    KeyCode restart = KeyCode.R;
    	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(restart))
            ReloadLevel();
	}

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
