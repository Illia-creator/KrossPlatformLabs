namespace Lab6.Api.Services;

public interface IHttpContextStorage
{
    void Set<TEntity>(TEntity entity, string key);
    object Get<TEntity>(string key);
}

public class HttpContextStorage : IHttpContextStorage
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextStorage(IHttpContextAccessor httpContextAccessor)
        => _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

    public void Set<TEntity>(TEntity entity, string key)
        => _httpContextAccessor.HttpContext?.Items.TryAdd(key, entity);

    public object Get<TEntity>(string key)
    {
        if (_httpContextAccessor.HttpContext is null) return null;

        if (_httpContextAccessor.HttpContext.Items.TryGetValue(key, out var entity)) return entity;

        return null;
    }
}