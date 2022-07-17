using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour
{
    float timer = 0;
    float endtimer = 0;
    float altitude = 0;
    bool crash = false;
    bool ended = false;
    string gameover = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setCrashed(bool value)
    {
        crash = value;
    }

    public void setEnded(bool value)
    {
        ended = value;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject plane = GameObject.Find("F18");
        altitude = plane.transform.position.y - 2.5f;

        if (altitude > 30)
        {
            gameover = "게임오버! - 고도 30M초과";
        }

        if (timer > 60)
        {
            gameover = "게임오버! - 시간 60초 초과.";
        }

        if (crash)
        {
            gameover = "게임오버! - 비행기 충돌";
        }

        timer += Time.deltaTime;

        var text = GetComponent<Text>();
        text.text = $"고도 : {(int)altitude}m, 시간 : {(int)timer}초\n {gameover}";


        if (ended)
        {
            Time.timeScale = 0;
            gameover = "게임승리!";
        }

        if (gameover.Length > 0 && ended == false)
        {
            var rb = plane.GetComponent<Rigidbody>();
            rb.useGravity = true;

            var script = plane.GetComponent<Airplane>();
            script.SetDestory(true);
        }
    }
}
