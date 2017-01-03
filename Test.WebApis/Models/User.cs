namespace Test.WebApis.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class User : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“User”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“Test.WebApis.Models.User”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“User”
        //连接字符串。
        public User()
            : base("name=User")
        {
            var userInfo = new UserInfo { Id = new Guid(), Gender = 0, IDCard = "3194181827", Name = "Tom", Phone = "13611112222" };
            Users.Add(userInfo);
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<UserInfo> Users { get; set; }
    }

    [Table("User")]
    public class UserInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IDCard { get; set; }
        public int Gender { get; set; }
        public string Phone { get; set; }
    }
    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}