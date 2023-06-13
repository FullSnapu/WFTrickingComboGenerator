using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFTrickingComboGenerator
{
    public static class TrickLibrary
    {
        public static ObservableCollection<Trick> TrickData { get; set; }

        static TrickLibrary()
        {
            TrickData = new ObservableCollection<Trick>();
            PopulateTricks();
        }

        //Trick(string name, string displayName, Stance inStance, Stance outStance, bool oneFootTakeOff, string category, Variation variation = null)
        private static void PopulateTricks()
        {
            TrickData.Add(new Trick("TouchDownRaiz", "TDR", true, Stances("Semi"), Stances("Complete"), "Connect;"));
            TrickData.Add(new Trick("Raiz", "Raiz", true, Stances("Semi"), Stances("Complete"), "Connect;"));
            TrickData.Add(new Trick("Cartwheel", "Cart", true, Stances("Mega"), Stances("Hyper"), "Connect;"));
            TrickData.Add(new Trick("Scoot", "Scoot", true, Stances("Semi"), Stances("Complete,Hyper"), "Connect;"));
            TrickData.Add(new Trick("Valdez", "Valdez", false, Stances("Complete"), Stances("Complete,Hyper"), "Connect;"));
            TrickData.Add(new Trick("MasterScoot", "MasterScoot", true, Stances("Hyper"), Stances("Complete"), "Connect;"));
            TrickData.Add(new Trick("TDGainer", "TDGainer", true, Stances("Complete"), Stances("Hyper"), "Connect;"));
            TrickData.Add(new Trick("Gainer", "Gainer", true, Stances("Complete"), Stances("Hyper"), "Flip;"));
            TrickData.Add(new Trick("GainerHook", "GainerHook", true, Stances("Complete"), Stances("Hyper,Semi"), "Flip;"));
            TrickData.Add(new Trick("Aerial", "Aerial", true, Stances("Mega"), Stances("Hyper,Semi"), "Flip;"));
            TrickData.Add(new Trick("ButterflyKick", "Butterfly Kick", true, Stances("Mega"), Stances("Hyper"), "Flip;"));
            TrickData.Add(new Trick("ButterflyHook", "ButterKnife", true, Stances("Mega"), Stances("Hyper,Semi"), "Flip;"));
            TrickData.Add(new Trick("Sideswipe", "Sideswipe", true, Stances("Semi"), Stances("Hyper"), "Flip;"));
            TrickData.Add(new Trick("Sidewinder", "Sidewinder", true, Stances("Mega"), Stances("Mega,Complete"), "Flip;"));
            TrickData.Add(new Trick("Webster", "Webster", true, Stances("Mega"), Stances("Semi"), "Flip;"));
            TrickData.Add(new Trick("Webster", "Webster", true, Stances("Semi"), Stances("Mega"), "Flip;"));
            TrickData.Add(new Trick("Gumbi", "Gumbi", true, Stances("Semi"), Stances("Complete"), "Flip;"));
            TrickData.Add(new Trick("DoubleLeg", "DoubleLeg", false, Stances("Semi,Mega"), Stances("Complete"), "Flip;"));
            TrickData.Add(new Trick("FrontFlip", "FrontFlip", false, Stances("Semi,Mega"), Stances("Semi,Mega"), "Flip;"));
            TrickData.Add(new Trick("Arabian", "Arabian", false, Stances("Complete,Hyper"), Stances("Semi,Mega"), "Flip;"));
            TrickData.Add(new Trick("BackflipFlashKick", "FlashKick", false, Stances("Complete"), Stances("Hyper"), "Flip;"));
            TrickData.Add(new Trick("GrandMasterSwipe", "GMS", true, Stances("Hyper"), Stances("Hyper"), "Flip;"));
            TrickData.Add(new Trick("GrandMasterScoot", "GMScoot", true, Stances("Hyper"), Stances("Complete"), "Flip;"));
            TrickData.Add(new Trick("IllusionTwist", "IllusionTwist", true, Stances("Mega"), Stances("Mega"), "Flip;"));
            TrickData.Add(new Trick("FlashSwitch", "Switch", false, Stances("Complete"), Stances("Complete"), "Flip"));
            TrickData.Add(new Trick("GainerSwitch", "Gainer Switch", true, Stances("Complete"), Stances("Complete"), "Flip;Swing"));
            TrickData.Add(new Trick("GainerArabian", "Gainer Arabian", true, Stances("Complete"), Stances("Semi,Mega"), "Flip;Swing;Twist"));
            TrickData.Add(new Trick("DoubleCork", "Double Cork", true, Stances("Complete"), Stances("Complete"), "Flip;Swing;Twist"));
            TrickData.Add(new Trick("BackFullTwist", "Full", false, Stances("Complete"), Stances("Complete"), "Flip;Twist"));
            TrickData.Add(new Trick("TrkrFullTwist", "Full", false, Stances("Hyper"), Stances("Complete"), "Flip;Twist"));
            TrickData.Add(new Trick("Corkscrew", "Cork", true, Stances("Complete"), Stances("Complete"), "Flip;Twist"));
            TrickData.Add(new Trick("TakFull", "Tak Full", true, Stances("Hyper"), Stances("Complete"), "Flip;Twist"));
            TrickData.Add(new Trick("ButterflyTwist", "Btwist", true, Stances("Mega"), Stances("Complete"), "Flip;Twist"));
            TrickData.Add(new Trick("AerialTwist", "Atwist", true, Stances("Mega"), Stances("Complete"), "Flip;Twist"));
            TrickData.Add(new Trick("RaizTwist", "c7Twist", true, Stances("Semi"), Stances("Complete"), "Flip;Twist"));
            TrickData.Add(new Trick("Cheat360Round", "Tornado", true, Stances("Hyper"), Stances("Complete,Mega"), "Kick;"));
            TrickData.Add(new Trick("Cheat360Para", "Parafuso", true, Stances("Hyper"), Stances("Complete"), "Kick;"));
            //TrickData.Add(new Trick("Cheat360RoundHook", "Jackknife", true, Stances("Hyper"), Stances("Hyper,Semi"), "Kick;"));
            TrickData.Add(new Trick("Cheat540Hook", "Cheat 720", true, Stances("Hyper"), Stances("Hyper,Semi"), "Kick;"));
            TrickData.Add(new Trick("Cheat720Round", "Cheat 900", true, Stances("Hyper"), Stances("Complete,Mega"), "Kick;"));
            TrickData.Add(new Trick("Cheat900Hook", "Cheat 1080", true, Stances("Hyper"), Stances("Hyper,Semi"), "Kick;"));
            // TrickData.Add(new Trick("c360R(Hyper)", "Cheat 540kick", true, Stances("Hyper"), Stances("Hyper,Semi"), "Kick;"));
            TrickData.Add(new Trick("Pop360Cresent", "Pop3", false, Stances("Semi"), Stances("Semi,Mega"), "Kick;"));
            TrickData.Add(new Trick("BS540Round", "BS900", false, Stances("Complete,Hyper"), Stances("Complete,Mega"), "Kick;"));
            TrickData.Add(new Trick("BS720Hook", "BS1080", false, Stances("Complete,Hyper"), Stances("Hyper,Semi"), "Kick;"));
            TrickData.Add(new Trick("Swing360H", "Swing 7", true, Stances("Complete"), Stances("Hyper,Semi"), "Kick;Swing"));
            TrickData.Add(new Trick("Swing540R", "Swing 9", true, Stances("Complete"), Stances("Complete,Mega"), "Kick;Swing"));
            TrickData.Add(new Trick("Wrap360Hook", "Wrap 720", true, Stances("Semi"), Stances("Hyper,Semi"), "Kick;Wrap"));
            TrickData.Add(new Trick("Wrap540Round", "Wrap 900", true, Stances("Semi"), Stances("Complete,Mega"), "Kick;Wrap"));
            TrickData.Add(new Trick("Wrap720Hook", "Wrap 1080", true, Stances("Semi"), Stances("Hyper,Semi"), "Kick;Wrap"));

        }

        public static Trick GetRandomTrick(Transition PrevTran, Transition NextTran)
        {
            //Returning random trick considering criteria

            List<Trick> tricklist = new List<Trick>();


            tricklist = GetSuitableTrickList(PrevTran, NextTran);

            int index = random.Next(0, tricklist.Count); // Random range from 0 to length of list

            Trick trick = tricklist[index];

            return trick;

        }

        public static Stance[] Stances(string names)
            //returns array of stances from a string of comma separated stances
        {
            string[] namesArr = names.Split(','); 
            Stance[] stances = new Stance[namesArr.Length];

            for(int i = 0; i < namesArr.Length; i++)
            {
                stances[i] = new Stance(namesArr[i]);
                if (stances[i]==null)
                {
                    throw new ArgumentNullException();
                }
            }
            
            return stances;
        }

        //creates a non repeating instance of random
        private static Random random = new Random();

        public static List<Trick> GetSuitableTrickList(Transition prevTran, Transition nextTran,bool specifyStances = true)
        {
            //Creating list of suitable transitions based on begin and end stances

            List<Trick> tricklist = new List<Trick>(); //perhaps pass by reference
            Stance inStance = null;
            Stance outStance = null;
            bool? tranOneFootTakeOff = null;

            if (prevTran != null) {inStance = prevTran.StanceEnd; tranOneFootTakeOff = prevTran.OneFootTakeOff; } //inStance of trick should match previous transitions endstacne
            if (nextTran != null) {outStance = nextTran.StanceBegin; } //avoids null reference error


            Stance[] inStances;
            Stance[] outStances;

            //temp variables for suitable trick instances to be added to list
            string tempName;
            string tempDisplay;
            Nullable<bool> oneFootTakeOff;
            Stance tempInStance;
            Stance tempOutStance;
            string tempCategory;
            Trick tempTrick;



            for (int t = 0; t < TrickData.Count; t++) //looping TrickData list
            {
                inStances = TrickData[t].InStances;
                outStances = TrickData[t].OutStances;

                for (int i = 0; i < inStances.Length; i++) //looping thru in-stances
                {
                    for (int o = 0; o < outStances.Length; o++) //looping thru out-stances
                    {
                        if (TrickTranMatch(inStance, outStance, inStances[i], outStances[o], tranOneFootTakeOff, TrickData[t].OneFootTakeOff)) //if stances match & tranisiton + trick are one footed 
                        { 
                            tempName = TrickData[t].Name;
                            tempDisplay = TrickData[t].DisplayName;
                            oneFootTakeOff = TrickData[t].OneFootTakeOff;
                            tempInStance = TrickData[t].InStances[i];
                            tempOutStance = TrickData[t].OutStances[o];
                            tempCategory = TrickData[t].Category;

                            if(specifyStances) //allows in/out stances not to finalized - for use on combox list
                            {
                                tempInStance = TrickData[t].InStances[i];
                                tempOutStance = TrickData[t].OutStances[o];
                                tempTrick = new Trick(tempName, tempDisplay, tempInStance, tempOutStance, oneFootTakeOff, tempCategory); 
                            }
                            else //if stances arent finalized - construct with stances array
                            {
                                tempTrick = new Trick(tempName, tempDisplay, oneFootTakeOff, TrickData[t].InStances, TrickData[t].OutStances, tempCategory);
                            }

                            tricklist.Add(tempTrick);

                        }

                    }
                }
            }
            return tricklist;
        }
        private static bool TrickTranMatch(Stance inStance, Stance outStance, Stance inStances, Stance outStances, Nullable<bool> prevTranOneFootTakeOff, bool? trickOneFootTakeOff)
        {
            //if  (in-Stances match or null) & (outstances match or null) & (oneFooted match or null) return true
            bool inStanceMatch = false;
            bool outStanceMatch = false;
            bool footingMatch = false;

            if (inStance == null)
            {
                inStanceMatch = true;
            }
            else if (inStance.Name == inStances.Name)
            {
                inStanceMatch = true;
            }

            if (outStance == null)
            {
                outStanceMatch = true;
            }
            else if (outStance.Name == outStances.Name)
            {
                outStanceMatch = true;
            }

            if(prevTranOneFootTakeOff == null)
            {
                footingMatch = true;
            }
            else if(prevTranOneFootTakeOff == trickOneFootTakeOff)
            {
                footingMatch = true;
            }


            //if  (in-Stances match or null) & (outstances match or null) & takeoff type match or null

            return inStanceMatch && outStanceMatch && footingMatch;
        }

        public static bool VerifyCategory(string catString, Transition transition) //**REFACTOR TO ACCEPT TRAN OR TRICK AND GET THE OBJECT PROPERTIES 
        {
            //parsing category property string to array for loop
            string[] categories = catString.Split(';');
            //parsing incompatible property to array for nested loop
            string[] incompats = transition.Incompatible.Split(';');

            //looping through trick's categories
            for(int c = 0;c<categories.Length;c++)
            {
                //loop through transitions incompatible categories
                for(int i=0;i<incompats.Length;i++)
                {
                    //if trick category matches transition incompatible category then false
                    if (categories[c] == incompats[i]) return false;
                }
            }
            //no category incompatible matches - return true
            return true;
        }

        public static Trick Lookup(string lookupName)
        {
            //method to look up tricks by name - using this to reinstanciate tricks for labels
            for (int i = 0; i < TrickData.Count; i++)
            {
                if (TrickData[i].DisplayName == lookupName)
                {
                    return TrickData[i];
                }
            }

            return null;
        }
    }


}
