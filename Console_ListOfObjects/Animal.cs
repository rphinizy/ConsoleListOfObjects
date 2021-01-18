using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_ListOfObjects
{
    class Animal
    {
        #region ENUMS
        public enum Diet
        {
            herbivore,
            carnivore,
            omnivore,
            unknown,
        }
        #endregion

        #region FIELDS

        private string _name;
        private int _age;
        private bool _isExtinct;
        private Diet _food;



        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public bool IsExtinct
        {
            get { return _isExtinct; }
            set { _isExtinct = value; }
        }

        public Diet Food
        {
            get { return _food; }
            set { _food = value; }
        }

        #endregion

        #region CONSTRUCTORS
        public Animal()
        {

        }

        public Animal(string name, int age, bool isExtinct)
        {
            _name = name;
            _age = age;
            _isExtinct = isExtinct;

        }

        #endregion

    }

}
