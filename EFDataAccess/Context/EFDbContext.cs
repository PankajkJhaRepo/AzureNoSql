
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Emisoft.TeamsSR.WorkflowDAL.Interface;
using System.Configuration;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration;
using Entity;

namespace EFDataAccess
{
    /// <summary>
    /// Class WorkflowDbContext.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class EFDbContext : DbContext
    {
        /// <summary>
        /// Enum DataBaseType
        /// </summary>
        public enum DataBaseType { SQL, Oracle, Empty }

        /// <summary>
        /// Initializes static members of the <see cref="WorkflowDbContext"/> class.
        /// </summary>
        static EFDbContext()
        {
            Database.SetInitializer<EFDbContext>(null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowDbContext"/> class.
        /// </summary>
        public EFDbContext()
            : base(GetConnection(), true)
        {
            //Database.SetInitializer<WorkflowDbContext>(new CreateDatabaseIfNotExists<WorkflowDbContext>()); 
            //this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFDbContext, Configuration>());
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.</remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);
        }
        /// <summary>
        /// Assign Ancestors and descndants form menu table and make hierarchycal data 
        /// </summary>
        
        /// <summary>
        /// Gets or sets the type of the database.
        /// </summary>
        /// <value>The type of the database.</value>
        public static DataBaseType DbType
        {
            get
            {
                var connectionString = ConfigurationManager.ConnectionStrings[CurrentDatabase];
                if (connectionString == null)
                    return DataBaseType.Empty;
                return connectionString.ProviderName.Contains("SqlClient")
                        ? DataBaseType.SQL
                        : DataBaseType.Oracle;
            }
            set { }
        }

        /// <summary>
        /// The current database
        /// </summary>
        private static string _currentDatabase = "ApartmentDbContext";
        /// <summary>
        /// Gets or sets the current database.
        /// </summary>
        /// <value>The current database.</value>
        public static string CurrentDatabase
        {
            set { _currentDatabase = value; }
            get { return _currentDatabase; }
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns>DbConnection.</returns>
        public static DbConnection GetConnection()
        {
            DbConnection dbConnection = null;
            switch (DbType)
            {
                case DataBaseType.SQL:
                    dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CurrentDatabase].ConnectionString);
                    break;
            }
            return dbConnection;
        }


        public DbSet<Apartment> Apartments { get; set; }

        public DbSet<Address> Addresses { get; set; }
        


    }
    /// <summary>
    /// Class Configuration.
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigrationsConfiguration{Emisoft.TeamsSR.WorkflowDAL.Context.WorkflowDbContext}" />
    public class Configuration : DbMigrationsConfiguration<EFDbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowService"/> class.
        /// </summary>
        /// <param name="SchemaID">The schema identifier.</param>
        /// <param name="WorkflowExcutionType">Type of the workflow excution.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        protected override void Seed(EFDbContext context)
        {
 
            
        }
    }
}
