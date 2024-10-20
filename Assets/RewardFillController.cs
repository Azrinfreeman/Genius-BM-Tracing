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

    public Image imageReward;

    // Start is called before the first frame update
    void Start()
    {
        imageReward = transform.GetChild(1).transform.GetChild(1).GetComponent<Image>();
        rewardLastValue = 5;
        slider = transform.GetChild(0).GetComponent<Slider>();
        valueText = transform.GetChild(0).transform.Find("Value").GetComponent<TextMeshProUGUI>();

        //assign value to index equals to certain current game shape id
        rewardValueIndex = DataManager.GetRewardShape(ShapesManager.Shape.selectedShapeID);
        slider.maxValue = rewardLastValue;
    }

    // Update is called once per frame
    void Update()
    {
        //DataManager.CheckRewardShape(ShapesManager.Shape.selectedShapeID);
        slider.value = rewardValueIndex;
        valueText.text = rewardValueIndex.ToString() + " / " + rewardLastValue.ToString();

        //assign image if index Reward has increase
        if (
            PlayerPrefs.GetInt("Shape_" + ShapesManager.Shape.selectedShapeID + "_IndexReward")
            != PlayerPrefs.GetInt("Shape_" + ShapesManager.Shape.selectedShapeID + "_TotalReward")
        )
        {
            imageReward.sprite = RewardController.instance.AssignImage(
                PlayerPrefs.GetInt("Shape_" + ShapesManager.Shape.selectedShapeID + "_IndexReward")
            );
            imageReward.preserveAspect = true;
        }
        else
        {
            imageReward.GetComponent<Transform>().gameObject.SetActive(false);
        }

        if (
            PlayerPrefs.GetInt("Shape_" + ShapesManager.Shape.selectedShapeID + "_IndexReward")
            == PlayerPrefs.GetInt("Shape_" + ShapesManager.Shape.selectedShapeID + "_TotalReward")
        )
        {
            PlayerPrefs.SetInt(
                "Shape_" + ShapesManager.Shape.selectedShapeID + "_Reward_Count",
                rewardLastValue
            );
        }
    }

    public void GetReward()
    {
        rewardValueIndex++;
    }
}
