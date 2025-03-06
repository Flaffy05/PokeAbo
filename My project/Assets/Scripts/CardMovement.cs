using UnityEngine;
using UnityEngine.EventSystems;


public class CardMovement : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 originalLocalPointerPosition;
    private Vector3 originalPanelLocalPosition;
    private Vector3 originalScale;
    private int currentState=0;
    private Quaternion originalRotation;
    private Vector3 originalPosition;

    [SerializeField] private float selectScale=1.1f;
    [SerializeField] private Vector2 cardPlay;
    [SerializeField] private Vector3 playPosition;
    [SerializeField] private GameObject glowEffect;
    [SerializeField] private GameObject playArrow;

    void Awake(){
        glowEffect.SetActive(false);
        rectTransform=GetComponent<RectTransform>();
        canvas=GetComponent<Canvas>();
        originalScale=rectTransform.localScale;
        originalPosition=rectTransform.localPosition;
        originalRotation=rectTransform.localRotation;
    }

    void Update(){
        switch(currentState){
            case 1:
                HandleHoverState();
                break;
            case 2:
                HanleDragState();
                if(!Input.GetMouseButton(0)){//controlla se clicco il mouse
                    TransitionToState0();
                } 
                break;
            case 3:
                HandlePlayState();
                break;
        }
    }

    private void TransitionToState0(){
        currentState=0;
        //resetta
        rectTransform.localScale=originalScale;
        rectTransform.localRotation=originalRotation;
        rectTransform.localPosition=originalPosition;
        glowEffect.SetActive(false); //non metti il glow
        playArrow.SetActive(false); 
    }

    public void OnPointerEnter(PointerEventData eventData){
        if(currentState==0){
            originalPosition=rectTransform.localPosition;
            originalRotation=rectTransform.localRotation;
            originalScale=rectTransform.localScale;
            currentState=1;
        }
    }

    public void OnPointerExit(PointerEventData eventData){
        if(currentState==1){
            TransitionToState0();
        }        
    }

    public void OnPointerDown(PointerEventData eventData){
        if(currentState == 1){
            currentState=2;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(),eventData.position,eventData.pressEventCamera,out originalLocalPointerPosition);
            originalPanelLocalPosition=rectTransform.localPosition;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (currentState == 2)
        {
            Vector2 localPointerPosition;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out localPointerPosition))
            {
                rectTransform.position = Input.mousePosition;

                if (rectTransform.localPosition.y > cardPlay.y)
                {
                    currentState = 3;
                    playArrow.SetActive(true);
                    rectTransform.localPosition = playPosition;
                }
            }
        }
    }

    private void HandleHoverState(){
        glowEffect.SetActive(true);
        rectTransform.localScale=originalScale;

    }

    private void HanleDragState(){
        //set the card rotation to 0
        rectTransform.localRotation=Quaternion.identity;
    }
    
    private void HandlePlayState(){
        rectTransform.localPosition=playPosition;
        rectTransform.localRotation=Quaternion.identity;
        if(Input.mousePosition.y<cardPlay.y){
            currentState=2;
            playArrow.SetActive(false);
        }
    }
}