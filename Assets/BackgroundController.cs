using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public List<Transform> backgroundImages;

    [Header("Toggle Whether In Album or Game")]
    public bool inAlbum;

    private void InitiateImages()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            backgroundImages.Add(transform.GetChild(i).transform);
        }
    }

    private void UpdateBackground()
    {
        if (!inAlbum)
        {
            //ShapesManager uses index
            //ScrollSlider currentGroundIndex starts at 1
            if (
                ShapesManager.Shape.selectedShapeID >= 0
                && ShapesManager.Shape.selectedShapeID <= 10
            )
            {
                backgroundImages[0].transform.gameObject.SetActive(true);
                backgroundImages[1].transform.gameObject.SetActive(false);
                backgroundImages[2].transform.gameObject.SetActive(false);
            }
            else if (
                ShapesManager.Shape.selectedShapeID > 10
                && ShapesManager.Shape.selectedShapeID <= 20
            )
            {
                backgroundImages[0].transform.gameObject.SetActive(false);
                backgroundImages[1].transform.gameObject.SetActive(true);
                backgroundImages[2].transform.gameObject.SetActive(false);
            }
            else if (
                ShapesManager.Shape.selectedShapeID > 20
                && ShapesManager.Shape.selectedShapeID <= 25
            )
            {
                backgroundImages[0].transform.gameObject.SetActive(false);
                backgroundImages[1].transform.gameObject.SetActive(false);
                backgroundImages[2].transform.gameObject.SetActive(true);
            }
        }
        else
        {
            if (
                ScrollSlider.instance.currentGroupIndex > 0
                && ScrollSlider.instance.currentGroupIndex <= 10
            )
            {
                backgroundImages[0].transform.gameObject.SetActive(true);
                backgroundImages[1].transform.gameObject.SetActive(false);
                backgroundImages[2].transform.gameObject.SetActive(false);
            }
            else if (
                ScrollSlider.instance.currentGroupIndex > 10
                && ScrollSlider.instance.currentGroupIndex <= 20
            )
            {
                backgroundImages[0].transform.gameObject.SetActive(false);
                backgroundImages[1].transform.gameObject.SetActive(true);
                backgroundImages[2].transform.gameObject.SetActive(false);
            }
            else if (
                ScrollSlider.instance.currentGroupIndex > 20
                && ScrollSlider.instance.currentGroupIndex <= 25
            )
            {
                backgroundImages[0].transform.gameObject.SetActive(false);
                backgroundImages[1].transform.gameObject.SetActive(false);
                backgroundImages[2].transform.gameObject.SetActive(true);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitiateImages();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBackground();
    }
}
