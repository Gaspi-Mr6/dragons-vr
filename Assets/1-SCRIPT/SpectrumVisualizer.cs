using UnityEngine;

public class AmplitudeWaveVisualizer : MonoBehaviour
{
    public AudioSource audioSource;
    public RectTransform[] bars;
    public float scale = 300f;
    public float smoothSpeed = 10f;

    private float[] samples = new float[256];
    private float[] values; // historial de amplitudes

    void Start()
    {
        values = new float[bars.Length];
    }

    void Update()
    {
        // --- Obtener amplitud RMS (volumen global) ---
        audioSource.GetOutputData(samples, 0);
        float sum = 0f;
        for (int i = 0; i < samples.Length; i++)
            sum += samples[i] * samples[i];
        float amplitude = Mathf.Sqrt(sum / samples.Length) * scale;

        // --- Desplazar los valores hacia la derecha ---
        for (int i = values.Length - 1; i > 0; i--)
            values[i] = values[i - 1];

        // Nuevo valor en la primera barra
        values[0] = amplitude;

        // --- Actualizar todas las barras con suavizado ---
        for (int i = 0; i < bars.Length; i++)
        {
            float newHeight = Mathf.Lerp(bars[i].sizeDelta.y, values[i], Time.deltaTime * smoothSpeed);
            bars[i].sizeDelta = new Vector2(bars[i].sizeDelta.x, Mathf.Clamp(newHeight, 2f, scale));
        }
    }
}
