using UnityEngine;
using UnityEngine.UI;

public class GifRenderer : MonoBehaviour
{
    public Sprite[] Frames;
    
    private const float FramesPerSecond = 10f;

    private Image _image;
    private SpriteRenderer _render;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _render = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        var index = Time.time * FramesPerSecond;
        index %= Frames.Length;

        _image.sprite = Frames[(int)index];
    }
}