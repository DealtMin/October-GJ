using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteScroller : MonoBehaviour
{
    [Header("UV/сек")]
    public float speedX = 0.1f;
    public float speedY = 0f;

    private Material _mat;
    private Vector2 _offset;

    void Awake()
    {
        var sr = GetComponent<SpriteRenderer>();
        _mat = new Material(sr.sharedMaterial);
        sr.material = _mat;
    }

    void Update()
    {
        _offset.x += speedX * Time.deltaTime;
        _offset.y += speedY * Time.deltaTime;
        _mat.mainTextureOffset = _offset;
    }

    void OnDestroy()
    {
        if (_mat != null) Destroy(_mat);
    }
}