using UnityEngine;
using System.Collections;

public class AiController : MonoBehaviour {
    private enum AIState {Searching, Walking, Chasing, Idle, Flee};
    AIState AState;
	// Use this for initialization
	void Start () {
        //Instance Refrences:
        //Check position and if there is no player nearby. walk default route.
        AState = AIState.Walking;
        Debug.Log("Ai is currently "+AState);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
