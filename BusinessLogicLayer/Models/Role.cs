using System;
using System.Diagnostics;

namespace Store.BusinessLogicLayer.Models
{
    public class Role
    {
        private string name { get; set; }

        public Role() { }

        public Role(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name
        {
            get
            {
                Debug.Assert(name != null);
                return name;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Name", "Valid name is mandatory!");

                string oldValue = name;
                try
                {
                    name = value;
                }
                catch
                {
                    name = oldValue;
                    throw;
                }
            }
        }
    }
}
