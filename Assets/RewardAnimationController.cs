using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardAnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void playAudioReward()
    {
        //set audio for the reward
        //parent
        RewardController
            .instance.HaiwanTotal[
                PlayerPrefs.GetInt("Shape_" + ShapesManager.Shape.selectedShapeID + "_IndexReward")
            ]
            .GetChild(1)
            .parent.transform.gameObject.SetActive(true);
        //sfx
        RewardController
            .instance.HaiwanTotal[
                PlayerPrefs.GetInt("Shape_" + ShapesManager.Shape.selectedShapeID + "_IndexReward")
            ]
            .GetChild(1)
            .transform.gameObject.SetActive(true);
    }
}
