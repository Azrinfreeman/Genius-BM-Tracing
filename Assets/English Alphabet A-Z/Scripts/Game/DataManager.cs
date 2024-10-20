using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

public class DataManager
{
    /// <summary>
    /// Save the shape stars.
    /// </summary>
    /// <param name="ID">The ID of the shape.</param>
    /// <param name="stars">Stars.</param>
    public static void SaveShapeStars(int ID, ShapesManager.Shape.StarsNumber stars)
    {
        PlayerPrefs.SetInt(GetStarsStrKey(ID), CommonUtil.ShapeStarsNumberEnumToIntNumber(stars));
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Get the shape stars.
    /// </summary>
    /// <returns>The shape stars.</returns>
    /// <param name="ID">The ID of the shape.</param>
    public static ShapesManager.Shape.StarsNumber GetShapeStars(int ID)
    {
        ShapesManager.Shape.StarsNumber stars = ShapesManager.Shape.StarsNumber.ZERO;
        string key = GetStarsStrKey(ID);
        if (PlayerPrefs.HasKey(key))
        {
            stars = CommonUtil.IntNumberToShapeStarsNumberEnum(PlayerPrefs.GetInt(key));
        }
        return stars;
    }

    /// <summary>
    /// Save the color of the shape path.
    /// </summary>
    /// <param name="ID">The ID of the shape.</param>
    /// <param name="from">From.</param>
    /// <param name="to">To.</param>
    /// <param name="color">Color.</param>
    public static void SaveShapePathColor(int ID, int from, int to, Color color)
    {
        PlayerPrefs.SetString(
            GetPathStrKey(ID, from, to),
            color.r + "," + color.g + "," + color.b + "," + color.a
        );
        PlayerPrefs.Save();
    }

    //new reward code here
    public static void SaveRewardShape(int ID)
    {
        if (PlayerPrefs.GetInt("Shape_" + ID + "_Reward_Count") != 0)
        {
            int i = 0;
            i = PlayerPrefs.GetInt("Shape_" + ID + "_Reward_Count");
            i++;
            PlayerPrefs.SetInt("Shape_" + ID + "_Reward_Count", i);

            //CheckRewardShape(ID);
        }
        else
        {
            PlayerPrefs.SetInt("Shape_" + ID + "_Reward_Count", 1);
            PlayerPrefs.Save();
        }
    }

    public static void CheckRewardShape(int ID)
    {
        if (
            PlayerPrefs.GetInt("Shape_" + ID + "_Reward_Count")
            == RewardFillController.instance.rewardLastValue
        )
        {
            //reset indexCount to 0

            if (
                PlayerPrefs.GetInt("Shape_" + ShapesManager.Shape.selectedShapeID + "_IndexReward")
                == PlayerPrefs.GetInt(
                    "Shape_" + ShapesManager.Shape.selectedShapeID + "_TotalReward"
                )
            )
            {
                PlayerPrefs.SetInt(
                    "Shape_" + ShapesManager.Shape.selectedShapeID + "_Reward_Count",
                    RewardFillController.instance.rewardLastValue
                );
            }
            else
            {
                PlayerPrefs.SetInt("Shape_" + ID + "_Reward_Count", 0);
                RewardFillController.instance.rewardValueIndex = 0;
            }

            int l;

            //check IndexReward
            if (PlayerPrefs.GetInt("Shape_" + ID + "_IndexReward") == 0)
            {
                l = 1;
                PlayerPrefs.SetInt("Shape_" + ID + "_IndexReward", l);
            }
            else if (PlayerPrefs.GetInt("Shape_" + ID + "_IndexReward") > 0)
            {
                l = PlayerPrefs.GetInt("Shape_" + ID + "_IndexReward");

                //check if IndexReward has unlocked all, no change is index REward == totalReward
                if (l == PlayerPrefs.GetInt("Shape_" + ID + "_TotalReward"))
                {
                    PlayerPrefs.GetInt("Shape_" + ID + "_TotalReward");
                }
                else
                {
                    l++;
                }
                PlayerPrefs.SetInt("Shape_" + ID + "_IndexReward", l);
            }

            PlayerPrefs.Save();
        }
    }

    public static void SaveTotalRewardShape(int ID, int count)
    {
        PlayerPrefs.SetInt("Shape_" + ShapesManager.Shape.selectedShapeID + "_TotalReward", count);
        PlayerPrefs.Save();
    }

    public static int GetRewardShape(int ID)
    {
        return PlayerPrefs.GetInt("Shape_" + ID + "_Reward_Count");
    }

    /// <summary>
    /// Get the color of the shape path.
    /// </summary>
    /// <returns>The shape path color.</returns>
    /// <param name="ID">The ID of the shape.</param>
    /// <param name="from">From.</param>
    /// <param name="to">To.</param>
    public static Color GetShapePathColor(int ID, int from, int to)
    {
        Color color = Color.white;
        string key = GetPathStrKey(ID, from, to);
        if (PlayerPrefs.HasKey(key))
        {
            color = CommonUtil.StringRGBAToColor(PlayerPrefs.GetString(key));
        }
        return color;
    }

    /// <summary>
    /// Determine whether the shape is locked or not.
    /// </summary>
    /// <returns><c>true</c> if is shape locked; otherwise, <c>false</c>.</returns>
    /// <param name="ID">The ID of the shape.</param>
    public static bool IsShapeLocked(int ID)
    {
        bool isLocked = true;
        string key = GetLockedStrKey(ID);
        if (PlayerPrefs.HasKey(key))
        {
            isLocked = CommonUtil.ZeroOneToTrueFalseBool(PlayerPrefs.GetInt(key));
        }
        return isLocked;
    }

    /// <summary>
    /// Save the shape locked status.
    /// </summary>
    /// <param name="ID">The ID of the shape.</param>
    /// <param name="isLocked">Whether the shape is locked or not.</param>
    public static void SaveShapeLockedStatus(int ID, bool isLocked)
    {
        PlayerPrefs.SetInt(GetLockedStrKey(ID), CommonUtil.TrueFalseBoolToZeroOne(isLocked));
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Return the string key of specific path.
    /// </summary>
    /// <returns>The string key.</returns>
    /// <param name="shapeID">The ID of the shape.</param>
    /// <param name="from">From number.</param>
    /// <param name="to">To number.</param>
    public static string GetPathStrKey(int shapeID, int from, int to)
    {
        return ShapesManager.shapePrefix + "-Shape-" + shapeID + "-Path-" + from + "-" + to;
    }

    /// <summary>
    /// Return the locked string key of specific shape.
    /// </summary>
    /// <returns>The locked string key.</returns>
    /// <param name="ID">The ID of the shape.</param>
    public static string GetLockedStrKey(int ID)
    {
        return ShapesManager.shapePrefix + "-Shape-" + ID + "-isLocked";
    }

    /// <summary>
    /// Return the stars string key of specific shape.
    /// </summary>
    /// <returns>The stars string key.</returns>
    /// <param name="ID">The ID of the shape.</param>
    public static string GetStarsStrKey(int ID)
    {
        return ShapesManager.shapePrefix + "-Shape-" + ID + "-Stars";
    }

    /// <summary>
    /// Reset the game.
    /// </summary>
    public static void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
}
