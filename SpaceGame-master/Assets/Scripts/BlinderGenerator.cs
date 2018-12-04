using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinderGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject[] blinders;
    Vector3[] efeito = new Vector3[2];
    Vector3 primeiro;
    Vector3 segundo;
    public float temp = 1.2f;
    public float time;
    public static bool primeiroOn = false;
    public static bool segundoOn = false;



    // Use this for initialization
    void Start()
    {
        primeiro = new Vector3(1.6f, 0, 17.36f);
        segundo = new Vector3(0, 0, 4.03f);
        efeito[0] = primeiro;
        efeito[1] = segundo;
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.highSpeed == true)
        {
            primeiroOn = true;
            if (primeiroOn == true)
            {
                Instantiate(blinders[0], efeito[0], transform.rotation);
                temp = time + temp;
                primeiroOn = false;
            }
            else if (primeiroOn == false && segundoOn == true)
            {
                SegundoOn();
                Instantiate(blinders[1], efeito[1], transform.rotation);
            }
        }
    }
    public void PrimeiroOn ()
    {
        primeiroOn = true;
        StartCoroutine(PrimeiroDownRoutine());
    }
    public IEnumerator PrimeiroDownRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        primeiroOn = false;
    }
    public void SegundoOn()
    {
        segundoOn = true;
        StartCoroutine(SegundoDownRoutine());
    }
    public IEnumerator SegundoDownRoutine()
    {
        yield return new WaitForSeconds(2.0f);
        segundoOn = false;
    }
}