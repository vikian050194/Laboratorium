namespace LaboratoriumCore
{
    public class NameManager
    {
        private char _currentName;
        private int _extendedNamesCount;
        private int _namesCount;

        public NameManager()
        {
            Reset();
        }

        public void Reset()
        {
            _currentName = 'a';
            _currentName--;

            _extendedNamesCount = 0;
            _namesCount = 0;
        }

        public string GetNextName()
        {
            _namesCount++;

            if (_namesCount <= 26)
            {
                _currentName++;
                return _currentName.ToString();
            }

            _extendedNamesCount++;
            return "x" + _extendedNamesCount;
        }
    }
}
