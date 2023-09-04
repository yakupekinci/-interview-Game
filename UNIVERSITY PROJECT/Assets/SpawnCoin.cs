using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour

{
    public GameObject[] coins;
    public Transform[] coinsV;
    public GameObject COINS;
    public GameObject coin;
    float counter;
    bool count;
    // Start is called before the first frame update
    void Start()
    {
        count = true;
        addCoin();
    }

    // Update is called once per frame
    void Update()
    {
        if (count)
        {
            counter += 0.1f * Time.deltaTime;
            Debug.Log(counter);
        }


        if (counter > 0.5)
        {
            spawnCoin();
            counter = 0;

        }



    }

    private void spawnCoin()
    {
        for (int i = 0; i < 40; i++)
        {
            if (coins[i] == null)
            {
                coins[i] = Instantiate(coin, coinsV[i]);
            }
         

        }
    }
    private void addCoin()
    {

        for (int i = 0; i < 40; i++)
        {
            coinsV[i] = COINS.transform.GetChild(i).transform;
        }

    }
}
