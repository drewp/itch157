using UnityEngine;

public class Shake : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        var rt = GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(
             Mathf.PerlinNoise(speed * Time.realtimeSinceStartup, 0.2f),
             Mathf.PerlinNoise(.3f, speed * Time.realtimeSinceStartup)
        );
    }
}
