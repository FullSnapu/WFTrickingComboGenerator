using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WFTrickingComboGenerator
{
    public static class VariationLibrary
    {
        public static ObservableCollection<Variation> VarData { get; set; }

        static VariationLibrary()
        {
            VarData = new ObservableCollection<Variation>();
            PopulateVariations();
        }

        private static void PopulateVariations()
        {
            VarData.Add(new Variation("Flip;Twist;", "Round", "Round", TrickLibrary.Stances("Complete")));
            VarData.Add(new Variation("Flip;Twist;", "Shuriken", "Shuriken", TrickLibrary.Stances("Complete")));
            VarData.Add(new Variation("Flip;Twist;", "Feilong", "Feilong", TrickLibrary.Stances("Complete,Mega")));
            VarData.Add(new Variation("Flip;Twist;", "DoubleLeg", "Dleg", TrickLibrary.Stances("Complete")));
            VarData.Add(new Variation("Flip;Twist;", "Swipe", "Swipe", TrickLibrary.Stances("Hyper, Semi")));
            VarData.Add(new Variation("Flip;Twist;", "HyperHook", "HyperHook", TrickLibrary.Stances("Hyper,Semi")));
            VarData.Add(new Variation("Flip;Twist;", "SwipeGyro", "Snapu", TrickLibrary.Stances("Complete")));
            VarData.Add(new Variation("Flip;", "Switch(L)", "Switch", TrickLibrary.Stances("Complete")));

            //Kick Variations change trick name completely. Variations should be limited to non-rotation-adding variations. OR add logic to update name of trick.
            //VarData.Add(new Variation("Kick;", "RoundHyper", "RoundHyper", TrickLibrary.Stances("Hyper,Semi")));
            //VarData.Add(new Variation("Kick;", "HookHyper", "Shuriken", TrickLibrary.Stances("Mega,Complete")));
        }

        
        private static Random random = new Random(); //**REFACTOR - should create one static random across classes

        public static Variation GetVariation(Trick trick)
        {
            //parsing string category to array for loop
            string[] trickCategories = trick.Category.Split(';');

            List<Variation> varList = SuitableList(trickCategories);

            int varIndex = random.Next(0, varList.Count); // Random range from 0 to length of collection

            //create this variation variable
            Variation vari = varList[varIndex];

            //pick an outstance from he variations outstance array
            int stanceIndex = random.Next(0, vari.OutStances.Length);
            vari.OutStance = vari.OutStances[stanceIndex];

            return vari;


        }

        private static List<Variation> SuitableList(string[] trickCats)
        {

            List<Variation> varList = new List<Variation>();
            string[] varCats = null;
            
            for(int v = 0; v < VarData.Count; v++) //loop through all variations
            {
                varCats = VarData[v].Categories.Split(';');

                if(AllVarCatsInTrickCats(varCats,trickCats))
                {
                    varList.Add(VarData[v]);
                }

            }

            return varList; 
        }

        private static bool AllVarCatsInTrickCats(string[] varCats, string[] trickCats)
        {
            // all variation categories are found in the trick's categories

            for(int v = 0; v<varCats.Length; v++) //go thru each variation category
            {
                if (trickCats.Contains(varCats[v]) || string.IsNullOrEmpty(varCats[v])) //if category exists in trick categories, then continue OR category is blank
                {
                    continue;
                }

                else //if not found -- return false
                {
                    return false;
                }
            }


            return true; //if no false found return true
        } 
    }
}
