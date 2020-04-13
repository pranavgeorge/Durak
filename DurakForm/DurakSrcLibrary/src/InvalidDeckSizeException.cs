using System;
namespace DurakSrcLibrary
{
    [Serializable]
    public class InvalidDeckSizeException : Exception
    {
        public InvalidDeckSizeException() : base()
        {
        }

        public InvalidDeckSizeException(string aName) : base(aName)
        {
        }

        public InvalidDeckSizeException(string aName, Exception inner) : base(aName, inner)
        {

        }
    }
}
