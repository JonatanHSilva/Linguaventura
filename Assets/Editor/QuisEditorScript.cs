using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

[CustomEditor(typeof(QuisScript))]
public class QuisEditorScript : Editor
{
    bool pWindow = true;
    bool unityInspector = false;
    [SerializeField]
    QuisScript quis;
    private void OnEnable()
    {

        quis = (QuisScript)target;
    }
    public override void OnInspectorGUI()
    {
        

        quis.PainelRespostas = (GameObject)EditorGUILayout.ObjectField("OBJ Painel de Respostas", quis.PainelRespostas, typeof(GameObject), true);
        quis.Pergunta = (TextMeshProUGUI)EditorGUILayout.ObjectField("TMP Pergunta", quis.Pergunta, typeof(TextMeshProUGUI), true);
        quis.buttonCerto = (GameObject)EditorGUILayout.ObjectField("Prefab Buttão Certo", quis.buttonCerto, typeof(GameObject), true);
        quis.buttonErrado = (GameObject)EditorGUILayout.ObjectField("Prefab Buttão Errado", quis.buttonErrado, typeof(GameObject), true);
        GUILayout.Space(10);

        GUILayout.Label("Nome do arquivo:");
        quis.fileName = GUILayout.TextField(quis.fileName);
        GUILayout.Label("Proximo level:");
        quis.ProximoLevel = GUILayout.TextField(quis.ProximoLevel);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Salvar"))
        {
            if (EditorUtility.DisplayDialog("Load", "O arquivo " + quis.fileName + ".json sera salvo da pasta " + Application.dataPath + "/data/", "Salvar", "Cancelar"))
            {
                if (!quis.SalvarPerguntas()) { EditorUtility.DisplayDialog("Erro!", "Não foi possivel Salvar o arquivo", "Ok"); }
            }

        }
        if (GUILayout.Button("Load"))
        {
            if (EditorUtility.DisplayDialog("Load", "O arquivo " + quis.fileName + ".json sera carregado da pasta " + Application.dataPath + "/data/", "Confirmar", "Cancelar"))
            {
                if (!quis.LoadPerguntas()) { EditorUtility.DisplayDialog("Erro!", "Não foi possivel Abrir o arquivo", "Ok"); }
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(10);
        pWindow = EditorGUILayout.Foldout(pWindow, "Perguntas:");
        if (pWindow)
        {
            foreach (Pergunta pergunta in quis.perguntas)
            {
                GUILayout.Space(10);
                pergunta.pergunta = GUILayout.TextArea(pergunta.pergunta);

                GUILayout.BeginHorizontal();
                GUILayout.Label("Quantidade de respostas: " + pergunta.qtdRespostas.ToString());
                if (GUILayout.Button("2")) { pergunta.qtdRespostas = 2; }
                if (GUILayout.Button("3")) { pergunta.qtdRespostas = 3; }
                if (GUILayout.Button("4")) { pergunta.qtdRespostas = 4; }
                GUILayout.EndHorizontal();
                GUILayout.Label("Resposta Certa:");
                pergunta.respostaCerta = GUILayout.TextField(pergunta.respostaCerta);
                GUILayout.Label("Respostas Erradas:");
                pergunta.respostaErradaA = GUILayout.TextField(pergunta.respostaErradaA);
                if (pergunta.qtdRespostas > 2) pergunta.respostaErradaB = GUILayout.TextField(pergunta.respostaErradaB);
                if (pergunta.qtdRespostas > 3) pergunta.respostaErradaC = GUILayout.TextField(pergunta.respostaErradaC);
                GUILayout.Space(10);
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Deletar"))
                {
                    if (EditorUtility.DisplayDialog("Tem Certeza?", "A pergunta: " + pergunta.pergunta + " sera deletada permanentimente!", "Deletar", "Cancelar"))
                        quis.perguntas.Remove(pergunta);
                }
                GUILayout.EndHorizontal();
            }
        }
        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Nova Pergunta")) quis.perguntas.Add(new Pergunta());
        if (GUILayout.Button("Limpar Perguntas"))
        {
            if (EditorUtility.DisplayDialog("Tem Certeza?", "Todas as perguntas serão deletadas", "Deletar", "Cancelar"))
            {
                quis.perguntas = new List<Pergunta>();
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(10);

        unityInspector = EditorGUILayout.Foldout(unityInspector, "Componete Original");
        EditorUtility.SetDirty(quis);
        if (unityInspector) base.OnInspectorGUI();
    }

}
