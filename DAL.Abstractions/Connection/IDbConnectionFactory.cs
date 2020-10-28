using System.Data;

namespace BSF.DAL.Abstractions.Connection
{
    /// <summary>
    /// Интерфейс для соединения с БД
    /// </summary>
    public interface IDbConnectionFactory
    {
        ///<summary>
        /// Возвращает соединение.
        ///</summary>
        IDbConnection GetConnection();
    }
}
