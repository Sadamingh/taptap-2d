using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private SpriteRenderer _interactSprite;
    private Transform _playerTransform;
    [SerializeField] private const float INTERACT_DISTANCE = 4f; //distance between cat and Interactable NPCs

    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Cat").transform;
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && IsWithinInteractDistance())
        {
            //talk and interact
            Interact();
            Debug.Log("Test space pressed");
        }
        if (_interactSprite.gameObject.activeSelf && !IsWithinInteractDistance())
        {
            //turn off sprite
            _interactSprite.gameObject.SetActive(false);
        }
        else if (!_interactSprite.gameObject.activeSelf && IsWithinInteractDistance())
        {
            //turn on sprite
            _interactSprite.gameObject.SetActive(true);
            Debug.Log("Sprite Active.");
        }
    }
    public abstract void Interact();

    private bool IsWithinInteractDistance()
    {
        if (Vector2.Distance(_playerTransform.position, transform.position) < INTERACT_DISTANCE)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
