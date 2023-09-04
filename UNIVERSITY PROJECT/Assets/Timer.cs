using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float timer;
    public  static bool isCounting;

    // Start is called before the first frame update
    void Start()
    {
        isCounting = true;
    }
    

    // Update is called once per frame
    void Update()
    {
        Count();
    }
    private void Count()
    {
        if (isCounting)
        {
            timer += Time.deltaTime;
            int min = Mathf.FloorToInt(timer / 60f);
            int sec= Mathf.FloorToInt(timer % 60f);
            int mil = Mathf.FloorToInt((timer*100f)%100f);
            Display(min, sec,mil);
        }

    }
    private void Display(int min, int sec,int mil)
    {

        text.text = min.ToString("00") + ":" + sec.ToString("00")+":"+mil.ToString("00");
    }
   
}
