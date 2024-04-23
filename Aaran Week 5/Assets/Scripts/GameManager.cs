using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Timer")]
    public int Timer;
    public TextMeshProUGUI TimerText;
    float currentTime = 0;

    [Header("Lives")]
    public int Lives;
    public TextMeshProUGUI LivesText;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime < 0) currentTime += Time.deltaTime;

        TimerText.text = "Timer:" + Mathf.RoundToInt(currentTime).ToString();
        LivesText.text = "Lives:" + Lives.ToString();
    }
}
