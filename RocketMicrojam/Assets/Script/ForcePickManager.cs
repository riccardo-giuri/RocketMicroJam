using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForcePickManager : MonoBehaviour
{
    /// <summary>
    /// Ui slider for pickimg the force
    /// </summary>
    public Slider Slider;
    /// <summary>
    /// timer debug variable
    /// </summary>
    private float Timer;
    /// <summary>
    /// know if the timer need to go positive or not
    /// </summary>
    public bool PositiveTimer;
    /// <summary>
    /// how fast the handle slide on the slider
    /// </summary>
    public float BarSensitivity;
    /// <summary>
    /// know if the timer is activated
    /// </summary>
    public bool TimerActivated;
    /// <summary>
    /// time that basses between one choose and the other
    /// </summary>
    public float NewChooseTimer;
    /// <summary>
    /// the list of force data you picked
    /// </summary>
    public List<float> RocketForceList = new List<float>();
    /// <summary>
    /// number of pick done by the player
    /// </summary>
    public int PickCounter;

    // Start is called before the first frame update
    void Start()
    {
        Slider.value = 0;
        PositiveTimer = true;
        TimerActivated = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerActivated == true && PickCounter < 5)
        {
            SliderTimer();
        }
        if (Input.GetKeyDown(KeyCode.Space) && TimerActivated == true)
        {
            StartCoroutine(StartNewForceChoose());
        }
    }

    /// <summary>
    /// the timer that move the handle in the slider
    /// </summary>
    public void SliderTimer()
    {
        if (PositiveTimer == true)
        {
            if (Timer > 100)
            {
                PositiveTimer = false;
                return;
            }
            Timer += (Time.deltaTime * BarSensitivity);
            Slider.value = Timer;
        }
        else
        {
            if (Timer < 0)
            {
                PositiveTimer = true;
            }
            Timer -= (Time.deltaTime * BarSensitivity);
            Slider.value = Timer;
        }
    }

    /// <summary>
    /// restart timer values
    /// </summary>
    public void restartTimer()
    {
        Slider.value = 0;
        Timer = 0;
        PositiveTimer = true;
        TimerActivated = true;
    }

    /// <summary>
    /// coroutine that start and setup values after one player choise
    /// </summary>
    /// <returns></returns>
    public IEnumerator StartNewForceChoose()
    {
        AddToForceList(Timer, RocketForceList);
        
        TimerActivated = false;

        PickCounter++;

        yield return new WaitForSeconds(NewChooseTimer);

        restartTimer();
       
    }

    /// <summary>
    /// add a force value to the list of forces
    /// </summary>
    /// <param name="value"></param>
    /// <param name="ForceList"></param>
    public void AddToForceList(float value, List<float> ForceList)
    {
        if(value > 50f)
        {
            float diff = value - 50;
            value = 50 - diff;
        }
        ForceList.Add(value);
    }

    /// <summary>
    /// calculate total shooting force to use for shooting the rocket
    /// </summary>
    /// <param name="ForcesList"></param>
    /// <returns></returns>
    public float CalculateShootingForce(List<float> ForcesList)
    {
        float TotalForce = 0;

        foreach(float Force in ForcesList)
        {
            TotalForce += Force;
        }

        return TotalForce;
    }
}
