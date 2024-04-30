using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMover : MonoBehaviour
{
    private RawImage image;
    [SerializeField] private float _x = 1f;
    [SerializeField] private float _y = 1f;

    public RawImage Image
    {
        get
        {
            if (image == null)
                image = GetComponent<RawImage>();
            return image;
        }
    }

    void Update()
    {
        Image.uvRect = new Rect(Image.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, Image.uvRect.size);
    }
}
