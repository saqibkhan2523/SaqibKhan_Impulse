using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject howToPlayPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void DisplayInstructions()
    {
        howToPlayPanel.gameObject.SetActive(true);
    }

    public void HideInstructions()
    {
        howToPlayPanel.gameObject.SetActive(false);
    }
}
