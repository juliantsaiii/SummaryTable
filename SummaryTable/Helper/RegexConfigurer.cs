using SummaryTable.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryTable.Helper
{
    public class RegexConfigurer
    {


        /// <summary>
        /// 获取自定义抓取规则的节点对象信息
        /// </summary>
        /// <param name="key">配置节点key值</param>
        /// <returns>包含对应节点信息的实体类对象</returns>
        public RegexRule GetRegexRule(string key)
        {
            RegexRule regexRule = new RegexRule();
            return regexRule;
        }



        /// <summary>
        /// 新增或更新
        /// </summary>
        /// <param name="regexRule"></param>
        /// <returns></returns>
        public string SetRegexRule(RegexRule regexRule)
        {

            return "";
        }


        public void testit()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var mySection = config.GetSection("mySection");
            //foreach (MySection.MyKeyValueSetting add in mySection.KeyValues)
            //{
            //    Console.WriteLine(string.Format("{0}-{1}", add.Key, add.Value));
            //}
        }
    }











    /// <summary>
    /// 自定义节点配置类
    /// </summary>
    public class MySection : ConfigurationSection    // 所有配置节点都要选择这个基类
    {
        private static ConfigurationProperty s_property = new ConfigurationProperty(string.Empty, typeof(MyKeyValueCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public MyKeyValueCollection KeyValues
        {
            get
            {
                return (MyKeyValueCollection)base[s_property];
            }
        }
        [ConfigurationCollection(typeof(MyKeyValueSetting))]
        public class MyKeyValueCollection : ConfigurationElementCollection        // 自定义一个集合
        {
            // 基本上，所有的方法都只要简单地调用基类的实现就可以了。
            public MyKeyValueCollection()
                : base(StringComparer.OrdinalIgnoreCase)    // 忽略大小写
            {

            }

            // 其实关键就是这个索引器。但它也是调用基类的实现，只是做下类型转就行了。
            new public MyKeyValueSetting this[string name]
            {
                get { return (MyKeyValueSetting)base.BaseGet(name); }
                set { base[name] = value; }
            }

            // 下面二个方法中抽象类中必须要实现的。
            protected override ConfigurationElement CreateNewElement()
            {
                return new MyKeyValueSetting();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((MyKeyValueSetting)element).Key;
            }

            // 说明：如果不需要在代码中修改集合，可以不实现Add, Clear, Remove
            public void Add(MyKeyValueSetting setting)
            {
                this.BaseAdd(setting);
            }

            public void Clear()
            {
                base.BaseClear();
            }

            public void Remove(string name)
            {
                base.BaseRemove(name);
            }
        }
        public class MyKeyValueSetting : ConfigurationElement    // 集合中的每个元素
        {

            [ConfigurationProperty("key", IsRequired = true)]
            public string Key
            {
                get { return this["key"].ToString(); }
                set { this["key"] = value; }
            }

            [ConfigurationProperty("value", IsRequired = true)]
            public string Value
            {
                get { return this["value"].ToString(); }
                set { this["value"] = value; }
            }
        }

    }
}
