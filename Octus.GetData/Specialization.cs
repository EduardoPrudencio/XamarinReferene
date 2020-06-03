namespace Octus.GetData
{
    public class Specialization
    {

        public Specialization(string name, int icon)
        {
            Name = name;
            IconName = icon;
        }

        public int IconName { get; set; }
        public string Name { get; set; }
    }
}
