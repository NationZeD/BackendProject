namespace BackendProject.Shared.REST;

public class QueryBuilder
{
    private readonly List<QueryParameter> _parameters;

    public QueryBuilder()
    {
        _parameters = new List<QueryParameter>();
    }

    public QueryBuilder Append(QueryParameter parameter)
    {
        _parameters.Add(parameter);
        return this;
    }

    public QueryBuilder Append(string key, string value)
    {
        _parameters.Add(new QueryParameter(key, value));
        return this;
    }

    public IReadOnlyList<QueryParameter> Parameters => _parameters.AsReadOnly();
}