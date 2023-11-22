using AutoMapper;
using System;
using static Dynamics.Lesson.State;

namespace Dynamics.Lesson
{
    internal class Program
    {
        static IMapper mapper;
        static void Main(string[] args)
        {
            configureMapper();
            State italy = new State();
            italy.Name = "Italy";

            dynamic RegioneFlatObj = italy.CreateRegione();

            Console.WriteLine(RegioneFlatObj.Name);
            Console.WriteLine(RegioneFlatObj.Population);
            Console.WriteLine(RegioneFlatObj.Regioni); // Non è chaive chiave/valore[string]

            StateDto RegioneComplexObj = italy.CreateRegione("Lombardia");
            State state = mapper.Map<State>(RegioneComplexObj);


            dynamic RegioneComplexObjDynamic = italy.CreateRegioneDynamic();


            Console.WriteLine(RegioneComplexObjDynamic.Name);
            Console.WriteLine(RegioneComplexObjDynamic.Population);
            Console.WriteLine(RegioneComplexObjDynamic.Regioni[0].Name);

            foreach (var regione in RegioneComplexObjDynamic.Regioni)
            {
                Console.WriteLine($"regione:{regione.Name} ");

                Console.WriteLine(regione.Population);
                foreach (var provincia in regione.Province)
                {
                    Console.WriteLine($"    provincia:{provincia.Name} ");
                }
            }

            PrintDynamic(RegioneComplexObj);


            Console.Read();
        }
        static void configureMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StateDto, State>()
                .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.Population));
                // .ForMember(dest => dest.Regioni, opt => opt.MapFrom(src => src.data));

                cfg.CreateMap<RegioneDto, Regione>()
                   .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.Population))
                   .ForMember(dest => dest.Province, opt => opt.MapFrom(src => src.data));

                cfg.CreateMap<ProvinciaDto, Provincia>()
                   .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.Population))
                   .ForMember(dest => dest.Comuni, opt => opt.MapFrom(src => src.data));

                cfg.CreateMap<ComuneDto, Comune>()
                   .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.Population))
                   .ForMember(dest => dest.Cittanini, opt => opt.MapFrom(src => src.data));

                cfg.CreateMap<CittadinoDto, Cittadino>()
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
                //Se ci sono properties di class  che sono private dovrò utilizzare un mix di auomapper e dynamic  

            });

            mapper = config.CreateMapper();
        }



        static void PrintDynamic(dynamic dto)
        {
            if (dto != null)
            {
                foreach (var property in dto.GetType().GetProperties())
                {
                    var propertyValue = property.GetValue(dto, null);

                    if (!property.PropertyType.IsArray)
                    {
                        if (propertyValue != null)
                        {
                            Console.WriteLine($" : {property.Name}: {propertyValue}");
                        }
                    }
                    else
                    {
                        foreach (var element in propertyValue)
                        {
                            Console.WriteLine(element.GetType().Name.ToUpper());
                            PrintDynamic(element);
                        }
                    }
                }
            }
        }
    }
}



