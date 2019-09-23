using UnityEngine;
using System.Collections;
public class ThirdPersonCamera : MonoBehaviour
{
    public float Sensibilité = 10;
    public Transform cible;
    public float DistanceCible = 2;
    public Vector2 MaxAxeY = new Vector2(-40, 85);

    public float DelaiRotation = 0.3f;
    Vector3 VelociteRotation;
    Vector3 RotationActuel;

    float AxeX;
    float AxeY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        AxeX += Input.GetAxis("Mouse X");
        AxeY -= Input.GetAxis("Mouse Y");
        AxeY = Mathf.Clamp(AxeY, MaxAxeY.x, MaxAxeY.y);

        RotationActuel = Vector3.SmoothDamp(RotationActuel, new Vector3(AxeY, AxeX), ref VelociteRotation, DelaiRotation);

        //angle sur 360 degrès
        transform.eulerAngles = RotationActuel;

        transform.position = cible.position - transform.forward * DistanceCible;


    }
}