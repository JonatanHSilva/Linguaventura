using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StageCompletedScript : MonoBehaviour
{
    public Tile tileFase1, tileFase2part1, tileFase2part2, tileFase3part1, tileFase3part2, tileFase4;
    public Tilemap mapa;

    SetFaseScript setFase;

    Vector3Int posicaoTile;
    int fase;
    // Start is called before the first frame update
    void Start()
    {
        setFase = FindObjectOfType<SetFaseScript>();
        fase = setFase.GetFase();
        switch (fase)
        {
            case 1:
                posicaoTile = new Vector3Int(-1, -13);
                mapa.SetTile(posicaoTile, tileFase2part1);
                posicaoTile = new Vector3Int(0, -13);
                mapa.SetTile(posicaoTile, tileFase2part1);
                posicaoTile = new Vector3Int(1, -13);
                mapa.SetTile(posicaoTile, tileFase2part1); 
                posicaoTile = new Vector3Int(-1, -14);
                mapa.SetTile(posicaoTile, tileFase2part2);
                posicaoTile = new Vector3Int(0, -14);
                mapa.SetTile(posicaoTile, tileFase2part2);
                posicaoTile = new Vector3Int(1, -14);
                mapa.SetTile(posicaoTile, tileFase2part2); 

                posicaoTile = new Vector3Int(-1, 14);
                mapa.SetTile(posicaoTile, tileFase3part1);
                posicaoTile = new Vector3Int(0, 14);
                mapa.SetTile(posicaoTile, tileFase3part1);
                posicaoTile = new Vector3Int(1, 14);
                mapa.SetTile(posicaoTile, tileFase3part1);
                posicaoTile = new Vector3Int(-1, 13);
                mapa.SetTile(posicaoTile, tileFase3part2);
                posicaoTile = new Vector3Int(0, 13);
                mapa.SetTile(posicaoTile, tileFase3part2);
                posicaoTile = new Vector3Int(1, 13);
                mapa.SetTile(posicaoTile, tileFase3part2);

                posicaoTile = new Vector3Int(19, -1);
                mapa.SetTile(posicaoTile, tileFase4);
                posicaoTile = new Vector3Int(19, 0);
                mapa.SetTile(posicaoTile, tileFase4);
                posicaoTile = new Vector3Int(19, 1);
                mapa.SetTile(posicaoTile, tileFase4);


                break;
            case 2:
                posicaoTile = new Vector3Int(-19, -1);
                mapa.SetTile(posicaoTile, tileFase1);
                posicaoTile = new Vector3Int(-19, 0);
                mapa.SetTile(posicaoTile, tileFase1);
                posicaoTile = new Vector3Int(-19, 1);
                mapa.SetTile(posicaoTile, tileFase1);

                posicaoTile = new Vector3Int(-1, 14);
                mapa.SetTile(posicaoTile, tileFase3part1);
                posicaoTile = new Vector3Int(0, 14);
                mapa.SetTile(posicaoTile, tileFase3part1);
                posicaoTile = new Vector3Int(1, 14);
                mapa.SetTile(posicaoTile, tileFase3part1);
                posicaoTile = new Vector3Int(-1, 13);
                mapa.SetTile(posicaoTile, tileFase3part2);
                posicaoTile = new Vector3Int(0, 13);
                mapa.SetTile(posicaoTile, tileFase3part2);
                posicaoTile = new Vector3Int(1, 13);
                mapa.SetTile(posicaoTile, tileFase3part2);

                posicaoTile = new Vector3Int(19, -1);
                mapa.SetTile(posicaoTile, tileFase4);
                posicaoTile = new Vector3Int(19, 0);
                mapa.SetTile(posicaoTile, tileFase4);
                posicaoTile = new Vector3Int(19, 1);
                mapa.SetTile(posicaoTile, tileFase4);
                break;
            case 3:
                posicaoTile = new Vector3Int(-19, -1);
                mapa.SetTile(posicaoTile, tileFase1);
                posicaoTile = new Vector3Int(-19, 0);
                mapa.SetTile(posicaoTile, tileFase1);
                posicaoTile = new Vector3Int(-19, 1);
                mapa.SetTile(posicaoTile, tileFase1);

                posicaoTile = new Vector3Int(-1, -13);
                mapa.SetTile(posicaoTile, tileFase2part1);
                posicaoTile = new Vector3Int(0, -13);
                mapa.SetTile(posicaoTile, tileFase2part1);
                posicaoTile = new Vector3Int(1, -13);
                mapa.SetTile(posicaoTile, tileFase2part1);
                posicaoTile = new Vector3Int(-1, -14);
                mapa.SetTile(posicaoTile, tileFase2part2);
                posicaoTile = new Vector3Int(0, -14);
                mapa.SetTile(posicaoTile, tileFase2part2);
                posicaoTile = new Vector3Int(1, -14);
                mapa.SetTile(posicaoTile, tileFase2part2);

                posicaoTile = new Vector3Int(19, -1);
                mapa.SetTile(posicaoTile, tileFase4);
                posicaoTile = new Vector3Int(19, 0);
                mapa.SetTile(posicaoTile, tileFase4);
                posicaoTile = new Vector3Int(19, 1);
                mapa.SetTile(posicaoTile, tileFase4);
                break;
            case 4:
                posicaoTile = new Vector3Int(-19, -1);
                mapa.SetTile(posicaoTile, tileFase1);
                posicaoTile = new Vector3Int(-19, 0);
                mapa.SetTile(posicaoTile, tileFase1);
                posicaoTile = new Vector3Int(-19, 1);
                mapa.SetTile(posicaoTile, tileFase1);

                posicaoTile = new Vector3Int(-1, -13);
                mapa.SetTile(posicaoTile, tileFase2part1);
                posicaoTile = new Vector3Int(0, -13);
                mapa.SetTile(posicaoTile, tileFase2part1);
                posicaoTile = new Vector3Int(1, -13);
                mapa.SetTile(posicaoTile, tileFase2part1);
                posicaoTile = new Vector3Int(-1, -14);
                mapa.SetTile(posicaoTile, tileFase2part2);
                posicaoTile = new Vector3Int(0, -14);
                mapa.SetTile(posicaoTile, tileFase2part2);
                posicaoTile = new Vector3Int(1, -14);
                mapa.SetTile(posicaoTile, tileFase2part2);

                posicaoTile = new Vector3Int(-1, 14);
                mapa.SetTile(posicaoTile, tileFase3part1);
                posicaoTile = new Vector3Int(0, 14);
                mapa.SetTile(posicaoTile, tileFase3part1);
                posicaoTile = new Vector3Int(1, 14);
                mapa.SetTile(posicaoTile, tileFase3part1);
                posicaoTile = new Vector3Int(-1, 13);
                mapa.SetTile(posicaoTile, tileFase3part2);
                posicaoTile = new Vector3Int(0, 13);
                mapa.SetTile(posicaoTile, tileFase3part2);
                posicaoTile = new Vector3Int(1, 13);
                mapa.SetTile(posicaoTile, tileFase3part2);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
