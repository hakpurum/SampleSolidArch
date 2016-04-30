using System.Text;
using Microsoft.SqlServer.Management.Smo;

namespace Sample.Generator.Helper
{
    public static class SqlServerHelper
    {
        public static string ToCSharpType(this DataType type)
        {
            var val = "object";
            #region SqlDataType Convert
            switch (type.SqlDataType)
            {
                case SqlDataType.BigInt:
                    val = "long";
                    break;
                case SqlDataType.Binary:
                    val = "byte[]";
                    break;
                case SqlDataType.Bit:
                    val = "bool";
                    break;
                case SqlDataType.Char:
                    val = "string";
                    break;
                case SqlDataType.Date:
                    val = "DateTime";
                    break;
                case SqlDataType.DateTime:
                    val = "DateTime";
                    break;
                case SqlDataType.DateTime2:
                    val = "DateTime";
                    break;
                case SqlDataType.DateTimeOffset:
                    val = "DateTimeOffset";
                    break;
                case SqlDataType.Decimal:
                    val = "decimal";
                    break;
                case SqlDataType.Float:
                    val = "float";
                    break;
                case SqlDataType.Image:
                    val = "byte[]";
                    break;
                case SqlDataType.Int:
                    val = "int";
                    break;
                case SqlDataType.Money:
                    val = "decimal";
                    break;
                case SqlDataType.NChar:
                    val = "char";
                    break;
                case SqlDataType.NText:
                    val = "string";
                    break;
                case SqlDataType.NVarChar:
                    val = "string";
                    break;
                case SqlDataType.NVarCharMax:
                    val = "string";
                    break;
                case SqlDataType.Numeric:
                    val = "decimal";
                    break;
                case SqlDataType.Real:
                    val = "double";
                    break;
                case SqlDataType.SmallDateTime:
                    val = "DateTime";
                    break;
                case SqlDataType.SmallInt:
                    val = "short";
                    break;
                case SqlDataType.SmallMoney:
                    val = "decimal";
                    break;
                case SqlDataType.Text:
                    val = "string";
                    break;
                case SqlDataType.Time:
                    val = "TimeSpan";
                    break;
                case SqlDataType.Timestamp:
                    val = "DateTime";
                    break;
                case SqlDataType.TinyInt:
                    val = "byte";
                    break;
                case SqlDataType.UniqueIdentifier:
                    val = "Guid";
                    break;
                case SqlDataType.VarBinary:
                    val = "byte[]";
                    break;
                case SqlDataType.VarBinaryMax:
                    val = "byte[]";
                    break;
                case SqlDataType.VarChar:
                    val = "string";
                    break;
                case SqlDataType.VarCharMax:
                    val = "string";
                    break;
                default:
                    val = "";
                    break;
            } 
            #endregion

            return val;
        }
        public static string ReplaceWith(this string p)
        {
            if (p.EndsWith("ies")) { p = p.Remove(p.Length - 3, 3) + "y"; }
            else if (p.EndsWith("s")) { p = p.Remove(p.Length - 1, 1); }

            return p;
        }
        public static string ToProperties(this ColumnCollection columns)
        {
            var builder = new StringBuilder();
            foreach (Column column in columns)
            {
                var cSharpType = column.DataType.ToCSharpType();
                if (column.InPrimaryKey)
                {
                    builder.AppendLine("[Key]");
                }
                var str = "        public virtual {CSharpType} {ColumnName} { get; set; }"
                            .Replace("{CSharpType}", cSharpType)
                            .Replace("{ColumnName}", column.Name);

                if (column.InPrimaryKey)
                {
                    str = str.Replace("public virtual", "public ");
                }

                builder.AppendLine(str);
            }

            return builder.ToString();
        }
    }
}
