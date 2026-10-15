using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TouchInputManager : MonoBehaviour
{
    #region Pixel Variables

    [Range(0, 1)]
    [SerializeField]
    float threshHori = 0.25f;

    [Range(0, 1)]
    [SerializeField]
    float threshVert = 0.25f;

    float targetPixelsHori;
    float targetPixelsVert;

    float amountDraggedHori;
    float amountDraggedVert;

    #endregion

    #region Enum Variables

    
    enum HoriEnum
    {
        left,
        right,
        none
    }

    
    enum VertEnum
    {
        up,
        down,
        none
    }

    [SerializeField]
    HoriEnum horiSwipeAction;

    [SerializeField]
    VertEnum vertSwipeAction;

    #endregion

    #region Vector Variables

    Vector2 startTouchPoisition;

    #endregion

    #region Bool Variables

    bool swipeMadeHori = false;
    bool swipeMadeVert = false;

    bool swipeAppliedHori = false;
    bool swipeAppliedVert = false;

    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        targetPixelsHori = Screen.width * threshHori;
        targetPixelsVert = Screen.height * threshVert;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    startTouchPoisition = touch.position;

                    break;


                case TouchPhase.Moved:

                    amountDraggedHori = touch.position.x - startTouchPoisition.x;
                    amountDraggedVert = touch.position.y - startTouchPoisition.y;

                    if (Mathf.Abs(amountDraggedHori) > targetPixelsHori && !swipeMadeHori)
                    {
                        if (amountDraggedHori > 0)
                        {
                            swipeMadeHori = true;

                            horiSwipeAction = HoriEnum.right;
                        }
                        else
                        {
                            swipeMadeHori = true;

                            horiSwipeAction = HoriEnum.left;
                        }

                        if (Mathf.Abs(amountDraggedVert) > targetPixelsVert && !swipeMadeVert)
                        {
                            if (amountDraggedHori > 0)
                            {
                                swipeMadeVert = true;

                                vertSwipeAction = VertEnum.up;
                            }
                            else
                            {
                                swipeMadeVert = true;

                                vertSwipeAction = VertEnum.down;
                            }
                        }

                        break;
                    }

                case TouchPhase.Ended:

                    amountDraggedHori = amountDraggedVert = 0;

                    swipeMadeVert = swipeMadeHori = false;
                    swipeAppliedVert = swipeAppliedHori = false;

                    horiSwipeAction = HoriEnum.none;
                    vertSwipeAction = VertEnum.none;

                    break;
            }
        }

        if (!swipeAppliedHori && horiSwipeAction != HoriEnum.none)
        {

            swipeAppliedHori = true;
        }

        if (!swipeAppliedVert && vertSwipeAction != VertEnum.none)
        {

            swipeAppliedVert = true;
        }
    }
}
