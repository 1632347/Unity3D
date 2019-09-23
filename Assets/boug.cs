using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boug : MonoBehaviour
{

    public float vitesseMarche = 2;
    public float vitesseCourse = 6;

    public float tamponTournee = 0.2f;
    private float velociteTourner;

    public float tamponVitesse = 0.1f;
    private float velociteVitesse;
    private float vitesseActuel;

    Animator animateur;
    Transform transformCamera;

    // Start is called before the first frame update
    void Start()
    {
        animateur = GetComponent<Animator>();
        transformCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float rotationVisee = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + transformCamera.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationVisee, ref velociteTourner, tamponTournee);

        }

        bool estCourse = Input.GetKey(KeyCode.LeftShift);
        float vitesseVisee = ((estCourse) ? vitesseCourse : vitesseMarche) * inputDir.magnitude;
        vitesseActuel = Mathf.SmoothDamp(vitesseActuel, vitesseVisee, ref velociteVitesse, tamponVitesse);


        transform.Translate(transform.forward * vitesseActuel * Time.deltaTime, Space.World);

        float vitesseAnimation = ((estCourse) ? 1 : 0.65f) * inputDir.magnitude;
        animateur.SetFloat("pourcentageVitesse", vitesseAnimation, tamponVitesse, Time.deltaTime);
    }
}

