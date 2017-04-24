using UnityEngine;
using System.Collections;


namespace Spikes
{
    public interface IItemBase
    {


        bool checkCollision(Collision2D col);

        void refrence(string toFind);

        void CheckEssence(string tocheck);

       


    }

}

