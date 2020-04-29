using System.Collections.Generic;
using System.Linq;

namespace Octus.GetData
{
    public class SpecializationManager
    {
        List<Specialist> _listOfSpecialists;
        List<Specialization> _listyOfSpecializations;

        public SpecializationManager()
        {
            PrepareLitOsSpecializations();
        }

        public string GetSpecializations()
        {
            string serilizedList = Newtonsoft.Json.JsonConvert.SerializeObject(_listyOfSpecializations);
            return serilizedList;
        }

        public string GetSpecialists(string name)
        {
            List<Specialist> _filteredList = _listOfSpecialists.Where(x => x.Name.Equals(name)).ToList();
            string serilizedList = Newtonsoft.Json.JsonConvert.SerializeObject(_filteredList);
            return serilizedList;
        }

        private void PrepareLitOsSpecializations()
        {
            _listyOfSpecializations = new List<Specialization>
            {
                new Specialization("Especialização 1"),
                new Specialization("Especialização 2"),
                new Specialization("Especialização 3"),
                new Specialization("Especialização 4"),
                new Specialization("Especialização 5"),
            };
        }

        private void PrepareLitOsSpecialists()
        {
            _listOfSpecialists = new List<Specialist>
            {
                new Specialist("Dorote","https://cdn.pixabay.com/photo/2012/05/07/15/07/penguin-48559_960_720.png",_listyOfSpecializations[0]),
                new Specialist("Marta","https://cdn.pixabay.com/photo/2013/07/13/11/43/tux-158547_960_720.png",_listyOfSpecializations[0]),
                new Specialist("João","https://assets.pinshape.com/uploads/image/file/140673/linux-tux-high-five-desk-model-3d-printing-140673.png",_listyOfSpecializations[0]),

                new Specialist("Alberto","https://cdn.pixabay.com/photo/2012/05/07/15/07/penguin-48559_960_720.png",_listyOfSpecializations[1]),
                new Specialist("Pedro","https://cdn.pixabay.com/photo/2013/07/13/11/43/tux-158547_960_720.png",_listyOfSpecializations[1]),

                new Specialist("Maria","https://assets.pinshape.com/uploads/image/file/140673/linux-tux-high-five-desk-model-3d-printing-140673.png",_listyOfSpecializations[2]),

                new Specialist("Brnardo","https://cdn.pixabay.com/photo/2012/05/07/15/07/penguin-48559_960_720.png",_listyOfSpecializations[3]),
                new Specialist("Ângela","https://cdn.pixabay.com/photo/2013/07/13/11/43/tux-158547_960_720.png",_listyOfSpecializations[3]),

                new Specialist("Manuelle","https://assets.pinshape.com/uploads/image/file/140673/linux-tux-high-five-desk-model-3d-printing-140673.png",_listyOfSpecializations[4]),
                new Specialist("Eduardo","https://cdn.pixabay.com/photo/2012/05/07/15/07/penguin-48559_960_720.png",_listyOfSpecializations[4]),

            };
        }
    }
}
