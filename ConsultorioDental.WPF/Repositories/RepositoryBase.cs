using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ConsultorioDental.WPF.Repositories;
public abstract class RepositoryBase
{
    private readonly string _connectionString = string.Empty;

    public RepositoryBase()
    {
        //_connectionString = "Server=(local); Database=dbConsultorioDental; Integrated Security=true; TrustServerCertificate=True";
        _connectionString = App.Configuration.GetConnectionString("DefaultConnection");
    }

    protected SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}

