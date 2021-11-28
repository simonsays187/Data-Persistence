using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public InputField inputName;
    
    // Start is called before the first frame update
    void Start()
    {
        inputName.text = GameManager.Instance.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void ChangePlayerName() {
        GameManager.Instance.playerName = inputName.text;
    }
}
