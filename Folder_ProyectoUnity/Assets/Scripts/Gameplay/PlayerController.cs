
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;


public class PlayerController : MonoBehaviour
{


    [SerializeField] float speed;
    Rigidbody _compRigidbody;
    private Vector2 direction;

    private void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {

        _compRigidbody.velocity = new Vector3(speed * direction.x, _compRigidbody.velocity.y, direction.y * speed);
    }



    void GetInputMovement(Vector2 direction)
    {
        this.direction = direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.gameObject.tag == "Matematicas")
        {
            SceneManager.LoadScene("Matematicas");
        }

        if (other != null && other.gameObject.tag == "Ciencias")
        {
            SceneManager.LoadScene("Ciencias");
        }

        if (other != null && other.gameObject.tag == "Letras")
        {
            SceneManager.LoadScene("Letras");
        }
    }
    private void OnEnable()
    {
        InputReaderGameplay.GetValueMovement += GetInputMovement; 
    }
    private void OnDisable()
    {
        InputReaderGameplay.GetValueMovement -= GetInputMovement;
    }




}
