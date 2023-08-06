namespace StambenaZgradaLibrary.DTOs;

public class ImenaStanaraView
{
		public int ID_stanari;

        public string? Ime_stanara {get; set;} 
        public NivoView? Nivo {get; set;} 
		
    public ImenaStanaraView()
    {
    }

    internal ImenaStanaraView(ImenaStanara? z)
    {
        if (z != null)
        {
           ID_stanari =z.ID_stanari;
		   Ime_stanara = z.Ime_stanara;
		  // Nivo = z.Nivo;
        }
    }
}
