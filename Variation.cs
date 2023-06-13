using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFTrickingComboGenerator
{
    public class Variation
    {
        private string categories; //category variation applies to
        private string name; //true variation name
        private string displayName;  //colloquial name
        private Stance outStance; //landing stance of variation instance
        private Stance[] outStances; //array of possible landing stances for general variation data

        //private int favorability;

        //private string outKick; //if kick, what is the kick category

        //private int rotation //calc difficulty
        //private int kickCount / calc difficulty 

        public Variation(string categories, string name, string displayName, Stance outStance)
        {
            //constructor for specific instance of a trick in a combo

            Categories = categories;
            Name = name;
            DisplayName = displayName;
            OutStance = outStance;
        }

        public Variation(string categories, string name, string displayName, Stance[] outStances)
        {
            //constructor for specific instance of a trick in a combo

            Categories = categories;
            Name = name;
            DisplayName = displayName;
            OutStances = outStances;
        }

        public string Categories
        {
            get { return categories; }
            set
            {
                categories = value;
            }

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

        public Stance OutStance
        {
            get { return outStance; }
            set
            {
                outStance = value;
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

    }
}
