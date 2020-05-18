namespace Octus.Models
{
    public class Especializacao
    {
        private int _iconNameInt;

        public Especializacao(string name, int iconName)
        {
            Name = name;
            _iconNameInt = iconName;
        }

        public string Name { get; }


    public string IconName { get {return ((char)_iconNameInt).ToString(); } }
    }
}
