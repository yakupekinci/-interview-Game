using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinColllcet2 : MonoBehaviour
{
    
    public static bool collectiablec;
    private bool collected = false;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (collected)
        { 
            Vector3 targetPos = CoinCollect.instance.GetIconPosition(transform.position);

            if (Vector2.Distance(transform.position, targetPos) > 0.5f)
            {
                transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 7f);
            }
            else
            {

                CoinCollect.instance.AddCount(1);
                gameObject.SetActive(false);
            }
        }
    }
    public void SetCollected()
    {
        collected = true;
    }
}

