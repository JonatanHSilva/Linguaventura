using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //animate the sprite color base on the gradient and time
    public class GlowRuneScript1 : MonoBehaviour
    {
        public SpriteRenderer sprite;
        public float velocidade;

        private Color corAtual;
        private Color corAlvo;

        private void Start()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            corAtual = new Color(1, 0, 0, 1);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            corAtual = new Color(1, 0, 0, 0);
        }

        private void Update()
        {
            corAlvo = Color.Lerp(corAlvo, corAtual, velocidade * Time.deltaTime);
            sprite.color = corAlvo;
        }
    }
}
