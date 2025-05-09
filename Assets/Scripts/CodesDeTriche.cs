using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodesDeTriche : MonoBehaviour
{
    public GameObject zonePortes;

    public MouvementFerdinand ferdinandScript;
    public GameManager managerScript;

    // Update is called once per frame
    void Update()
    {
        // Teleporter Ferdinand aux portes de sortie
        if (Input.GetKeyDown(KeyCode.T) && Time.timeScale != 0)
        {
            ferdinandScript.controleurMouvement.enabled = false;
            ferdinandScript.transform.position = zonePortes.transform.position;
            ferdinandScript.transform.rotation = Quaternion.LookRotation(new Vector3(0,0,1));
            ferdinandScript.controleurMouvement.enabled = true;
        }
        // Descendre le temps restant a 3 secondes
        if (Input.GetKeyDown(KeyCode.Y) && Time.timeScale != 0)
        {
            managerScript.tempsRestant = 3.0f;
        }
    }
}
