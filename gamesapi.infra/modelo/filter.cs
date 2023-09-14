namespace gamesapi.infra.modelo
{
    public class filter
    {
        public filter() { filtroLimit = 100; }
      
        public filter(float _limit)
        {
            int result  = 0;
            if(_limit < 0 && int.TryParse(_limit.ToString(), out result))
                filtroLimit = int.Parse(_limit.ToString());
        }
        public int filtroLimit { get; set; }
        public string? charname { get; set; }
        public int pageAtual { get; set; }
    }
    
    public class Amiibo
    {
        public string? amiiboSeries { get; set; }
        public string? character { get; set; }
        public string? gameSeries { get; set; }
        public string? head { get; set; }
        public string? image { get; set; }
        public string? name { get; set; }
        public string? tail { get; set; }
        public string? type { get; set; }
    }

    public class Amiibooo : Amiibo
    {
        public string? thecharacter { get; set; }
    }
    
    public class RootObject
    {
        public List<Amiibo>? amiibo { get; set; }
    }

}
