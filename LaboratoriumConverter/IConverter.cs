using LaboratoriumTypeLib;

namespace LaboratoriumConverter
{
    public interface IConverter
    {
        MathObject Convert(string line);
    }
}