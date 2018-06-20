using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAuto : MonoBehaviour {

	public WheelCollider Llanta1;
	public WheelCollider Llanta2;
	public Transform Neumatico1;
	public Transform Neumatico2; 
	public Transform Neumatico3; 
	public Transform Neumatico4; 
	public int desaceleracion = 200;
	private int velocidadMaxima = 150;


	public double velocidad;
	public int aceleracion = 300;


	// Solo se ejecuta cuando se inicia
	void Start () {
		transform.GetComponent<Rigidbody>().centerOfMass = new Vector3(0,-1f,0);	// se pone el centro de masa en el -1 de y para que no se voltee
	}

	void Update(){
		//movimiento de las llantas hacia los costados
		Neumatico1.localEulerAngles = new Vector3 (0, Llanta1.steerAngle*2, 0);
		Neumatico2.localEulerAngles = new Vector3 (0, Llanta2.steerAngle*2, 0);
		//rotacion de las llantas
		Neumatico1.Rotate(new Vector3(Llanta1.rpm/60*360*Time.deltaTime/4,0,0));
		Neumatico2.Rotate(new Vector3(Llanta1.rpm/60*360*Time.deltaTime/4,0,0));
		Neumatico3.Rotate(new Vector3(Llanta1.rpm/60*360*Time.deltaTime/4,0,0));
		Neumatico4.Rotate(new Vector3(Llanta1.rpm/60*360*Time.deltaTime/4,0,0));
		velocidad= (2* 3.1416 * Llanta1.radius) * (Llanta1.rpm * 60/1000);			// perimetro * rpm * conversion a km/h de m/min
	}
	
	// Se ejecuta varias veces por segundo
	void FixedUpdate () {

		//Aceleracion del auto
		if (velocidad <= velocidadMaxima){
			//Aceleracion del auto
			Llanta1.motorTorque= aceleracion * Input.GetAxis("Vertical");
			Llanta2.motorTorque= aceleracion * Input.GetAxis("Vertical");
		}
		else {
			Llanta1.motorTorque= 0;
			Llanta2.motorTorque= 0;
		}

		

		//Rotacion del auto
		Llanta1.steerAngle = 10 * Input.GetAxis("Horizontal");
		Llanta2.steerAngle = 10 * Input.GetAxis("Horizontal");

		//Desaceleracion
		if (Input.GetAxis("Vertical")==0) {

			Llanta1.brakeTorque=desaceleracion;
			Llanta2.brakeTorque=desaceleracion;
		}

		else {

			Llanta1.brakeTorque=0;
			Llanta2.brakeTorque=0;
		}
	}
}
