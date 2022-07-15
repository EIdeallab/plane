using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour
{
    float timer = 0;
    float altitude = 0;
    bool crash = false;
    string gameover = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setCrashed(bool value)
    {
        crash = value;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject plane = GameObject.Find("F18");
        altitude = plane.transform.position.y - 2.5f;

        if (altitude > 30)
        {
            gameover = "���ӿ���! - �� 30M�ʰ�";
        }

        if (timer > 60)
        {
            gameover = "���ӿ���! - �ð� 60�� �ʰ�.";
        }

        if (crash)
        {
            gameover = "���ӿ���! - ����� �浹";
        }

        timer += Time.deltaTime;

        var text = GetComponent<Text>();
        text.text = $"�� : {(int)altitude}m, �ð� : {(int)timer}��\n {gameover}";

        if (gameover.Length > 0)
        {
            Time.timeScale = 0;
        }
    }
}
