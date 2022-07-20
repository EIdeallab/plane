using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    Button btnRe;
    Button btnEnd;

    // Start is called before the first frame update
    void Start()
    {
        btnRe = this.transform.GetChild(0).gameObject.GetComponent<Button>();
        btnEnd = this.transform.GetChild(1).gameObject.GetComponent<Button>();
        if (btnRe != null)
        {
            btnRe.onClick.AddListener(OnClickReset);
        }
        if (btnEnd != null)
        {
            btnEnd.onClick.AddListener(OnClickEnd);
        }
    }

    void Update()
    {

    }

    // Update is called once per frame
    public void OnClickEnd()
    {
        Application.Quit();
    }

    public void OnClickReset()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameObject.scene.name);
        Time.timeScale = 1;
    }
}
