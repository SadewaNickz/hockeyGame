using UnityEngine;

public class MunculLiga : MonoBehaviour
{
    public float jeda = 0.8f;
    float timer;
    public GameObject[] obyekLiga;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > jeda)
        {
            int random = Random.Range(0, obyekLiga.Length);
            Instantiate (obyekLiga [random], transform.position,
            transform.rotation);
            timer = 0;
        }
    }
}
