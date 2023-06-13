using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFTrickingComboGenerator
{
    public class Transition
    {
        private string transName; //true transition name
        private string displayName;  //coloquial name
        private bool oneFootTakeOff; //is single foot takeoff or not
        private Stance stanceBegin; //entry stance of transition 
        private Stance stanceEnd; //ending stance of transition
        private bool changeDOM; //does transition change combo DOM
        private int favorability; //influences the likely hood of being used
        private string incompatible; //does this transition have incompatible moves

        //private string footPattern;

        public Transition(string transName, string displayName, bool oneFootTakeOff, Stance stanceBegin, Stance stanceEnd, int favorability = 1, string incompatible = null)
        {
            //this is a constructor within the class that allows the object to be created with the variables supplied.

            TransName = transName;
            DisplayName = displayName;
            OneFootTakeOff = oneFootTakeOff; 
            StanceBegin = stanceBegin;
            StanceEnd = stanceEnd;
            Favorability = favorability;
            Incompatible = incompatible;

        }

    public string TransName
        {
            get { return transName; }
            set
            {
                transName = value;
            }

        }

        public string DisplayName
        {
            get { return displayName; }
            set
            {
                displayName = value;
            }

        }

        public bool OneFootTakeOff
        {
            get { return oneFootTakeOff; }
            set
            {
                oneFootTakeOff = value;
            }

        }

        public Stance StanceBegin
        {
            get { return stanceBegin; }
            set
            {
                stanceBegin = value;
            }

        }

        public Stance StanceEnd
        {
            get { return stanceEnd; }
            set
            {
                stanceEnd = value;
            }

        }

        public bool ChangeDOM
        {
            get { return changeDOM; }
            set
            {
                changeDOM = value;
            }

        }

        public int Favorability
        {
            get { return favorability; }
            set
            {
                favorability = value;
            }

        }

        public string Incompatible
        {
            get { return incompatible; }
            set
            {
                incompatible = value;
            }

        }

    }
}
