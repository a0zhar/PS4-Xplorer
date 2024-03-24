using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesAvanzadas : MonoBehaviour {
    private int Opcion = 0;
    private bool Paso = true;

    public GameObject[] MisOpciones = new GameObject[2];

    public void OnDisable() {
        Opcion = 0;
        MisOpciones[0].transform.GetChild(0).gameObject.SetActive(true);
        MisOpciones[1].transform.GetChild(0).gameObject.SetActive(false);
        //MisOpciones[2].transform.GetChild(0).gameObject.SetActive(false);
    }

    private void Update() {
        if ((Input.GetAxis("dpad1_vertical") > 0 || Input.GetKey(KeyCode.UpArrow)) && Opcion > 0 && Paso) {
            Paso = false;

            MisOpciones[Opcion].transform.GetChild(0).gameObject.SetActive(false);
            Opcion--;
            MisOpciones[Opcion].transform.GetChild(0).gameObject.SetActive(true);

            StartCoroutine(SeguirPasando());
        }

        if ((Input.GetAxis("dpad1_vertical") < 0 || Input.GetKey(KeyCode.DownArrow)) && Opcion < 1 && Paso) {
            Paso = false;

            MisOpciones[Opcion].transform.GetChild(0).gameObject.SetActive(false);
            Opcion++;
            MisOpciones[Opcion].transform.GetChild(0).gameObject.SetActive(true);

            StartCoroutine(SeguirPasando());
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button0) || 
            Input.GetKeyDown(KeyCode.Keypad2)) {
            if (Opcion == 0) {
                Controlador.instancia.ActivarFTP();
            } else if (Opcion == 1) {
                Controlador.instancia.ActivarFullRW();
            }
            //case 2:
            //    Controlador.instancia.ExportarPFS_Map();
            //    break;
        }
    }

    private IEnumerator SeguirPasando() {
        yield return new WaitForSeconds(0.2f);
        Paso = true;
    }
}
