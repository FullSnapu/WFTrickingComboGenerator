using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFTrickingComboGenerator
{
    public class Trick
    {
        private string name; //true trick name
        private string displayName; //colloquial name
        private Nullable<bool> oneFootTakeOff; //take off is 1 foot
        private Stance[] inStances; //array of possible stances into the trick
        private Stance[] outStances; //array of possible stances out of the trick
        private Stance inStance; //an in stance will be selected for the specific instance
        private Stance outStance;//an out stance will be selected for the specific instance
        private string category; //classification of trick (kick;flip;twist)
        private Variation variation;//variation of trick - will change the landing stance (and other future properties)


        //SPECIFIC INSTANCE
        public Trick(string name, string displayName, Stance inStance, Stance outStance, Nullable<bool> oneFootTakeOff, string category, Variation variation = null)
        {
            //constructor for definitive instance of trick - for actual Trick mid combo
            this.Name = name;
            this.DisplayName = displayName;
            this.OneFootTakeOff = oneFootTakeOff;

            this.Variation = variation; 
            this.InStance = inStance;
            this.OutStance = outStance;
            this.Category = category;
            
        }

        //GENERAL TRICK DATA
        public Trick(string name, string displayName, Nullable<bool> oneFootTakeOff, Stance[] inStances, Stance[] outStances, string category)
        {
            //constructor for general idea for trick object - for TrickLibrary
            this.Name = name;
            this.DisplayName = displayName;
            this.OneFootTakeOff = oneFootTakeOff;
            this.InStances = inStances;
            this.OutStances = outStances;
            this.Category = category;
        }



        public string Name
        {
            get { return name; }
            set
            {
                name = value;
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

        public Stance[] InStances
        {
            get { return inStances; }
            set
            {
                inStances = value;
            }
        }

        public Stance[] OutStances
        {
            get { return outStances; }
            set
            {
                outStances = value;
            }
        }

        public Stance InStance
        {
            get { return inStance; }
            set
            {
                inStance = value;
            }

        }

        public Stance OutStance
        {
            get { return outStance; }
            set
            {
                // if trick has a variation, use variation outstance
                if (variation == null) { outStance = value;}
                else { outStance = variation.OutStance; }
            }

        }

        public Nullable<bool> OneFootTakeOff
        {
            get { return oneFootTakeOff; }
            set
            {
                oneFootTakeOff = value;
            }
        }

        public string Category
        {
            get { return category; }
            set
            {
                category = value;
            }
        }

        public Variation Variation
        {
            get { return variation; }
            set
            {
                variation = value;
                if (variation != null) { outStance = variation.OutStance; } //if trick has a variation - then use the variation outstance
            }
        }


    }
}
