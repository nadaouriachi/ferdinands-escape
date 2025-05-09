using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text txtTemps;
    public TMP_Text etat;
    public GameObject fenetre;
   
    public float tempsRestant;
    public float tempsFurtif;

    public GameObject ferdinand;
    public GameObject[] robots;

    public bool estVisible;

    // Start is called before the first frame update
    void Start()
    {
        fenetre.gameObject.SetActive(false);
        tempsRestant = 180.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Actualiser l'horloge
        tempsRestant -= Time.deltaTime;
        if (tempsRestant > 0.0f)
        {
            int minutes = Mathf.RoundToInt(tempsRestant) / 60;
            int secondes = Mathf.RoundToInt(tempsRestant) % 60;
            txtTemps.text = minutes.ToString("00") + ":" + secondes.ToString("00");

        }
        else
        {
            txtTemps.text = "00:00";
        }

        // Actualiser le temps furtif fourni par le cube magnetique
        tempsFurtif -= Time.deltaTime;

        // Verifier la visibilite du joueur par au moins un robot
        bool estVisible = false;
        for (int i = 0; i < robots.Length; i++)
        {
            if (Utilitaires.ObjetVisible(robots[i], ferdinand, 80.0f, 25.0f))
            {
                estVisible = true;
                break;
            }
        }

        // Mettre a jour tous les robots selon la visibilite du joueur
        for (int i = 0; i < robots.Length; i++)
        {
            MouvementRobot robotScript = robots[i].GetComponent<MouvementRobot>();

            if (estVisible && tempsFurtif <= 0.0f)
            {
                robotScript.DemarrerChasse();
                etat.text = "Détecté";
            }
            else
            {
                robotScript.ArreterChasse();
                etat.text = "Furtif";
            }
        }

        // Afficher la fenetre quand le jeu est fini
        if (Time.timeScale == 0)
        {
            fenetre.gameObject.SetActive(true);
        }

    }
    public void Rejouer()
    {
        // Recommencer le temps
        Time.timeScale = 1;
        tempsRestant = 180.0f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        fenetre.gameObject.SetActive(false);
    }
}
   
