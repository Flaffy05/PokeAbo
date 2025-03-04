using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(DeckManager))]
public class DeckManagerEditor : Editor
{
    public override void OnInspectorGUI(){
        DrawDefaultInspector();

        DeckManager deckManager = (DeckManager)target;
        if(GUILayout.Button("Pesca una carta")){
            HandManager handManager = FindObjectOfType<HandManager>();
            if(handManager != null){
                deckManager.DrawCard(handManager);
            }
        }
    }
}
#endif
