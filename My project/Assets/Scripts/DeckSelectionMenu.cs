using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeckSelectionMenu : MonoBehaviour
{
    public DeckManager deckManager; // Il manager per il mazzo
    public Button deckButtonPrefab; // Prefab del pulsante
    public Transform buttonContainer; // Il contenitore in cui mettere i pulsanti
    public string[] deckNames; // Lista dei nomi dei mazzi
    public GameObject panel; // Il pannello da eliminare dopo la selezione

    private Button[] buttons; // Array per memorizzare i pulsanti

    void Start()
    {
        if (deckButtonPrefab == null)
        {
            Debug.LogError("deckButtonPrefab non è stato assegnato!");
            return;
        }

        if (buttonContainer == null)
        {
            Debug.LogError("buttonContainer non è stato assegnato!");
            return;
        }

        if (deckNames.Length == 0)
        {
            Debug.LogError("Non sono stati assegnati i nomi dei mazzi!");
            return;
        }

        // Creare un array per memorizzare i pulsanti
        buttons = new Button[deckNames.Length];

        // Creare un pulsante per ogni mazzo
        for (int i = 0; i < deckNames.Length; i++)
        {
            Button newButton = Instantiate(deckButtonPrefab, buttonContainer);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = deckNames[i]; // Assegna il nome del mazzo al pulsante
            int index = i; // Cattura l'indice per la corretta selezione
            newButton.onClick.AddListener(() => OnDeckSelected(newButton, deckNames[index])); // Aggiungi listener al pulsante
            buttons[i] = newButton; // Memorizza il pulsante nell'array
        }
        Destroy(deckButtonPrefab);
    }

    // Quando un mazzo viene selezionato
    public void OnDeckSelected(Button selectedButton, string deckName)
    {
        // Carica il mazzo selezionato nel DeckManager
        deckManager.LoadDeck(deckName);

        // Disabilita tutti i pulsanti
        foreach (Button button in buttons)
        {
            button.interactable = false; // Disabilita il pulsante
        }

        // Elimina completamente il pannello e tutti i suoi figli
        if (panel != null)
        {
            Destroy(panel); // Distrugge il pannello e tutti i suoi componenti
        }

        // (Opzionale) Nascondere il pulsante selezionato o disabilitarlo visivamente
        selectedButton.gameObject.SetActive(false); // Nasconde il pulsante selezionato (opzionale)
        Destroy(panel);
    }
}



