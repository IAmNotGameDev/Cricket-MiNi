using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Fpscounter : MonoBehaviour
{
    [SerializeField]  TextMeshProUGUI fpsTEXT;
    [SerializeField] private float _hudRefreshRate = 1f;

    private float _timer;
    private void Start()
    {
        Application.targetFrameRate = 300;
    }
    private void Update()
    {
        if (Time.unscaledTime > _timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            fpsTEXT.text = "FPS: " + fps;
            _timer = Time.unscaledTime + _hudRefreshRate;
        }
    }
}