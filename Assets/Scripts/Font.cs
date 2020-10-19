using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Font : MonoBehaviour
{
    // Start is called before the first frame update
     // Mapping each character to the font spritesheet
[SerializeField]
private Dictionary<char, CharData> characters;
[SerializeField]
List<Sprite> charSprite = new List<Sprite>();
private static readonly char[] type =
   "!\"#$%&\'()*+,./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^`abcdefghijklmnopqrstuvwxyz{|}~_".ToCharArray();

   void Awake()
   {
      //Debug.Log(type.Length);
      characters = new Dictionary<char, CharData>();

      //Debug.Log(charSprite[0].rect.width);

      for(int i = 0; i < charSprite.Count; i++)
      {
         characters.Add(type[i], new CharData((int)charSprite[i].rect.width, charSprite[i]));
      }

     // Debug.Log(characters['a'].width);

   }


   public struct CharData
   {
      public int width;
      public Sprite sprite;

      public CharData(int width, Sprite sprite)
      {
         this.width = width;
         this.sprite = sprite;
      }
   }

}
