using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(QuisEditScript))]
public class QuisEditEditor : Editor
{
    QuisEditScript quis;
    private void OnEnable()
    {

        quis = (QuisEditScript)target;
    }
    public override void OnInspectorGUI()
    {

        quis.perguntaUIPrefab = (GameObject)EditorGUILayout.ObjectField("Prefab Pergunta UI", quis.perguntaUIPrefab, typeof(GameObject), true);
        quis.painel = (GameObject)EditorGUILayout.ObjectField("Painel De Perguntas", quis.painel, typeof(GameObject), true);
        quis.novaPerguntaBtn = (Button)EditorGUILayout.ObjectField("Butão Nova Pergunta", quis.novaPerguntaBtn, typeof(Button), true);
        quis.salvarBtn = (Button)EditorGUILayout.ObjectField("Butão Salvar", quis.salvarBtn, typeof(Button), true);
        quis.voltarBtn = (Button)EditorGUILayout.ObjectField("Butão Voltar", quis.voltarBtn, typeof(Button), true);
        quis.scroll = (Scrollbar)EditorGUILayout.ObjectField("Scroll bar", quis.scroll, typeof(Scrollbar), true);
        GUILayout.Label("Nome do arquivo:");
        quis.fileName = GUILayout.TextField(quis.fileName);
        GUILayout.Label("Cena a Voltar:");
        quis.sceneToLoad = GUILayout.TextField(quis.sceneToLoad);
    }
}