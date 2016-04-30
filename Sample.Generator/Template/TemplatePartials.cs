
namespace Sample.Generator.Template
{
    #region Partial Classes
    public partial class EntitiesTemplate
    {
        public EntitiesTemplateModel Model { get; set; }
    }

    public partial class DataLayerInterfaceTemplate
    {
        public DataLayerInterfaceTemplateModel Model { get; set; }

    }

    public partial class DataLayerEfTemplate
    {
        public DataLayerEfTemplateModel Model { get; set; }

    }

    public partial class BusinessInterfaceTemplate
    {
        public BusinessTemplateModel Model { get; set; }
    }

    public partial class BusinessManagerTemplate
    {
        public BusinessManagerTemplateModel Model { get; set; }
    }



    #endregion

    #region Models
    public class DataLayerEfTemplateModel : BaseTemplateModel { }
    public class EntitiesTemplateModel : BaseTemplateModel { }
    public class DataLayerInterfaceTemplateModel : BaseTemplateModel { }
    public class BusinessTemplateModel : BaseTemplateModel { }
    public class BusinessManagerTemplateModel : BaseTemplateModel { }
    #endregion

    #region Base Model
    public class BaseTemplateModel
    {
        public BaseTemplateModel()
        {
            ClassName = "null";
            NameSpaceName = "Sample";
        }
        public string ClassName { get; set; }
        public string ClassNameFirstLowerCase
        {
            get
            {
                var toLower = this.ClassName;
                if (this.ClassName != string.Empty && char.IsUpper(this.ClassName[0]))
                {
                    toLower = char.ToLower(this.ClassName[0]) + this.ClassName.Substring(1);
                }
                return toLower;
            }
        }
        public string NameSpaceName { get; set; }
    }
    #endregion
}
