using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public TMP_InputField input;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input.onValueChanged.AddListener(SetName);

        input.text = DataTransfer.instance.playerName;
    }

    public void SetName(string name)
    {
        DataTransfer.instance.playerName = name;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        DataTransfer.instance.Save();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
