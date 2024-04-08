using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    void Start() {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier; }

    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            playerRb.AddForce(Vector3.up *jumpForce, ForceMode.Impulse); } }
}
