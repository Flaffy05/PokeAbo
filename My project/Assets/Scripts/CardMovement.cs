using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 originalLocalPointerPosition;
    private Vector3 originalPanelLocalPosition;
    private Vector3 originalScale;
    private int currentState = 0;
    private Quaternion originalRotation;
    private Vector3 originalPosition;

    [SerializeField] private float selectScale = 1.1f;
    [SerializeField] private Vector2 cardPlay;
    [SerializeField] private Vector3 playPosition = Vector3.zero;
    [SerializeField] private GameObject glowEffect;
    [SerializeField] private GameObject playArrow;

    private bool isPlayed = false; // FLAG per bloccare la carta

    void Awake()
    {
        glowEffect.SetActive(false);
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        originalScale = rectTransform.localScale;
        originalPosition = rectTransform.localPosition;
        originalRotation = rectTransform.localRotation;
    }

    void Update()
    {
        if (isPlayed) return; // Blocca tutto se la carta è giocata

        switch (currentState)
        {
            case 1:
                HandleHoverState();
                break;
            case 2:
                HandleDragState();
                break;
            case 3:
                HandlePlayState();
                break;
        }

        // Controlla rilascio tasto sinistro del mouse
        if (Input.GetMouseButtonUp(0))
        {
            // Se non hai giocato la carta, torna allo stato 0
            if (!isPlayed && currentState != 0)
            {
                TransitionToState0();
            }
        }
    }

    private void TransitionToState0()
    {
        currentState = 0;
        rectTransform.localScale = originalScale;
        rectTransform.localRotation = originalRotation;
        rectTransform.localPosition = originalPosition;
        glowEffect.SetActive(false);
        playArrow.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currentState == 0 && !isPlayed)
        {
            originalPosition = rectTransform.localPosition;
            originalRotation = rectTransform.localRotation;
            originalScale = rectTransform.localScale;
            currentState = 1;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (currentState == 1 && !isPlayed)
        {
            TransitionToState0();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (currentState == 1 && !isPlayed)
        {
            currentState = 2;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out originalLocalPointerPosition);
            originalPanelLocalPosition = rectTransform.localPosition;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (currentState != 2 || isPlayed) return; // Blocca il drag se è già giocata

        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out localPointerPosition))
        {
            rectTransform.position = Input.mousePosition;

            if (rectTransform.localPosition.y > cardPlay.y)
            {
                // GIOCA LA CARTA
                PlayCard();
            }
        }
    }

    private void HandleHoverState()
    {
        glowEffect.SetActive(true);
    }

    private void HandleDragState()
    {
        rectTransform.localRotation = Quaternion.identity;
    }

    private void HandlePlayState()
    {
        // Non fa più niente perché la carta è già giocata
    }

    private void PlayCard()
    {
        currentState = 3;
        isPlayed = true; // BLOCCA definitivamente
        playArrow.SetActive(false);
        glowEffect.SetActive(false);

        // Sistema posizione e rotazione definitiva
        rectTransform.localPosition = playPosition;
        rectTransform.localRotation = Quaternion.identity;

        // (Opzionale) Disabilita lo script se vuoi proprio fermare tutto
        // this.enabled = false;
    }
}

