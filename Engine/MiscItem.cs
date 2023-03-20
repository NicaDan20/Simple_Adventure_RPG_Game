using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonSubTypes;


namespace Engine
{
    public class MiscItem : Item
    {
        public override string Type
        {
            get { return "MISC"; }
        }

        public MiscItem(int _id, string _name, string _namePlural) : base(_id, _name, _namePlural) { }
    }
}
