using UnityEngine;
public class PaddleController : MonoBehaviour
{
public float batasAtas;
public float batasBawah;
public float batasKiri;
public float batasKanan;
public float kecepatan;
public string axis;
public string axisX;
// Use this for initialization
void Start()
{ }
// Update is called once per frame
void Update()
{
        float gerakY = Input.GetAxis(axis) * kecepatan * Time.deltaTime;
        float gerakX = Input.GetAxis(axisX) * kecepatan * Time.deltaTime;

        float nextPosY = transform.position.y + gerakY;
        float nextPosX = transform.position.x + gerakX;

        // Cek batas atas dan bawah
        if (nextPosY > batasAtas || nextPosY < batasBawah)
        {
            gerakY = 0;
        }

        // Cek batas kiri dan kanan
        if (nextPosX > batasKanan || nextPosX < batasKiri)
        {
            gerakX = 0;
        }

        transform.Translate(gerakX, gerakY, 0);
    }
}