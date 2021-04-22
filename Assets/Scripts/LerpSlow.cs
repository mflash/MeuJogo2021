using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpSlow : MonoBehaviour
{
    public float speed;
    
    // Distância máxima para o efeito de slow e troca de cor
    public float maxDist = 4f;
    public Transform target;
    public Transform other;
    private Vector3 start;
    private float currentTime;
    private float totalTime;
    private Material mat;
    
    // cor original (para interpolar com o cinza)
    private Color original;
    
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        // Salva a cor original
        original = mat.color;  
        ResetPos();
    }

    void ResetPos()
    {
        start = transform.position;
        float distance = Vector3.Distance(start, target.position);
        currentTime = 0f;
        totalTime = distance / speed;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, target.position);
        if(dist < 0.1f) {
            float x = Random.Range(-4.5f, 4.5f);
            float z = Random.Range(-4.5f, 4.5f);
            target.position = new Vector3(x, 
                transform.position.y, z);
            ResetPos();
            //mat.color = Color.gray;
        }

        float current = currentTime/totalTime;

        // Ease out:
        float t = current;
        //t = Mathf.Sin(current * Mathf.PI * 0.5f);
        // Ease in:
        //t = 1 - Mathf.Cos(current * Mathf.PI * 0.5f);
        // Smoothstep
        t = t*t * (3f - 2f*t);

        Vector3 newPos = Vector3.Lerp(start, target.position, t);
        transform.position = newPos;
        float distOther = Vector3.Distance(transform.position,
            other.position);

        // localSpeed é um fator de ajuste, de forma que
        // se possa aplicar uma "escala" à velocidade atual
        float localSpeed = 1f;

        if(distOther < maxDist) {            
            localSpeed = distOther/maxDist;//0.2f;
        }
        mat.color = Color.Lerp(Color.yellow, original, localSpeed);         

        currentTime += localSpeed * Time.deltaTime;
    }

   /*
    void OnGUI()
    {
        string pos = string.Format("{0}",
            child.localPosition);              
        GUI.Label(new Rect(10, 30, 100, 20), pos);
    }
    */
}
