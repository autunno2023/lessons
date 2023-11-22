namespace Dynamics.Lesson
{

    internal partial class State
    {

        public class Dto
        {
            public string? Name { get; set; }
            public int? Population { get; set; }

        }
        public class StateDto : Dto
        {
            public RegioneDto[] data { get; set; }
        }

        public class RegioneDto : Dto
        {
            public ProvinciaDto[]? data { get; set; }
        }
        public class ProvinciaDto : Dto
        {
            public ComuneDto[]? data { get; set; }
        }
        public class ComuneDto : Dto
        {
            public CittadinoDto[]? data { get; set; }
        }
        public class CittadinoDto
        {
            public string? Name { get; set; }
        }
    }


}
