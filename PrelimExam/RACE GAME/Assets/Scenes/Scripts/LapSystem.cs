using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapSystem : MonoBehaviour
{
    public int no_checks;
    public int curr_check;
    public int no_laps;
    public int curr_lap;
    public GameObject go_ui;


    void Start()
    {
        Time.timeScale = 1;
        go_ui.SetActive(false);
        no_checks = GameObject.Find("Checkpoints").transform.childCount;
        curr_check = 1;
        no_laps = 1;
        curr_lap = 1;
    }
    void Update()
    {
        //for checking if the lap is finished
        if (curr_check > no_checks)
        {
            curr_lap++;
            curr_check = 1;
        }
        if(curr_lap > no_laps)
        {
            go_ui.SetActive(true);
            Time.timeScale = 0; 
        }
    }

    void OnTriggerEnter(Collider check_col)
    {
        //for incrementing the checkpoints triggered.
        if (check_col.name == curr_check.ToString())
        {
            curr_check++;
        }
    }
}
