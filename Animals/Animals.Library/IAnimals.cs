namespace Animals.Library
{
    public interface IAnimal
    {
        // an interface is a contract that a class has to follow
        // specifying some methods it needs to have, with their
        // arguments and return type.

        // no implimentation possible in interfaces
        // no data (properties OK)
        // just method names, arguments, return type

        // any IAnimal class must have a Name property

        string Name { get; set; }

        void MakeSound();

        void GoTo(string location);

        // no "void type" or "void class"; means return nothing

        // every interface members has the same access modifier as the whole interface




    }
}