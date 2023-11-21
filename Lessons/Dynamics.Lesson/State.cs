using AutoMapper;

namespace Dynamics.Lesson
{
    internal partial class State
    {
        static IMapper mapper;

        string _presindent;

        public string Presindent { get => _presindent; set => _presindent = value; }

        internal RegionDto CreateRegion(dynamic req)
        {
            Region region = new(req.Name);
            // return new RegionDto { Name = region.Name }; 
            RegionDto regionDto = mapper.Map<RegionDto>(region);
            return regionDto;
        }
        public State()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Region, RegionDto>()
                .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.Population))
                .ForMember(dest => dest.Province, opt => opt.MapFrom(src => src.Province)));
            mapper = config.CreateMapper();

        }
        #region Nested Class
        private class Region
        {
            string _name;
            int _poplation;
            Provincia[] _province;
            Comune[] _comuni;
            public string Name { get => _name; }
            public int Population { get => _poplation; }
            public Provincia[] Province { get => _province; }
            public Comune[] Comuni { get => _comuni; set => _comuni = value; }

            public Region(string Name)
            {
                _name = Name;
                _province = CreateProvince();

            }
            Provincia[] CreateProvince()
            {
                return new Provincia[] { new Provincia("Milano") };
            }
        }
        private class Provincia
        {
            string _name;
            int _poplation;
            Comune[] _comuni;
            Cittanino[] _cittanini;
            public string Name { get => _name; }
            public int Population { get => _poplation; }
            public Comune[] Comuni { get => _comuni; }

            public Provincia(string Name)
            {
                _name = Name;
                _comuni = CreateComuni();

            }
            public Comune[] CreateComuni()
            {
                return new Comune[] { new Comune("Milano") };
            }
        }
        private class Comune
        {
            string _name;
            int _population;
            Cittanino[] _cittanini;

            public string Name { get => _name; }
            public int Population { get => _population; }
            public Cittanino[] Cittanini { get => _cittanini; }

            public Comune(string Name)
            {
                _name = Name;
                _cittanini = CreateCittadini();
            }
            public Cittanino[] CreateCittadini()
            {
                return new Cittanino[] { new Cittanino("Bruno") };
            }


        }
        private class Cittanino
        {
            string _name;
            int _population;
            public string Name { get => _name; }
            public int Population { get => _population; }

            public Cittanino(string Name)
            {
                _name = Name;
            }

        }

        #endregion
    }


}
