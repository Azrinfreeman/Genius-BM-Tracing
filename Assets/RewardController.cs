using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardController : MonoBehaviour
{
    public static RewardController instance;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    public List<Transform> HaiwanTotal;

    public void Initiate()
    {
        HaiwanTotal.Clear();
        int index = ShapesManager.Shape.selectedShapeID;

        //hide all rewards first of all
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        //enable reward only for selected index level reward
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == ShapesManager.Shape.selectedShapeID)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        //add animals into variable HaiwanTotal
        for (int i = 0; i < transform.GetChild(index).childCount; i++)
        {
            HaiwanTotal.Add(transform.GetChild(index).GetChild(i));
            HaiwanTotal[i].gameObject.SetActive(false);
        }
        DataManager.SaveTotalRewardShape(ShapesManager.Shape.selectedShapeID, HaiwanTotal.Count);
    }

    public Sprite AssignImage(int indexReward)
    {
        //seek child in REward Haiwan, find child based on index shape, then get the child count of that indexShape
        return transform
            .GetChild(ShapesManager.Shape.selectedShapeID)
            .transform.GetChild(indexReward)
            .GetChild(0)
            .GetComponent<Image>()
            .sprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initiate();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Shape_" + ShapesManager.Shape.selectedShapeID + "_IndexReward") > 0)
        {
            int i = PlayerPrefs.GetInt(
                "Shape_" + ShapesManager.Shape.selectedShapeID + "_IndexReward"
            );
            for (int l = 0; l < i; l++)
            {
                transform
                    .GetChild(ShapesManager.Shape.selectedShapeID)
                    .transform.GetChild(l)
                    .gameObject.SetActive(true);
            }
        }
    }
}
