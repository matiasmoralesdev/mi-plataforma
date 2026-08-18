using System.Text.Json.Serialization;

namespace MiPlataforma.Kernel;

public class PagedList<T>
{
    [JsonConstructor]
    public PagedList() //Constructor por defecto necesario para poder serializar las respuestas
        : this([])
    {
    }

    public PagedList(IEnumerable<T> collection)
        : this(collection, 1, int.MaxValue, 0)
    {
    }

    public PagedList(IEnumerable<T> collection, int page, int pageSize, int totalCount)
    {
        Items = [.. collection];
        Page = page;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    /// <summary>
    /// Nº de página
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// Tamaño de página (count)
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Nº total de elementos
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Nº total de páginas
    /// </summary>
    public int PageCount { get { return PageSize > 0 ? (int)decimal.Ceiling((decimal)TotalCount / PageSize) : 0; } }

    public T[] Items { get; set; }

    public int Count => Items.Length;
}
