using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiChiMovement : MonoBehaviour
{
    // Serialized Fields
    [SerializeField] 
    float moveSpeed = 7.5f;

    [SerializeField]
    Transform spriteTransform;

    // Private Variables
    private Vector3 moveInput;

    private void Update()
    {
        GetInput();

        MoveCharacter();
    }

    private void MoveCharacter()
    {
        gameObject.transform.position += moveInput * moveSpeed * Time.deltaTime;

        spriteTransform.transform.localScale = new Vector3(-1 * Mathf.Sign(moveInput.x), 1, 1);
    }

    private void GetInput()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = 0;
        moveInput.z = 0;

        if (moveInput.sqrMagnitude > 1f)
        {
            moveInput.Normalize();
        }
    }
}
