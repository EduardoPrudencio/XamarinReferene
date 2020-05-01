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
            PrepareLitOsSpecialists();
        }

        public string GetSpecializations()
        {
            string serilizedList = Newtonsoft.Json.JsonConvert.SerializeObject(_listyOfSpecializations);
            return serilizedList;
        }

        public string GetSpecialists(string name)
        {
            List<Specialist> _filteredList = _listOfSpecialists.Where(x => x.Specialization.Name.Equals(name)).ToList();

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
                new Specialist("Crotilde","https://s2.glbimg.com/HOos1Mu3tztptizOaf1ZuE4mMRM=/290x386/s.glbimg.com/jo/g1/f/original/2012/04/13/tereza-fotoruim_300_400.jpg",_listyOfSpecializations[0]),
                new Specialist("Marta","https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQwo2sONbkrbKQKt20gzNjLDND2GYm86caS_w6Si4n68DdQYoNA&usqp=CAU",_listyOfSpecializations[0]),
                new Specialist("João","https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTQbQw-M26y18LDQlEcEFIs6mFDOyRjih2UO_8ka5SZeAyVX8CI&usqp=CAU",_listyOfSpecializations[0]),

                new Specialist("Alberto","https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSIyqkbzziRjqjESQmrhgmXQG4rIcCF2GmnRClkqUBC9LmKjgEs&usqp=CAU",_listyOfSpecializations[1]),
                new Specialist("Pedro","https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTYqG8EzJysthqKA5keOvguEDLfnD0ZeZCIX0Roi33hzmUwDSO3&usqp=CAU",_listyOfSpecializations[1]),

                new Specialist("Maria","https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSDgQvuIPpGDu3EbYWxSEPo0n3LKaVfgCdcUTuL9g26GOeCL49M&usqp=CAU",_listyOfSpecializations[2]),

                new Specialist("Bernardo","https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSTxutvishAXvfEKnsoCCnz5ihPBRXAHIn1H_KkxZBCmKNNpLQ3&usqp=CAU",_listyOfSpecializations[3]),
                new Specialist("Ângela","https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTubYgiQuIRhSGTQbvrKkn1ertaFeQ4G_DX7quyDOTuUL1yMsDz&usqp=CAU",_listyOfSpecializations[3]),

                new Specialist("Manuelle","https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSFEjOv64HAlBayR50o2ttjWmGI-pBDkTGTWJ14lpCJ4R5EruKx&usqp=CAU",_listyOfSpecializations[4]),
                new Specialist("Eduardo","https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSC3pU8x40DHnMIeiYR7lTsNP1c3dHy1dnLb8tAWo1Arn2lDW7V&usqp=CAU",_listyOfSpecializations[4]),

            };
        }
    }
}
