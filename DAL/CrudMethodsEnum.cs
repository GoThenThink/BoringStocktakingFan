using System.Dynamic;

namespace BSF.DAL
{
    /// <summary>
    /// Перечисление для маппинга базовых методов в репозиториях
    /// </summary>
    public enum CrudMethodsEnum : byte
    {
        /// <summary/>
        Create = 0,
        /// <summary/>
        Delete = 1,
        /// <summary/>
        Get = 2,
        /// <summary/>
        GetList = 3,
        /// <summary/>
        Update = 4
    }
}
