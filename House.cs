using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, .5f);
    }
}
