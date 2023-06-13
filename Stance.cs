using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFTrickingComboGenerator
{
    public class Stance 
    {
        private string name;
        private string foot;
        private bool isInDOM;
        private int id; //use this to iterate rotations at a late date

        public Stance(string name)
        {

            Name = name;
            Foot = SetFoot(name);
            IsInDOM = SetIsInDOM(name);
            ID = SetID(name);
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        public string Foot
        {
            get { return foot; }
            set
            { this.foot = value; }
        }

        private string SetFoot(string name)
        {
            if(name == "Complete" || name == "Mega")
            {
                foot = "Left";
            }
            else if (name == "Hyper" || name == "Semi")
            {
                foot = "Right";
            }

            return foot;
        }

        public bool IsInDOM
        {
            get { return isInDOM; }
            set
            { this.isInDOM = value; }
        }


        private bool SetIsInDOM(string name)
        {
            if (name == "Complete" || name == "Hyper")
            {
                isInDOM = false;
            }
            else if (name == "Mega" || name == "Semi")
            {
                isInDOM = true;
            }

            return isInDOM;
        }

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
            }
        }

        private int SetID(string name)
        {
            switch(name)
            {
                case "Complete":
                    id = 1;
                    break;
                case "Hyper":
                    id = 2;
                    break;
                case "Mega":
                    id = 3;
                    break;
                case "Semi":
                    id = 4;
                    break;
            }
            return id;
        }
    }
}
