using AutoMapper;

namespace Dynamics.Lesson
{
    internal partial class State
    {
        static IMapper mapper;

        string _presindent;

        public string Presindent { get => _presindent; set => _presindent = value; }

        internal RegionDto CreateRegion(RegionReq req)
        {
            Region region = new(req.Name);
            // return new RegionDto { Name = region.Name };
            return mapper.Map<RegionDto>(region);
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
            Provicia[] _province;
            Comune[] _comuni;
            public string Name { get => _name; }
            public int Population { get => _poplation; }
            public Provicia[] Province { get => _province; }
            public Comune[] Comuni { get => _comuni; set => _comuni = value; }

            public Region(string Name)
            {
                _name = Name;
                _province = CreateProvince();

            }

            Provicia[] CreateProvince()
            {
                return new Provicia[] { new Provicia("Milano") };
            }


        }
        private class Provicia
        {
            string _name;
            int _poplation;
            Comune[] _comuni;
            public string Name { get => _name; }
            public int Population { get => _poplation; }
            public Comune[] Comuni { get => _comuni; }

            public Provicia(string Name)
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

            public Comune(string Name)
            {
                _name = Name;
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
