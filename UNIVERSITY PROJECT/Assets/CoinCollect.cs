using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollect : MonoBehaviour
{
    public static CoinCollect instance;
    
    private int coin = 0;
    public TextMeshProUGUI countText;
    public Transform icontransform;
    private Camera mainCamera;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        mainCamera = Camera.main;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCount(int amount)
    {
        coin += amount;
        countText.text = coin.ToString();

    }
    public Vector3 GetIconPosition(Vector3 target)
    {
        Vector3 uiPos = icontransform.position;
        uiPos.z = (target - mainCamera.transform.position).z;
        Vector3 result = mainCamera.ScreenToWorldPoint(uiPos);
        return result;
    }
}
