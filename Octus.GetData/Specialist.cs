namespace Octus.GetData
{
    public class Specialist
    {

        public Specialist(string name, string urlImage, Specialization specialization)
        {
            Name = name;
            LinkImage = urlImage;
            Specialization = specialization;
        }

        public string Name { get; set; }

        public string LinkImage { get; set; }

        public Specialization Specialization { get; set; }
    }
}
