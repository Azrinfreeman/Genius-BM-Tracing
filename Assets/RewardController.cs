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

    void Initiate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            HaiwanTotal.Add(transform.GetChild(i));
            HaiwanTotal[i].gameObject.SetActive(false);
        }
        DataManager.SaveTotalRewardShape(ShapesManager.Shape.selectedShapeID, HaiwanTotal.Count);
    }

    public Sprite AssignImage(int indexReward)
    {
        return transform.GetChild(indexReward).GetChild(0).GetComponent<Image>().sprite;
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
                transform.GetChild(l).gameObject.SetActive(true);
            }
        }
    }
}
