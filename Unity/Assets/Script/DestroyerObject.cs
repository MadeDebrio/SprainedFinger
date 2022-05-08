using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerObject : MonoBehaviour
{
    //meObject circleObject;
    //public CircleCollider2D circleObject;
    void OnMouseDown()
    {
        Destroy(this.gameObject);
    }
    //bool onTouch()
    //{
    //    if (circleObject!=)
    //    {

    //    }
    //        return true;
    //}
}
