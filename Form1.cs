using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection; //for name of property
using System.Diagnostics; //for debug

//***Footed take off "both" or "one foot" needed as trick/transition property. (if trick is one foot take off, cannot be pop)
//might want to weigh tricks randomness rather than transition randomness
//change name properties to ID
//allow type out combo and translate to TKT
//verify legitamacy by typing trick into combo
namespace WFTrickingComboGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



            //stance comboboxes

            //cbInStanceT1.DisplayMember = "Name";
            //cbInStanceT1.ValueMember = "Name";
            //cbOutStanceT1.DisplayMember = "Name";
            //cbOutStanceT1.ValueMember = "Name";

            //UpdateComboBoxes();

            // ResetComboBox(comboBoxT1);

        //private static ObservableCollection<Trick> TrickData = TrickLibrary.TrickData; **CREATE ON THE FLY LIST
        //WHEN DOES A STATIC OBSERVABLE COLLECTION GET CREATED?

        }
        private static BindingList<Trick> cbTrickList1  = new BindingList<Trick>();
        private BindingSource bs1 = new BindingSource();

        private void PopulateTrickComboBox(Transition prevTran, Transition nextTran, ComboBox comboBox)
        {
            //list of applicable tricks based on prev and next tran
            List<Trick> applicableTricks = TrickLibrary.GetSuitableTrickList(prevTran, nextTran, false);

            if (cbTrickList1.Count > 0) { cbTrickList1.Clear();}
            //loop thru list and add names to list
            for (int i = 0; i<applicableTricks.Count;i++)
            {
                Trick trick = applicableTricks[i];
                if (TrickNotInList(trick,cbTrickList1)) //ignore favorability - by removing duplicates
                {
                    cbTrickList1.Add(trick);
                }
            }
             
        }
         
        private void ResetComboBox(ComboBox cb)
        {

            if (cb.SelectedIndex < 1)
            {
                cb.SelectedIndex = -1;
                cb.Text = "Select a Trick...";
            }
            
        }

        private bool TrickNotInList(Trick trick, BindingList<Trick> list)
        {
            for (int l = 0; l < list.Count; l++)
            {
                if (trick.Name.Equals(list[l].Name))
                {
                    return false;
                }
            }

            return true;
        }


        private void PopulateTranComboBox(Trick prevTrick, Trick nextTrick, ComboBox cb)
        {
            Stance outstance = null;
            Stance nextstance = null;

            if (prevTrick != null) { outstance = prevTrick.OutStance; }
            else { outstance = null; }
            if(nextTrick != null) { nextstance = nextTrick.InStance; }
            else { nextstance = null; }


            //list of applicable tricks based on prev and next tran
            List<Transition> applicableTrans = TransitionLibrary.GetSuitableTransList(outstance, nextstance);// TrickLibrary.GetSuitableTrickList(prevTran, nextTran);
            List<string> tranNames = new List<string>();

            //loop thru list and add names to list
            for (int i = 0; i < applicableTrans.Count; i++)
            {

                if (!tranNames.Contains(applicableTrans[i].TransName)) //ignore favorability - by removing duplicates
                {
                    tranNames.Add(applicableTrans[i].TransName);
                }

            }

            //cb.DisplayMember = Name; --USE THIS IN FUTURE

            //add items from suitable list


            cb.DataSource = tranNames;

        }

        //private void PopulateTrickStanceComboBox()
        //{
        //    cbInStanceT1.Items.Clear();
        //    cbInStanceT1.Text = "Select a Stance...";

        //    cbOutStanceT1.Items.Clear();
        //    cbOutStanceT1.Text = "Select a Stance...";


        //    //Trick trick = (Trick)comboBoxT1.SelectedItem;

        //    if(trick != null)
        //    {
        //        cbInStanceT1.Items.AddRange(trick.InStances);
        //        cbOutStanceT1.Items.AddRange(trick.OutStances);
        //    }
        //}

        private void UpdateComboBoxes()
        {
            //recreate transition object
            Transition tran1 = TransitionLibrary.Lookup(labelTrans1.Text);
            Transition tran2 = TransitionLibrary.Lookup(labelTrans2.Text);

            //recreate trick1 object
            Trick trick1 = TrickLibrary.Lookup(labelT1.Text);
            if(trick1 != null)
            {
                trick1.InStance = new Stance(T1_BeginStance.Text);
                trick1.OutStance = new Stance(T1_EndStance.Text);
            }

            //recreate trick2 object
            Trick trick2 = TrickLibrary.Lookup(labelT2.Text);
            if(trick2 != null)
            {
                trick2.InStance = new Stance(T2_BeginStance.Text);
                trick2.OutStance = new Stance(T2_EndStance.Text);
            }

            //recreate trick3 object
            Trick trick3 = TrickLibrary.Lookup(labelT3.Text);
            if(trick3 != null)
            {
                trick3.InStance = new Stance(T3_BeginStance.Text);
                trick3.OutStance = new Stance(T3_EndStance.Text);
            }


            //^^^-----make these static objects-------------------^^^
            

            //PopulateTranComboBox(trick1, trick2,comboBoxTran1);
            //PopulateTranComboBox(trick2, trick3,comboBoxTran2);

            //PopulateTrickComboBox(null, tran1, comboBoxT1);
            //PopulateTrickComboBox(tran1, tran2, comboBoxT2);
            //PopulateTrickComboBox(tran2, null, comboBoxT3);

            //PopulateTrickStanceComboBox();
        }

        //assign event to all buttons in program class
        //foreach (var button in Controls.OfType<Button>()) {
        //button.Click += button_Click;

        //private static void button_Click(object sender, EventArgs eventArgs)
        //{
        //    switch (((Button)sender).Name)
        //    {
        //        // find a way to disambiguate.
        //    }
        //}



        private void PrintRandomTrick(Button sender)
        {
            //get last character of button clicked. This will indicate the trick seqnr
            string btnName = sender.Name;
            string seqnr = btnName.Substring(btnName.Length-1);

            Transition prevTran = null;
            Transition nextTran = null;
            Label nameLabel = null;
            Label inLabel = null;
            Label outLabel = null;
            ListBox listBox = null;

            switch (seqnr)
            {
                case "1":
                    prevTran = null;
                    nextTran = TransitionLibrary.Lookup(labelTrans1.Text);

                    nameLabel = labelT1;
                    inLabel = T1_BeginStance;
                    outLabel = T1_EndStance;

                    listBox = listBoxT1;

                    break;
                case "2":
                    prevTran = TransitionLibrary.Lookup(labelTrans1.Text);
                    nextTran = TransitionLibrary.Lookup(labelTrans2.Text);
                    nameLabel = labelT2;
                    inLabel = T2_BeginStance;
                    outLabel = T2_EndStance;

                    listBox = listBoxT2;

                    break;
                case "3":
                    prevTran = TransitionLibrary.Lookup(labelTrans2.Text);
                    nextTran = null;
                    nameLabel = labelT3;
                    inLabel = T3_BeginStance;
                    outLabel = T3_EndStance;

                    listBox = listBoxT3;

                    break;
            }


            Trick trick = TrickLibrary.GetRandomTrick(prevTran, nextTran);

            nameLabel.Text = trick.DisplayName;
            inLabel.Text = trick.InStance.Name;
            outLabel.Text = trick.OutStance.Name;

            AddToListbox(listBox, trick);

            //TESTING
            //UpdateComboBoxes();
            //PopulateTrickStanceComboBox();
        }
        private void BtnTrick1_Click(object sender, EventArgs e)
        {
            //Transition prevTran = null;
            //Transition nextTran = TransitionLibrary.Lookup(labelTrans1.Text);

            //Trick trick = TrickLibrary.GetRandomTrick(null, null);
            //labelT1.Text = trick.DisplayName;
            //T1_BeginStance.Text = trick.InStance.Name;
            //T1_EndStance.Text = trick.OutStance.Name;

            //AddToListbox(listBoxT1, trick);

            PrintRandomTrick((Button)sender);
        }
        private void BtnTrick2_Click(object sender, EventArgs e)
        {
            PrintRandomTrick((Button)sender);
        }

        private void BtnTrick3_Click(object sender, EventArgs e)
        {
            PrintRandomTrick((Button)sender);
        }

        private void BtnTran1_Click(object sender, EventArgs e)
        {
            //contruct prev & next stances as null
            Stance prevStance = null;
            Stance nextStance = null;

            if (T1_EndStance.Text != "End Stance") //if T1 END stance exists
            {
                string strPrevStance = T1_EndStance.Text; //get Trick1 END stance
                prevStance = new Stance(strPrevStance);
            }

            if (T2_BeginStance.Text != "Begin Stance")//if T2 BEGIN stance exists
            {

                string strNextStance = T2_BeginStance.Text; //get Trick2 BEGIN stance
                nextStance = new Stance(strNextStance);
            }

            //get the transition
            Transition transition = AssignTransition(prevStance, nextStance);

            if(transition == null) { return; } //if no tranition found exit

            //adding transition to labels
            labelTrans1.Text = transition.TransName;
            Tran1Begin.Text = transition.StanceBegin.Name;
            Tran1End.Text = transition.StanceEnd.Name;

            AddToListbox(listBoxTran1, transition);

        }

        private void BtnTran2_Click(object sender, EventArgs e)
        {
            //contruct prev & next stances as null
            Stance prevStance = null;
            Stance nextStance = null;

            if (T2_EndStance.Text != "End Stance") //if T2 END stance exists
            {
                string strPrevStance = T2_EndStance.Text; //get Trick1 END stance
                prevStance = new Stance(strPrevStance);
            }

            if (T3_BeginStance.Text != "Begin Stance")//if T3 BEGIN stance exists
            {

                string strNextStance = T3_BeginStance.Text; //get Trick3 BEGIN stance
                nextStance = new Stance(strNextStance);
            }

            //get the transition
            Transition transition = AssignTransition(prevStance, nextStance);

            //adding transition to labels
            labelTrans2.Text = transition.TransName;
            Tran2Begin.Text = transition.StanceBegin.Name;
            Tran2End.Text = transition.StanceEnd.Name;

            AddToListbox(listBoxTran2, transition);
        }


        private void AddToListbox(ListBox listBox, object trickORtran)
        {
            //adds object (Trick or Transition) properties to list box 
            listBox.Items.Clear();

            if(trickORtran is Transition)
            {
                Transition tran = (Transition)trickORtran;
            }
            else if(trickORtran is Trick)
            {
                Trick trick = (Trick)trickORtran;
            }

            Type type = trickORtran.GetType();

            foreach (var prop in type.GetProperties())
            {
                //prop.PropertyType.Name
                if (GetStanceObjectName(prop.GetValue(trickORtran)) != null) //if properties is null dont output property name
                {
                    //listBox.Items.Add(prop.Name + " - " + GetStanceObjectName(prop.GetValue(trickORtran)));

                    
                    //listBox.Items.AddRange(new string[] { prop.Name, GetStanceObjectName(prop.GetValue(trickORtran)).ToString() });
                    listBox.Items.Add(prop.Name + " - " + GetStanceObjectName(prop.GetValue(trickORtran)));
                }
            }
            //anytime listbox is populated update combobox datasources
            //UpdateComboBoxes();

        }

        private object GetStanceObjectName(object obj)
        {
            //allows AddToListbox method to return stance NAME in list box. otherwise Stance object is listed
            if (obj is Stance)
            {
                Stance stance = (Stance)obj;
                return stance.Name;
            }
            if(obj is Variation)
            {
                Variation var = (Variation)obj;
                return var.DisplayName;
            }
            else
            {
                return obj;
            }
            
            
        }


        private Transition AssignTransition(Stance prevStance, Stance nextStance)
        {
            //library constructor
            //-TransitionLibrary transitionLibrary = new TransitionLibrary();

            //get random transition that fulfills criteria
            //-Transition tran = transitionLibrary.GetTransition(beginStance, endStance);

            Transition tran = TransitionLibrary.GetTransition(prevStance, nextStance);

            return tran;

        }


        //creates a non repeating instance of random
        static Random random = new Random();


        static string BeginStr = "Begin Stance";
        static string EndStr = "End Stance";

        private void ResetButton_Click(object sender, EventArgs e)
        {
            string beginstr = "Begin Stance";
            string endstr = "End Stance";

            T1_BeginStance.Text = beginstr;
            Tran1Begin.Text = beginstr;
            T2_BeginStance.Text = beginstr;
            Tran2Begin.Text = beginstr;
            T3_BeginStance.Text = beginstr;

            T1_EndStance.Text = endstr;
            Tran1End.Text = endstr;
            T2_EndStance.Text = endstr;
            Tran2End.Text = endstr;
            T3_EndStance.Text = endstr;

            T1Var.Text = "";
            T2Var.Text = "";
            T3Var.Text = "";

                
            labelT1.Text = "Trick 1";
            labelTrans1.Text = "Transition 1";
            labelT2.Text = "Trick 2";
            labelTrans2.Text = "Transition 2";
            labelT3.Text = "Trick 3";

            listBoxT1.Items.Clear();
            listBoxTran1.Items.Clear();
            listBoxT2.Items.Clear();
            listBoxTran2.Items.Clear();
            listBoxT3.Items.Clear();
        }

        private void BtnVariation1_Click(object sender, EventArgs e)
        {
            if(labelT1.Text != "Trick 1")
            {
                Trick thisTrick = TrickLibrary.Lookup(labelT1.Text);
                Stance thisInStance = new Stance(T1_BeginStance.Text);
                Stance thisOutStance = new Stance(T1_EndStance.Text);


                Variation variation = VariationLibrary.GetVariation(thisTrick);

                //Trick variatedTrick = new Trick()

                thisTrick.InStance = thisInStance;
                thisTrick.Variation = variation;
                T1Var.Text = variation.DisplayName;


                AddToListbox(listBoxT1, thisTrick);
            }
        }

        private void BtnVariation2_Click(object sender, EventArgs e)
        {
            if (labelT1.Text != "Trick 2")
            {
                Trick thisTrick = TrickLibrary.Lookup(labelT2.Text);
                Stance thisInStance = new Stance(T2_BeginStance.Text);
                Stance thisOutStance = new Stance(T2_EndStance.Text);


                Variation variation = VariationLibrary.GetVariation(thisTrick);

                //Trick variatedTrick = new Trick()

                thisTrick.InStance = thisInStance;
                thisTrick.Variation = variation;
                T2Var.Text = variation.DisplayName;


                AddToListbox(listBoxT1, thisTrick);
            }
        }

        private void BtnVariation3_Click(object sender, EventArgs e)
        {
            if (labelT1.Text != "Trick 3")
            {
                Trick thisTrick = TrickLibrary.Lookup(labelT3.Text);
                Stance thisInStance = new Stance(T3_BeginStance.Text);
                Stance thisOutStance = new Stance(T3_EndStance.Text);


                Variation variation = VariationLibrary.GetVariation(thisTrick);

                //Trick variatedTrick = new Trick()

                thisTrick.InStance = thisInStance;
                thisTrick.Variation = variation;
                T3Var.Text = variation.DisplayName;


                AddToListbox(listBoxT3, thisTrick);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //private void btnCBTrick1_Click(object sender, EventArgs e)
        //{


        //}

        //private void comboBoxT1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //MessageBox.Show("EVENT!");
        //    PopulateTrickStanceComboBox();
        //}
    }
}
