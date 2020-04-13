using System;
namespace DurakSrcLibrary
{
    [Serializable]
    public class InitializationException : Exception
    {
        public InitializationException(): base()
        {

        }

        public InitializationException(string aName) : base(aName)
        {

        }
        public InitializationException(string aName, Exception inner) : base(aName, inner)
        {

        }
        
    }
}
