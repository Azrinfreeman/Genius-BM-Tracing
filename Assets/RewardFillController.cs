using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardFillController : MonoBehaviour
{
    public static RewardFillController instance;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private TextMeshProUGUI valueText;

    public int rewardValueIndex;
    public int rewardLastValue;

    // Start is called before the first frame update
    void Start()
    {
        rewardLastValue = 10;
        slider = transform.GetChild(0).GetComponent<Slider>();
        valueText = transform.GetChild(0).transform.Find("Value").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = rewardValueIndex;
        valueText.text = rewardValueIndex.ToString() + " / " + rewardLastValue.ToString();
    }

    public void GetReward()
    {
        rewardValueIndex++;
    }
}
