using UnityEngine;
using UnityEngine.EventSystems;

public class DragUIObject : MonoBehaviour, IDragHandler, IPointerDownHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 originalLocalPointerPosition;
    private Vector3 originalPanelLocalPosition;
    public float movementSensitivity = 1.0f;
    private CardDisplay cardDisplay;

    private Transform originalParent;
    private bool isInSlot = false; // Nuova variabile per tracciare se la carta è dentro uno slot.

    private HandManager handManager; // Aggiungi il riferimento al HandManager

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        cardDisplay = GetComponent<CardDisplay>();
        handManager = FindObjectOfType<HandManager>(); // Trova il HandManager nella scena
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out originalLocalPointerPosition
        );

        originalPanelLocalPosition = rectTransform.localPosition;
        originalParent = transform.parent;
    }




    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.localScale = new Vector3(16f, 16f, 1f);

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localPointerPosition))
        {
            Vector2 offset = localPointerPosition - originalLocalPointerPosition;
            rectTransform.localPosition = originalPanelLocalPosition + (Vector3)offset;
        }
    }





    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject[] allSlots = GameObject.FindGameObjectsWithTag("Slot");

        foreach (GameObject slot in allSlots)
        {
            // Se lo slot è uno di quelli proibiti, salta
            string slotName = slot.name;
            if (slotName == "OpponentBench1" || slotName == "OpponentBench2" || slotName == "OpponentBench3" || slotName == "OpponentActiveCard")
            {
                continue;
            }

            RectTransform slotRect = slot.GetComponent<RectTransform>();

            if (RectTransformUtility.RectangleContainsScreenPoint(slotRect, Input.mousePosition, eventData.pressEventCamera))
            {
                string cardType = cardDisplay.cardData.element.name.ToLower();

                bool canPlace =
                    (slotName == "Support" && cardType == "supporto") ||
                    (slotName != "Support" && cardType != "supporto");

                if (canPlace && slot.transform.childCount == 0)
                {
                    // La carta è posizionata nello slot, quindi viene bloccata
                    transform.SetParent(slot.transform);
                    rectTransform.position = slotRect.position;

                    rectTransform.localScale = new Vector3(16f, 16f, 1f);
                    rectTransform.sizeDelta = new Vector2(-1.5f, -0.5f);

                    isInSlot = true; // Carta messa nello slot

                    // Rimuovi la carta dalla mano tramite il HandManager
                    handManager.RemoveCardFromHand(gameObject);

                    return;
                }
            }
        }
    // Nessuno slot valido → torna alla posizione originale
    rectTransform.localPosition = originalPanelLocalPosition;
    }
    
    // Funzione per permettere di rimuovere la carta dallo slot, se necessario.
    public void RemoveFromSlot()
    {
        isInSlot = false;
        transform.SetParent(originalParent);
    }
}






