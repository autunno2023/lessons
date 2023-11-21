using AutoMapper;

namespace Dynamics.Lesson
{
    internal partial class State
    {
        static IMapper mapper;
        string _name;
        int _population;
        string _presindent;
        Regione[] _regioni;


        public string Name { get => _name; set => _name = value; }
        private Regione[] Regioni { get => _regioni; }
        public int Population { get; private set; } = 600000;

        public State()
        {
            configureMapper();
        }
        void configureMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<State, StateDto>()
                 .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.Population))
                 .ForMember(dest => dest.data, opt => opt.MapFrom(src => src.Regioni));

                cfg.CreateMap<Regione, RegioneDto>()
                   .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.Population))
                   .ForMember(dest => dest.data, opt => opt.MapFrom(src => src.Province));

                cfg.CreateMap<Provincia, ProvinciaDto>()
                   .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.Population))
                   .ForMember(dest => dest.data, opt => opt.MapFrom(src => src.Comuni));

                cfg.CreateMap<Comune, ComuneDto>()
                   .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.Population))
                   .ForMember(dest => dest.data, opt => opt.MapFrom(src => src.Cittanini));

                cfg.CreateMap<Cittadino, CittadinoDto>()
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

                //cfg.CreateMap<Regione, StateDto>()
                //.ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.Population))
                //.ForMember(dest => dest.data, opt => opt.MapFrom(src => new RegioneDto[] { mapper.Map<RegioneDto>(src) }));
            });
            mapper = config.CreateMapper();
        }
        public StateDto CreateRegione(string Name)
        {

            _regioni = createRegioni();
            StateDto regionDto = mapper.Map<StateDto>(this);
            return regionDto;
        }
        Regione[] createRegioni()
        {
            return new Regione[] { new Regione("Lombardia"), new Regione("Veneto") };
        }
        #region Nested Class
        private class Regione
        {
            string _name;
            int _poplation;
            Provincia[] _province;
            Comune[] _comuni;
            public string Name { get => _name; }
            public int Population { get => _poplation; }
            public Provincia[] Province { get => _province; }
            public Comune[] Comuni { get => _comuni; set => _comuni = value; }

            public Regione(string Name)
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
            Cittadino[] _cittanini;
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
                return new Comune[] { new Comune("Lodi") };
            }
        }
        private class Comune
        {
            string _name;
            int _population;
            Cittadino[] _cittanini;

            public string Name { get => _name; }
            public int Population { get => _population; }
            public Cittadino[] Cittanini { get => _cittanini; }

            public Comune(string Name)
            {
                _name = Name;
                _cittanini = CreateCittadini();
            }
            public Cittadino[] CreateCittadini()
            {
                return new Cittadino[] { new Cittadino("Bruno") };
            }


        }
        private class Cittadino
        {
            string _name;
            int _population;
            public string Name { get => _name; }
            public int Population { get => _population; }

            public Cittadino(string Name)
            {
                _name = Name;
            }

        }

        #endregion
    }


}
