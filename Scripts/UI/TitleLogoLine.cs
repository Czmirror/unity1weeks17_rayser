using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleLogoLine : MonoBehaviour
{
    [SerializeField] private RectTransform rectTran;
    // Start is called before the first frame update
    void Start()
    {
        
        rectTran.DOLocalMove(
            new Vector3(0,0,0), 
            0.5f
            )
            .SetDelay(1f)
            .SetEase(Ease.OutQuad)
            ;
    }


}
