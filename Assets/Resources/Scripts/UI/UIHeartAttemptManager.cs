using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;

public class UIHeartAttemptManager
{
    List<SVGImage> _hearts;
    private SVGImage _fullHeart;
    private SVGImage _halfHeart;
    private SVGImage _emptyHeart;

    // <3 <3 <3 -> 3 corações = 6 tentativas; Attempt / 2
    // <3 <3 -> 2 corações = 4 tentativas; Attempt / 2
    // <3 <3 -> 2 corações = 3 tentativas; Attempt / 2

    public UIHeartAttemptManager(List<SVGImage> hearts)
    {
        this._hearts = SetListToFullHearts(hearts);
        this._hearts.ForEach(h =>
        {
            // Debug.Log(h.sprite.name);
        });
        _fullHeart = Resources.Load("Images/SVGs/UI/HeartEmpty", typeof(SVGImage)) as SVGImage;
        _halfHeart = Resources.Load("Images/SVGs/UI/HeartEmpty", typeof(SVGImage)) as SVGImage;
        _emptyHeart = Resources.Load("Images/SVGs/UI/HeartEmpty", typeof(SVGImage)) as SVGImage;
    }

    private List<SVGImage> SetListToFullHearts(List<SVGImage> hearts)
    {
        List<SVGImage> fullHeartsList = new List<SVGImage>();

        for (int i = 0; i < hearts.Count; i++)
        {
            fullHeartsList.Add(_fullHeart);
        }

        return fullHeartsList;
    }

    public void UpdateHearts(int attempts)
    {
        int heartStatesAtLastPosition = attempts % 2;
        bool isLastElementHalfHeart = heartStatesAtLastPosition == 1;
        int lastFullElement = attempts / 2;

        for (var i = 0; i < lastFullElement; i++)
        {
            this._hearts[i] = _fullHeart;
        }

        if (isLastElementHalfHeart)
        {
            this._hearts[lastFullElement + 1] = _halfHeart;
        }
    }
}
