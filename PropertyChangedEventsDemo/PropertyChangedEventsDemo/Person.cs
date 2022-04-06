using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChangedEventsDemo
{
    public class Person
    {
        private string? firstName;
        private string? lastName;

        public string FirstName { get {return firstName;} set { firstName = value; } }
        public string LastName { get {return lastName;} set {lastName = value;} }

        /// <summary>
        /// 
        /// </summary>
        Person()
        {
            firstName = "Joe";
            lastName = "Smith";
        }

        public Person(string fn, string ln)
        {
            firstName = fn;
            lastName = ln;
        }

        private void PropertyChanged()
        {

        }
    }
}
