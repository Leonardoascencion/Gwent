using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCard : MonoBehaviour
{
    public Sprite Image;
    public Sprite OriginalImage;

    void Start()
    {
        Scope.BoxCard = this.gameObject;
    }


}
