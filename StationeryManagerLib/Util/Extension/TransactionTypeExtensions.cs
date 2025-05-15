using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationeryManagerLib.Enum;

namespace StationeryManagerLib.Util.Extension
{
    public static class TransactionTypeExtensions
    {
        public static string ToFriendlyString(this TransactionTypeEnum type)
        {
            return type switch
            {
                TransactionTypeEnum.Import => "Nhập kho",
                TransactionTypeEnum.Export => "Xuất kho",
                _ => type.ToString()
            };
        }
    }
}
