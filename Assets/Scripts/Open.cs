using System;
using UnityEngine;

namespace BehaviorTree
{
    [Serializable]
    public class Open : Task
    {
        // The character that is opening the thing.
        private Character opener;
        public Character Opener
        {
            get { return opener; }
            set { opener = value; }
        }

        // The thing that is being opened.
        private Thing openThis;
        public Thing OpenThis
        {
            get { return openThis; }
            set { openThis = value; }
        }

        // This constructor defaults the character and thing to None.
        public Open() : this(Character.None, Thing.None) { }

        // This constructor takes parameters for the character and thing.
        public Open (Character opener, Thing openThis)
        {
            Opener = opener;
            OpenThis = openThis;
        }

        // This method runs the Open action on the given WorldState object.
        public override bool run(WorldState state)
        {
            //if the position of the Character Opener and the position of the Thing OpenThis are the same
            //--AND--
            //the Open value of Thing OpenThis is false
            if (state.CharacterPosition[Opener] == state.ThingPosition[OpenThis] && !state.Open[OpenThis])
            {
                //set the Open value of Thing OpenThis to true
                state.Open[OpenThis] = true;

                //print and return true
                Debug.Log($"{this} successfully");
                return true;
            }
            else
            {
                //otherwise print and return false
                Debug.Log($"{this} unsuccessfully");
                return false;
            }
        }

        // Creates and returns a string describing the Open action.
        public override string ToString()
        {
            return opener + " opens " + openThis;
        }
    }
}
