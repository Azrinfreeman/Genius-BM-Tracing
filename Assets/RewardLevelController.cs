using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardLevelController : MonoBehaviour
{
    public static RewardLevelController instance;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    public List<Transform> ShapeCollection;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
