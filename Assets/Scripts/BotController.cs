using UnityEngine;

public class BotController : MonoBehaviour
{
    public Transform bola;
    public float kecepatan = 3f;

    public float batasKiri = -8f;
    public float batasKanan = 8f;
    public float batasAtas = 4f;
    public float batasBawah = -4f;

    private Vector3 targetPosition;
    private float waktuUpdateTarget = 0.4f;
    private float timer;

    private bool modeKejarBola = true;
    private float waktuGantiMode = 2f;
    private float modeTimer;

    void Start()
    {
        targetPosition = transform.position;
        timer = waktuUpdateTarget;
        modeTimer = waktuGantiMode;
    }

    void Update()
    {
        // Ganti mode (ngejar bola / random) tiap beberapa detik
        modeTimer -= Time.deltaTime;
        if (modeTimer <= 0f)
        {
            modeKejarBola = Random.value > 0.4f; // 60% kejar bola, 40% random
            modeTimer = waktuGantiMode;
        }

        // Update posisi target dalam jeda tertentu
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            if (modeKejarBola && bola != null)
            {
                targetPosition = bola.position;
                targetPosition.y += Random.Range(-0.5f, 0.5f);
                targetPosition.x += Random.Range(-0.3f, 0.3f);
            }
            else
            {
                // Mode random: pilih posisi acak dalam batas
                targetPosition = new Vector3(
                    Random.Range(batasKiri, batasKanan),
                    Random.Range(batasBawah, batasAtas),
                    transform.position.z
                );
            }

            timer = waktuUpdateTarget;
        }

        // Gerak ke target
        Vector3 posisiBot = Vector3.MoveTowards(transform.position, targetPosition, kecepatan * Time.deltaTime);
        posisiBot.x = Mathf.Clamp(posisiBot.x, batasKiri, batasKanan);
        posisiBot.y = Mathf.Clamp(posisiBot.y, batasBawah, batasAtas);
        transform.position = posisiBot;
    }
}
