using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAuto : MonoBehaviour {

	public WheelCollider llantaI;
	public WheelCollider llantaD;
	public Transform neumatico1;
	public Transform neumatico2; 
	public int desaceleracion = 80;
	private int velocidadMaxima = 100;


	public double velocidad;
	public int aceleracion = 100;


	// Solo se ejecuta cuando se inicia
	void Start () {
		//transform.rigidbody.centerOfMass = new Vector3(0,-1f,0);
	}

	void Update(){
		neumatico1.localEulerAngles = new Vector3 (0, llantaI.steerAngle, 0);
		neumatico2.localEulerAngles = new Vector3 (0, llantaD.steerAngle, 0);
		velocidad= (2* 3.1416 * llantaD.radius) * (llantaD.rpm * 60/1000);			// perimetro * rpm * conversion a km/h
	}
	
	// Se ejecuta varias veces por segundo
	void FixedUpdate () {

		//Aceleracion del auto
		if (velocidad <= velocidadMaxima){
			//Aceleracion del auto
			llantaI.motorTorque= aceleracion * Input.GetAxis("Vertical");
			llantaD.motorTorque= aceleracion * Input.GetAxis("Vertical");
		}
		else {
			llantaI.motorTorque= 0;
			llantaD.motorTorque= 0;
		}

		

		//Rotacion del auto
		llantaI.steerAngle = 7 * Input.GetAxis("Horizontal");
		llantaD.steerAngle = 7 * Input.GetAxis("Horizontal");

		//Desaceleracion
		if (Input.GetAxis("Vertical")==0) {

			llantaI.brakeTorque=desaceleracion;
			llantaD.brakeTorque=desaceleracion;
		}

		else {

			llantaI.brakeTorque=0;
			llantaD.brakeTorque=0;
		}
	}
}
