
namespace DSR_MAGALU_DATA.Entities
{
    public class Paginacao<T> where T : class
    {
        public IEnumerable<T> Itens { get; set; } = new List<T>();
        public int Pagina { get; set; }
        public int QuantidadeTotalItens { get; set; }
        public int TamanhoPagina { get; set; }
        public int UltimaPagina
        {
            get
            {
                var ultimaPagina = Convert.ToInt32(Math.Ceiling((double)QuantidadeTotalItens / (double)TamanhoPagina));

                return ultimaPagina;
            }
        }

        public static Paginacao<TDestino> DePaginacao<TDestino, TOrigem>(Paginacao<TOrigem> origem)
            where TDestino : class, ViewModelBase<TDestino, TOrigem> where TOrigem : class
        {
            return new Paginacao<TDestino>
            {
                Itens = origem.Itens.Select(TDestino.DeModel),
                Pagina = origem.Pagina,
                QuantidadeTotalItens = origem.QuantidadeTotalItens,
                TamanhoPagina = origem.TamanhoPagina
            };
        }
    }
}
