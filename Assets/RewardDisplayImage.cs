using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardDisplayImage : MonoBehaviour
{
    public List<Transform> imageCollection;

    public Transform selectedIndex;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            imageCollection.Add(transform.GetChild(i).transform);
        }

        Invoke("startLater", 0.3f);
    }

    public void startLater()
    {
        //disable all pictures
        for (int i = 0; i < 5; i++)
        {
            imageCollection[i].transform.gameObject.SetActive(false);
        }
        for (int i = 0; i < selectedIndex.childCount; i++)
        {
            imageCollection[i]
                .GetChild(0)
                .transform.GetChild(1)
                .GetComponent<TextMeshProUGUI>()
                .text = "";
            imageCollection[i].GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite =
                selectedIndex.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite;

            imageCollection[i].GetChild(0).transform.GetChild(0).GetComponent<Image>().color =
                Color.black;
            imageCollection[i].transform.gameObject.SetActive(true);
        }

        for (
            int i = 0;
            i
                < PlayerPrefs.GetInt(
                    "Shape_" + RewardDisplay.instance.currentIndexShape + "_IndexReward"
                );
            i++
        )
        {
            imageCollection[i]
                .GetChild(0)
                .transform.GetChild(1)
                .GetComponent<TextMeshProUGUI>()
                .text = selectedIndex.GetChild(i).transform.name;
            imageCollection[i].GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite =
                selectedIndex.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite;

            imageCollection[i].GetChild(0).transform.GetChild(0).GetComponent<Image>().color =
                Colors.whiteColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //choose selctedINdex
        selectedIndex = RewardLevelController.instance.ShapeCollection[
            RewardDisplay.instance.currentIndexShape
        ];
        Invoke("startLater", 1f);
    }
}
