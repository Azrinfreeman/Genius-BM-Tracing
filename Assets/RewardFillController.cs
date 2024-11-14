using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    private Transform RewardDialog;

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private TextMeshProUGUI valueText;

    public int rewardValueIndex;
    public int rewardLastValue;

    public Image imageReward;

    public Image progress;

    private float tempReward;
    private float tempRewardLast;

    private float testTotal;

    // Start is called before the first frame update
    void Start()
    {
        progress = transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();
        RewardDialog = GameObject.Find("RewardDialog").GetComponent<Transform>();
        imageReward = transform.GetChild(1).transform.GetChild(1).GetComponent<Image>();
        rewardLastValue = 5;
        slider = transform.GetChild(0).GetComponent<Slider>();
        valueText = transform.GetChild(0).transform.Find("Value").GetComponent<TextMeshProUGUI>();

        //assign value to index equals to certain current game shape id
        rewardValueIndex = DataManager.GetRewardShape(ShapesManager.Shape.selectedShapeID);
        slider.maxValue = rewardLastValue;

        Invoke("CheckIfRewardDone", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        //DataManager.CheckRewardShape(ShapesManager.Shape.selectedShapeID);
        rewardValueIndex = PlayerPrefs.GetInt(
            "Shape_" + ShapesManager.Shape.selectedShapeID + "_Reward_Count"
        );

        slider.value = rewardValueIndex;
        //round increase number
        tempReward = rewardValueIndex;
        tempRewardLast = rewardLastValue;
        testTotal = tempReward / tempRewardLast;
        progress.fillAmount = testTotal;

        valueText.text = rewardValueIndex.ToString() + " / " + rewardLastValue.ToString();

        //assign image if index Reward has increase
        if (
            PlayerPrefs.GetInt("Shape_" + ShapesManager.Shape.selectedShapeID + "_IndexReward")
            != PlayerPrefs.GetInt("Shape_" + ShapesManager.Shape.selectedShapeID + "_TotalReward")
        )
        {
            imageReward.GetComponent<Transform>().gameObject.SetActive(true);
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

        if (
            PlayerPrefs.GetInt("Shape_" + ShapesManager.Shape.selectedShapeID + "_Reward_Count")
            >= rewardLastValue
        )
        {
            if (
                PlayerPrefs.GetInt("Shape_" + ShapesManager.Shape.selectedShapeID + "_IndexReward")
                != PlayerPrefs.GetInt(
                    "Shape_" + ShapesManager.Shape.selectedShapeID + "_TotalReward"
                )
            )
            {
                //Debug.Log("GetAnimal");
                ShowReward();
                //Invoke("CheckIfRewardDone", 1.2f);
            }
        }
    }

    public void CheckIfRewardDone()
    {
        if (
            PlayerPrefs.GetInt("Shape_" + ShapesManager.Shape.selectedShapeID + "_Reward_Count")
            >= rewardLastValue
        )
        {
            if (
                PlayerPrefs.GetInt("Shape_" + ShapesManager.Shape.selectedShapeID + "_IndexReward")
                != PlayerPrefs.GetInt(
                    "Shape_" + ShapesManager.Shape.selectedShapeID + "_TotalReward"
                )
            )
            {
                rewardValueIndex = 0;
                PlayerPrefs.SetInt(
                    "Shape_" + ShapesManager.Shape.selectedShapeID + "_Reward_Count",
                    rewardValueIndex
                );
            }
        }
    }

    public void ShowReward()
    {
        //play animation
        RewardDialog.GetComponent<Animator>().Play("OnDisplay");
        //set image for the rewrad
        RewardDialog.transform.GetChild(0).GetComponent<Image>().sprite =
            RewardController.instance.AssignImage(
                PlayerPrefs.GetInt("Shape_" + ShapesManager.Shape.selectedShapeID + "_IndexReward")
            );

        //set name of the reward
        RewardDialog
            .transform.GetChild(0)
            .transform.GetChild(0)
            .GetComponent<TextMeshProUGUI>()
            .text = RewardController
            .instance
            .HaiwanTotal[
                PlayerPrefs.GetInt("Shape_" + ShapesManager.Shape.selectedShapeID + "_IndexReward")
            ]
            .name;

        //set audio is in RewardAnimationController

        RewardDialog.transform.GetChild(0).GetComponent<Image>().preserveAspect = true;
    }

    public void HideReward()
    {
        RewardDialog.GetComponent<Animator>().Play("OffDisplay");
    }

    public void GetReward()
    {
        rewardValueIndex++;
    }
}
