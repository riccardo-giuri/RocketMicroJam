using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    /// <summary>
    /// rigidbody of the object
    /// </summary>
    public Rigidbody2D RB;
    /// <summary>
    /// force picker reference
    /// </summary>
    public ForcePickManager forcePickManager;
    /// <summary>
    /// know if rocket has been shooted
    /// </summary>
    public bool IsShooted;
    /// <summary>
    /// reference to the UI manager
    /// </summary>
    public UIManagerRocketGame UIManagerRocketgame;
    /// <summary>
    /// EndGame menu 
    /// </summary>
    public RG_FrameworkMenu.UI_MenuBase EndGameMenu;
    /// <summary>
    /// Hud menu
    /// </summary>
    public RG_FrameworkMenu.UI_MenuBase HUD;
    /// <summary>
    /// distance travelled text
    /// </summary>
    public Text DistanceText;
    /// <summary>
    /// explosion sprite
    /// </summary>
    public Sprite explosion;

    // Start is called before the first frame update
    void Start()
    {
        IsShooted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (forcePickManager.PickCounter >= 5 && IsShooted == false)
        {
            LauchRocket();
        }
        if (RB.velocity.y < 0 && IsShooted == true)
        {
            ExplodeRocket();
        }

    }

    /// <summary>
    /// Shoot The rocket with a amount of force
    /// </summary>
    /// <param name="ShootForce"></param>
    public void ShootRocket(float ShootForce)
    {
        RB.AddForce(Vector2.up * ShootForce, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Sequence of action during the explosion 
    /// </summary>
    public void ExplodeRocket()
    {
        float distance =  this.transform.position.y - 0.8f;
        this.GetComponent<SpriteRenderer>().sprite = explosion;
        Time.timeScale = 0;
        UIManagerRocketgame.ActiveNewMenu(EndGameMenu);
        DistanceText.text = distance.ToString() + " Mt.";
    }

    /// <summary>
    /// series of action when the rocket is launched
    /// </summary>
    public void LauchRocket()
    {
        float TotalForce = forcePickManager.CalculateShootingForce(forcePickManager.RocketForceList);
        ShootRocket(TotalForce);
        HUD.gameObject.SetActive(false);
        IsShooted = true;
    }
}
