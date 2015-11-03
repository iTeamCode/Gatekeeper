using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FellowshipOne.Framework.Entitys
{
    [XmlRoot("DBGroups")]
    public class DBGroupConfig
    {
        [XmlElement("Database", typeof(DatabaseConfig))]
        public List<DatabaseConfig> Databases { get; set; }
    }

    public class DatabaseConfig
    {
        [XmlAttribute("DataSourceID")]
        public string DataSourceID { get; set; }

        [XmlAttribute("DatabaseType")]
        public string DatabaseType { get; set; }

        [XmlElement("ConnectionString")]
        public string ConnectionString { get; set; }
    }
}
