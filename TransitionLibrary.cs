using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFTrickingComboGenerator
{
    public static class TransitionLibrary
    {
        public static ObservableCollection<Transition> TransData { get; set; }

        static TransitionLibrary()
        {
            TransData = new ObservableCollection<Transition>();
            PopulateTransitions();
        }

        private static void PopulateTransitions()
        {
            TransData.Add(new Transition(transName: "BackSwing (L)", displayName: "S/T", oneFootTakeOff: true, stanceBegin: Stance("Complete"), stanceEnd: Stance("Complete"), favorability: 2));
            TransData.Add(new Transition(transName: "BackSwing (R)", displayName: "S/T", oneFootTakeOff: true, stanceBegin: Stance("Hyper"), stanceEnd: Stance("Hyper"), favorability: 2, incompatible: "VertKick;"));
            TransData.Add(new Transition(transName: "FrontSwing (R)", displayName: "S/T", oneFootTakeOff: true, stanceBegin: Stance("Semi"), stanceEnd: Stance("Semi"), favorability: 2, incompatible: "VertKick;"));
            TransData.Add(new Transition(transName: "FrontSwing (L)", displayName: "S/T", oneFootTakeOff: true, stanceBegin: Stance("Mega"), stanceEnd: Stance("Mega"), favorability: 2, incompatible: "VertKick;"));
            TransData.Add(new Transition(transName: "(Complete) Vanish (LR)", displayName: "Vanish", oneFootTakeOff: true, stanceBegin: Stance("Complete"), stanceEnd: Stance("Hyper"), favorability: 2));
            TransData.Add(new Transition(transName: "(Mega) Vanish (LR)", displayName: "Vanish", oneFootTakeOff: true, stanceBegin: Stance("Mega"), stanceEnd: Stance("Semi")));
            TransData.Add(new Transition(transName: "(Semi) Vanish (RL)", displayName: "Vanish", oneFootTakeOff: true, stanceBegin: Stance("Semi"), stanceEnd: Stance("Mega"), favorability: 2));
            TransData.Add(new Transition(transName: "(Hyper) Vanish (RL)", displayName: "Vanish", oneFootTakeOff: true, stanceBegin: Stance("Hyper"), stanceEnd: Stance("Complete"), favorability: 2));
            TransData.Add(new Transition(transName: "(Mega) Misleg (L)", displayName: "M/L", oneFootTakeOff: true, stanceBegin: Stance("Mega"), stanceEnd: Stance("Complete")));
            TransData.Add(new Transition(transName: "(Hyper) Misleg (R)", displayName: "M/L", oneFootTakeOff: true, stanceBegin: Stance("Hyper"), stanceEnd: Stance("Semi")));
            TransData.Add(new Transition(transName: "(Complete) Misleg (L)", displayName: "M/L", oneFootTakeOff: true, stanceBegin: Stance("Complete"), stanceEnd: Stance("Mega"), favorability: 2));
            TransData.Add(new Transition(transName: "(Semi) Misleg (R)", displayName: "M/L", oneFootTakeOff: true, stanceBegin: Stance("Semi"), stanceEnd: Stance("Hyper")));
            TransData.Add(new Transition(transName: "CarryThru", displayName: "C/T", oneFootTakeOff: true, stanceBegin: Stance("Hyper"), stanceEnd: Stance("Semi"), favorability: 2));
            TransData.Add(new Transition(transName: "WrapThru", displayName: "W/T", oneFootTakeOff: true, stanceBegin: Stance("Hyper"), stanceEnd: Stance("Hyper"), favorability: 2));
            TransData.Add(new Transition(transName: "(Complete) Pop", displayName: "Pop", oneFootTakeOff: false, stanceBegin: Stance("Complete"), stanceEnd: Stance("Complete"), favorability: 2));
            TransData.Add(new Transition(transName: "(Hyper) Pop", displayName: "Pop", oneFootTakeOff: false, stanceBegin: Stance("Hyper"), stanceEnd: Stance("Hyper"), favorability: 2));
            TransData.Add(new Transition(transName: "(Mega) Pop", displayName: "Pop", oneFootTakeOff: false, stanceBegin: Stance("Mega"), stanceEnd: Stance("Mega"), favorability: 2));
            TransData.Add(new Transition(transName: "(Semi) Pop", displayName: "Pop", oneFootTakeOff: false, stanceBegin: Stance("Semi"), stanceEnd: Stance("Semi")));
            TransData.Add(new Transition(transName: "(Hyper) Reversal (R)", displayName: "Reversal", oneFootTakeOff: true, stanceBegin: Stance("Hyper"), stanceEnd: Stance("Semi")));
            TransData.Add(new Transition(transName: "(Complete) Reversal (L)", displayName: "Reversal", oneFootTakeOff: true, stanceBegin: Stance("Complete"), stanceEnd: Stance("Mega")));
            TransData.Add(new Transition(transName: "(Semi) Reversal (R)", displayName: "Reversal", oneFootTakeOff: true, stanceBegin: Stance("Semi"), stanceEnd: Stance("Hyper")));
            TransData.Add(new Transition(transName: "(Mega) Reversal (L)", displayName: "Reversal", oneFootTakeOff: true, stanceBegin: Stance("Mega"), stanceEnd: Stance("Complete")));
            TransData.Add(new Transition(transName: "(Mega)Pivot(L)", displayName: "Pivot", oneFootTakeOff: true, stanceBegin: Stance("Mega"), stanceEnd: Stance("Complete")));
            TransData.Add(new Transition(transName: "(Complete)Pivot(L)", displayName: "Pivot", oneFootTakeOff: true, stanceBegin: Stance("Complete"), stanceEnd: Stance("Mega")));

        }

        private static Stance Stance(string name)
        //Returns Stance from name
        {
            Stance stance = new Stance(name);

            return stance;
        }

        public static Transition Lookup(string lookupName)
        {
            for (int i = 0; i < TransData.Count; i++)
            {
                if(TransData[i].TransName == lookupName)
                {
                    return TransData[i];
                }
            }

            return null;
        }

        //creates a non repeating instance of random
        private static Random random = new Random();

        public static Transition GetTransition(Stance prevStance, Stance nextStance)
        {
            List<Transition> transitions = GetSuitableTransList(prevStance, nextStance);

            int index = random.Next(0, transitions.Count); // Random range from 0 to length of collecton

            try
            {
                Transition tran = transitions[index]; //need to code for when possible transition not found
                return tran;
            }
            catch(Exception e)
            {

                MessageBox.Show(e.Message + Environment.NewLine + "No transition match found for the given scenario. More transitions needed in TransitionLibrary");
                return null;

            }
            
        }

        public static List<Transition> GetSuitableTransList(Stance prevStance, Stance nextStance)
        {
            //Creating list of suitable transitions
            var translist = new List<Transition>();

            //and looping through TransData and adding to translist Transitions that match criteria
            for (int i = 0; i < TransData.Count; i++)
            {
                //comparing on name value because without: no match
                if(isSuitable(TransData[i], prevStance, nextStance))
                {
                    translist.Add(TransData[i]);
                }
            }

            return translist;
        }

        private static bool isSuitable(Transition transition, Stance prevStance, Stance nextStance)
        {
            bool prevMatch = false;
            bool nextMatch = false;

            //if begin stance is null or is a match - return true
            if (prevStance == null)
            {
                prevMatch = true;
            }
            else
            {
                prevMatch = transition.StanceBegin.Name == prevStance.Name;

            }

            //if endstance is null or is a match - return true
            if (nextStance == null)
            {
                nextMatch = true;
            }
            else
            {

                prevMatch = transition.StanceEnd.Name == nextStance.Name; //***USE BETTER NAMES FOR PREV-TRICK-BEGINSTANCE
            }

            bool suitable = prevMatch && nextMatch;

            return suitable;
        }
    }
}

