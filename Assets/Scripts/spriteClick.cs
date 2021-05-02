using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        TileMap tilemap = this.GetComponentInParent<TileMap>();
        Debug.Log("CLICK " + this.name);
        tilemap.SetValue(this.transform.position, this.gameObject);
    }
}
