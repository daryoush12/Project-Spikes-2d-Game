using UnityEngine;
using System.Collections;
using System;

namespace Spikes
{
    public class ItemBase : IItemBase
    {
        private GameObject essence;
        public GameObject Essence
        {
            get { return essence; }
            set { essence = value; }
            }
        private ItemType esst = ItemType.Debug;
        public ItemType essT
        {
            get { return esst; }
            set { if (value is Enum) { esst = value; }; }
        }


        public bool checkCollision(Collision2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                Debug.Log("Essence was properly picked up by player.");
                // Call for boost and destroy object.
                //Destroy(essence);
                return true;
            }
            else
            {
                Debug.Log("Something else triggered essence.");
                return false;
            }
        }

        public void refrence(string toFind)
        {
            Essence = GameObject.Find(toFind);
        }

        public void CheckEssence(string tocheck)
        {

          ItemType ParsedValue = ParseEnum<ItemType>(tocheck);
          essT = ParsedValue;




        }

        public static ItemType ParseEnum<ItemType>(string value)
        {
            return (ItemType)Enum.Parse(typeof(ItemType), value, true);
        }



    }

}

