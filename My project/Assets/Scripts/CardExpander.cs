using UnityEngine;
using UnityEngine.EventSystems;

public class CardExpander : MonoBehaviour, IPointerClickHandler
{
    //public RectTransform expandedCardLocation; //posto in cui mettere la carta quando espansa
    private Vector3 initialScale; // La scala vera originale, salvata solo una volta
    private Vector3 originalScale; // La scala a cui torni quando chiudi
    private Vector3 initialPosition;
    public bool isExpanded { private set; get; }

    public float expandedScale = 1.5f;
    public float animationSpeed = 10f;

    private Coroutine scaleCoroutine;

    private void Start()
    {
        initialScale = transform.localScale;
        initialPosition = transform.position;

        originalScale = initialScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isExpanded = !isExpanded;

        // Definisci la scala di ritorno quando viene cliccato
        Vector3 targetScale = isExpanded ? initialScale * expandedScale : new Vector3(16f, 16f, 1f);

        Vector3 targetPosition = isExpanded ? new Vector3(920, 540, 1f) : initialPosition;



        if (isExpanded)
        {
            transform.SetAsLastSibling(); // Mette la carta in primo piano (opzionale)
            initialPosition = transform.position;
        }

        if (scaleCoroutine != null)
            StopCoroutine(scaleCoroutine);

        scaleCoroutine = StartCoroutine(AnimateScale(targetScale, targetPosition));
    }

    private System.Collections.IEnumerator AnimateScale(Vector3 targetScale, Vector3 targetPosition)
    {
        // Anima fino a che la carta non raggiunge la scala target
        while (Vector3.Distance(transform.localScale, targetScale) > 0.01f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * animationSpeed);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * animationSpeed);
            yield return null;

        }

        // Assicurati che la carta arrivi alla scala target esatta
        transform.localScale = targetScale;
        transform.position = targetPosition;
    }
}




