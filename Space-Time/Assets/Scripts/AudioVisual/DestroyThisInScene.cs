using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DestroyThisInScene : MonoBehaviour
{
    public bool doNotDetroy = true;
    public string sceneName = "2_MainMenu";

    void Awake()
    {
        if (doNotDetroy)
            DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (SceneManager.GetActiveScene().name == sceneName)
            Destroy(gameObject);
    }
}
