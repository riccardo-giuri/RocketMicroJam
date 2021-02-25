using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerRocketGame : RG_FrameworkMenu.UI_ManagerGame
{
    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnSetup()
    {
        base.OnSetup();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
