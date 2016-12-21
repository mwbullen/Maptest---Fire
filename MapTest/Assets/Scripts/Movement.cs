using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	// Use this for initialization

	NavMeshAgent myNavMeshAgent ;
	void Start () {
		myNavMeshAgent = gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void NavtoPoint(Vector3 targetLocation) {
		myNavMeshAgent.SetDestination (targetLocation);
	}
}
