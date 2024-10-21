using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardDisplay : MonoBehaviour
{
    public static RewardDisplay instance;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    [SerializeField]
    private TextMeshProUGUI text;
    public int currentIndexShape;

    // Start is called before the first frame update
    void Start()
    {
        text = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //get the current shape index
        currentIndexShape = ScrollSlider.instance.currentGroupIndex;

        text.text =
            PlayerPrefs.GetInt("Shape_" + currentIndexShape + "_IndexReward") + "" + "/" + "5";
    }
}
