using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PatrolController : MonoBehaviour
{
    [Header("Properties")]
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public Transform[] moveSpots;
    private int randomSpot;

    public Vector2 oldPosition;
    public Vector2 newPosition;

    [Header("default position")]
    public Vector2 defaultPosition;

    [Header("bool")]
    public bool isButterfly;
    public bool isFish;

    public bool isMammals;

    public bool isSprite;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        oldPosition = transform.position;
        if (isButterfly)
        {
            defaultPosition = transform.position;
            moveSpots = new Transform[1];
            moveSpots[0] = GameObject.Find("goto").transform.GetComponent<Transform>();
        }
    }

    void Flip()
    {
        if (!isSprite)
        {
            if (!isFish)
            {
                if (oldPosition.x > newPosition.x)
                {
                    transform.localScale = new Vector3(
                        -1,
                        transform.localScale.y,
                        transform.localScale.z
                    );
                }
                else
                {
                    transform.localScale = new Vector3(
                        1,
                        transform.localScale.y,
                        transform.localScale.z
                    );
                }
            }
            else
            {
                if (oldPosition.x > newPosition.x)
                {
                    transform.localScale = new Vector3(
                        1,
                        transform.localScale.y,
                        transform.localScale.z
                    );
                }
                else
                {
                    transform.localScale = new Vector3(
                        -1,
                        transform.localScale.y,
                        transform.localScale.z
                    );
                }
            }
        }
        else
        {
            if (oldPosition.x > newPosition.x)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveSpots.Any())
        {
            newPosition = moveSpots[randomSpot].position;
            transform.position = Vector2.MoveTowards(
                transform.position,
                moveSpots[randomSpot].position,
                speed * Time.deltaTime
            );
            Flip();
            if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitTime;

                    oldPosition = newPosition;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }
}
