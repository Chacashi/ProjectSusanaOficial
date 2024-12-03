using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
abstract public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected AudioClipSO audioClip;
    protected Button myButton;
    protected Vector3 initialScale;
    [SerializeField] protected float timeScale;
    [SerializeField] protected Vector3 toScale;

    protected virtual void Awake()
    {
        myButton = GetComponent<Button>();
    }

    protected virtual void Start()
    {
        initialScale = transform.localScale;
        myButton.onClick.AddListener(Interactue);

    }
    protected abstract void Interactue();
    protected virtual void Scale(Vector3 toScale)
    {
        transform.DOScale(toScale, timeScale);
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        Scale(toScale);
        audioClip.PlayOneShoot();

    }
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        Scale(initialScale);

    }





}