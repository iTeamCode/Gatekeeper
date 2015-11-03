using System;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;
using FellowshipOne.Framework.Entitys;
using System.Collections.Generic;

namespace Gatekeeper.Framework.DataAccess
{
    public abstract class DataManager
    {
        #region Command Dictionary
        /// <summary>
        /// Init Dictionary Capacity
        /// </summary>
        private const int CONST_DICTIONARYCAPACITY_COMMAND = 100;
        private const int CONST_DICTIONARYCAPACITY_DATABASE = 10;

        /// <summary>
        /// 1 local db, 2 qa db
        /// Default is local db
        /// </summary>
        private static int DatabaseEnv = 1;

        public static void SetDatabaseEnv(int dbEnv)
        {
            DatabaseEnv = dbEnv;
            LoadDatabaseDictionary();
        }

        private static Dictionary<string, DataCommandConfig> _commandDictionary;
        /// <summary>
        /// Command Dictionary (Share to all entity of DataManager object.)
        /// </summary>
        protected static Dictionary<string, DataCommandConfig> CommandDictionary
        {
            get {
                if (_commandDictionary == null)
                {
                    _commandDictionary = new Dictionary<string, DataCommandConfig>(CONST_DICTIONARYCAPACITY_COMMAND);
                }
                return _commandDictionary;
            }
        }

        private static Dictionary<string, DatabaseConfig> _databaseDictionary;
        protected static Dictionary<string, DatabaseConfig> DatabaseDictionary
        {
            get
            {
                if (_databaseDictionary == null)
                {
                    _databaseDictionary = new Dictionary<string, DatabaseConfig>(CONST_DICTIONARYCAPACITY_DATABASE);
                }
                return _databaseDictionary;
            }
        }
        

        static DataManager()
        {
            LoadCommandDictionary();
            LoadDatabaseDictionary();
        }

        public static void LoadCommandDictionary()
        {
            #region 1.获取 XML 数据
            //1.获取 XML 数据【可修改问配置文件】
            string commandFilePath = ConfigurationManager.AppSettings["CommandFilePath"];
            string strNamespace = @"https:\\FellowshipOne\Framework\DataOperators";

            DirectoryInfo dirCommand = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + commandFilePath);
            FileInfo[] fileCommand = dirCommand.GetFiles("DataCommand*.xml");

            DataOperatorsConfig dataOperators = new DataOperatorsConfig();
            dataOperators.DataCommands = new List<DataCommandConfig>();

            foreach (FileInfo temp in fileCommand)
            {
                using (FileStream fs = temp.OpenRead())
                {
                    XmlSerializer xmls = new XmlSerializer(typeof(DataOperatorsConfig), strNamespace);
                    DataOperatorsConfig tempDataOperators = xmls.Deserialize(fs) as DataOperatorsConfig;
                    dataOperators.DataCommands.AddRange(tempDataOperators.DataCommands);
                }
            }

            //FileStream fs = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + commandFilePath);
            
            
            #endregion

            #region 2.Fill the Command Dictionary.
            //Fill the Command Dictionary.
            if (dataOperators == null || dataOperators.DataCommands == null)
            {
                throw new Exception(string.Format("CodePower Exception: Load Command failed!"));
            }

            DataManager.CommandDictionary.Clear();
            foreach (var cmd in dataOperators.DataCommands)
            {
                DataManager.CommandDictionary.Add(cmd.Name, cmd);
            }
            #endregion 2.Fill the Command Dictionary.
        }

        public static void LoadDatabaseDictionary()
        {
            #region 1.获取 XML 数据
            //1.获取 XML 数据【可修改问配置文件】
            string commandFilePath = ConfigurationManager.AppSettings["CommandFilePath"];
            string strNamespace = @"https:\\FellowshipOne\Framework\DBGroups";
            string dbXmlFile = DatabaseEnv == 2 ? "/Database_QA.xml" : "/Database.xml";
            FileStream fs = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + commandFilePath + dbXmlFile);
            XmlSerializer xmls = new XmlSerializer(typeof(DBGroupConfig), strNamespace);
            DBGroupConfig dbGroupConfig = xmls.Deserialize(fs) as DBGroupConfig;
            fs.Close();
            #endregion

            #region 2.Fill the Command Dictionary.
            //Fill the Command Dictionary.
            if (dbGroupConfig == null || dbGroupConfig.Databases == null)
            {
                throw new Exception(string.Format("FellowshipOne.Framework Exception: Load database config failed!"));
            }

            DataManager.DatabaseDictionary.Clear();
            foreach (var db in dbGroupConfig.Databases)
            {
                DataManager.DatabaseDictionary.Add(db.DataSourceID, db);
            }
            #endregion 2.Fill the Command Dictionary.
        }
        #endregion


        #region 操作方法
        /// <summary>
        /// 创建可用的Command对象
        /// </summary>
        /// <param name="commandName">需要获取的Command名称</param>
        /// <returns></returns>
        public CustomerCommand CreateCustomerCommand(string commandName)
        {
            /*
             * 1.获取 XML 数据
             * 2.获取对应的 Commmand 信息
             * 3.填充 Command 对象并返回数据
             */
            //#region 1.获取 XML 数据
            ////1.获取 XML 数据【可修改问配置文件】
            //string commandFilePath = ConfigurationManager.AppSettings["CommandFilePath"];
            //string strNamespace = @"https:\\FellowshipOne\Framework\DataOperators";

            //FileStream fs = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + commandFilePath);
            //XmlSerializer xmls = new XmlSerializer(typeof(DataOperatorsConfig), strNamespace);
            //DataOperatorsConfig DataOperators = xmls.Deserialize(fs) as DataOperatorsConfig;
            //fs.Close();
            //#endregion

            #region 2.获取对应的 Commmand 信息
            //2.获取对应的 Commmand 信息
            //DataCommandConfig commandConfig = DataOperators.DataCommands.Find(x => x.Name == commandName);
            if (!DataManager.CommandDictionary.ContainsKey(commandName))
            {
                throw new Exception(string.Format("未找到Name='{0}'的配置节点，请检查配置文件是否正确。", commandName));
            }

            DataCommandConfig commandConfig = DataManager.CommandDictionary[commandName];
            /*后续添加针对 commandConfig 对象的数据校验*/
            
            #endregion
            
            //3.填充 Command 对象
            CustomerCommand customerCmd = CreateCommand(commandConfig);
            return customerCmd;
        }
        #endregion 操作方法


        /// <summary>
        /// 创建命令对象
        /// </summary>
        /// <param name="commandConfig">命令对象配置文件</param>
        /// <returns>命令对象</returns>
        protected abstract CustomerCommand CreateCommand(DataCommandConfig commandConfig);

    }
}
