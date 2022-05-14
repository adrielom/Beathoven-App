using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;

public class UIHeartAttemptManager
{
    List<SVGImage> _hearts;
    private Sprite _fullHeart;
    private Sprite _halfHeart;
    private Sprite _emptyHeart;

    // <3 <3 <3 -> 3 corações = 6 tentativas; Attempt / 2
    // <3 <3 -> 2 corações = 4 tentativas; Attempt / 2
    // <3 <3 -> 2 corações = 3 tentativas; Attempt / 2

    public UIHeartAttemptManager(List<SVGImage> hearts)
    {
        _fullHeart = Resources.Load("Images/SVGs/UI/heartFull", typeof(Sprite)) as Sprite;
        _halfHeart = Resources.Load("Images/SVGs/UI/heartHalf", typeof(Sprite)) as Sprite;
        _emptyHeart = Resources.Load("Images/SVGs/UI/heartEmpty", typeof(Sprite)) as Sprite;
        this._hearts = hearts;
        SetListToFullHearts();
    }

    private void SetListToFullHearts()
    {
        for (int i = 0; i < _hearts.Count; i++)
        {
            _hearts[i].sprite = _emptyHeart;
        }
    }

    public void UpdateHearts(int attempts)
    {
        int heartStateAtLastPosition = attempts % 2;
        bool isLastElementHalfHeart = heartStateAtLastPosition == 1;
        int lastFullElement = (int)(attempts / 2);
        int lastElementThreshold = 0;

        for (var i = 0; i < lastFullElement; i++)
        {
            this._hearts[i].sprite = _fullHeart;
        }

        if (isLastElementHalfHeart)
        {
            this._hearts[lastFullElement].sprite = _halfHeart;
            lastElementThreshold = lastFullElement + 1;
        }
        else
        {
            lastElementThreshold = lastFullElement;
        }

        for (var i = lastElementThreshold; i < _hearts.Count; i++)
        {
            this._hearts[i].sprite = _emptyHeart;
        }
    }
}
