using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MouvementFerdinand : MonoBehaviour
{
    public float vitesse;
    public float vitesseRotation;

    public TMP_Text texte;
    private Animator _animator;
    public CharacterController controleurMouvement;
    public AudioSource sonCube;

    public OuverturePorte porteScript;
    public GameManager managerScript;



    // Start is called before the first frame update
    void Start()
    {
        controleurMouvement = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;

        // Ferdinand avance
        if (vertical != 0)
        {
            Vector3 vecteurVitesse = transform.forward * vitesse * vertical;
            controleurMouvement.SimpleMove(vecteurVitesse);
            _animator.SetBool("Marcher", true);
        }
        // Ferdinand s'immobilise
        else
        {
            _animator.SetBool("Marcher", false);
        }
        // Ferdinand tourne
        if (horizontal != 0)
        {
            transform.Rotate(0, horizontal * vitesseRotation, 0);
        }
        // Ferdinand n'a plus de temps
        if (managerScript.tempsRestant <= 0.0f)
        {
            Time.timeScale = 0;
            texte.text = "Vous avez été capturé...";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Ferdinand obtient un cube magnetique
        if (other.gameObject.tag == "Cube")
        {
            sonCube.Play();

            managerScript.tempsFurtif = 5.0f;
            other.gameObject.SetActive(false);
        }
        // Ferdinand se fait attraper par un robot
        if (other.gameObject.tag == "Chasseur" || other.gameObject.tag == "Patrouilleur")
        {
            Time.timeScale = 0;
            texte.text = "Vous avez été capturé...";
        }
        // Ferdinand atteint les portes de sortie
        if (other.gameObject.tag == "Zone portes")
        {
            porteScript.OuvrirPorte();
            other.gameObject.SetActive(false);
        }
        // Ferdinand atteint la zone de fin
        if (other.gameObject.tag == "Zone fin")
        {
            Time.timeScale = 0;
            texte.text = "Vous êtes libres !!!";
        }
    }
}
