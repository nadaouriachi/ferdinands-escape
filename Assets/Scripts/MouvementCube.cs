using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementCube : MonoBehaviour
{
    private float vitesseRotation;
    private Vector3 axeRotation;

    // Start is called before the first frame update
    void Start()
    {
        vitesseRotation = 25.0f;
        axeRotation = new Vector3(1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Cube tourne sur lui-meme sur un axe diagonal
        float angle = vitesseRotation * Time.deltaTime;
        transform.Rotate(axeRotation, angle);
    }
}
