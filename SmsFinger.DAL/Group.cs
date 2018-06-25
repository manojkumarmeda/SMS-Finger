using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace SMSFinger.DAL
{
	/// <summary>
	/// Strongly-typed collection for the Group class.
	/// </summary>
    [Serializable]
	public partial class GroupCollection : ActiveList<Group, GroupCollection>
	{	   
		public GroupCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>GroupCollection</returns>
		public GroupCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Group o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the groups table.
	/// </summary>
	[Serializable]
	public partial class Group : ActiveRecord<Group>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Group()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Group(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Group(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Group(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("groups", TableType.Table, DataService.GetInstance("SMSFingerProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarUserid = new TableSchema.TableColumn(schema);
				colvarUserid.ColumnName = "userid";
				colvarUserid.DataType = DbType.Int32;
				colvarUserid.MaxLength = 0;
				colvarUserid.AutoIncrement = false;
				colvarUserid.IsNullable = true;
				colvarUserid.IsPrimaryKey = false;
				colvarUserid.IsForeignKey = false;
				colvarUserid.IsReadOnly = false;
				colvarUserid.DefaultSetting = @"";
				colvarUserid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserid);
				
				TableSchema.TableColumn colvarGroupname = new TableSchema.TableColumn(schema);
				colvarGroupname.ColumnName = "groupname";
				colvarGroupname.DataType = DbType.String;
				colvarGroupname.MaxLength = 100;
				colvarGroupname.AutoIncrement = false;
				colvarGroupname.IsNullable = true;
				colvarGroupname.IsPrimaryKey = false;
				colvarGroupname.IsForeignKey = false;
				colvarGroupname.IsReadOnly = false;
				colvarGroupname.DefaultSetting = @"";
				colvarGroupname.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGroupname);
				
				TableSchema.TableColumn colvarAcid = new TableSchema.TableColumn(schema);
				colvarAcid.ColumnName = "acid";
				colvarAcid.DataType = DbType.Int32;
				colvarAcid.MaxLength = 0;
				colvarAcid.AutoIncrement = false;
				colvarAcid.IsNullable = true;
				colvarAcid.IsPrimaryKey = false;
				colvarAcid.IsForeignKey = false;
				colvarAcid.IsReadOnly = false;
				colvarAcid.DefaultSetting = @"";
				colvarAcid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAcid);
				
				TableSchema.TableColumn colvarUsercreated = new TableSchema.TableColumn(schema);
				colvarUsercreated.ColumnName = "usercreated";
				colvarUsercreated.DataType = DbType.Int32;
				colvarUsercreated.MaxLength = 0;
				colvarUsercreated.AutoIncrement = false;
				colvarUsercreated.IsNullable = true;
				colvarUsercreated.IsPrimaryKey = false;
				colvarUsercreated.IsForeignKey = false;
				colvarUsercreated.IsReadOnly = false;
				colvarUsercreated.DefaultSetting = @"";
				colvarUsercreated.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsercreated);
				
				TableSchema.TableColumn colvarDatecreated = new TableSchema.TableColumn(schema);
				colvarDatecreated.ColumnName = "datecreated";
				colvarDatecreated.DataType = DbType.DateTime;
				colvarDatecreated.MaxLength = 0;
				colvarDatecreated.AutoIncrement = false;
				colvarDatecreated.IsNullable = true;
				colvarDatecreated.IsPrimaryKey = false;
				colvarDatecreated.IsForeignKey = false;
				colvarDatecreated.IsReadOnly = false;
				colvarDatecreated.DefaultSetting = @"";
				colvarDatecreated.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDatecreated);
				
				TableSchema.TableColumn colvarStatus = new TableSchema.TableColumn(schema);
				colvarStatus.ColumnName = "status";
				colvarStatus.DataType = DbType.Int32;
				colvarStatus.MaxLength = 0;
				colvarStatus.AutoIncrement = false;
				colvarStatus.IsNullable = true;
				colvarStatus.IsPrimaryKey = false;
				colvarStatus.IsForeignKey = false;
				colvarStatus.IsReadOnly = false;
				colvarStatus.DefaultSetting = @"";
				colvarStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStatus);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SMSFingerProvider"].AddSchema("groups",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("Userid")]
		[Bindable(true)]
		public int? Userid 
		{
			get { return GetColumnValue<int?>(Columns.Userid); }
			set { SetColumnValue(Columns.Userid, value); }
		}
		  
		[XmlAttribute("Groupname")]
		[Bindable(true)]
		public string Groupname 
		{
			get { return GetColumnValue<string>(Columns.Groupname); }
			set { SetColumnValue(Columns.Groupname, value); }
		}
		  
		[XmlAttribute("Acid")]
		[Bindable(true)]
		public int? Acid 
		{
			get { return GetColumnValue<int?>(Columns.Acid); }
			set { SetColumnValue(Columns.Acid, value); }
		}
		  
		[XmlAttribute("Usercreated")]
		[Bindable(true)]
		public int? Usercreated 
		{
			get { return GetColumnValue<int?>(Columns.Usercreated); }
			set { SetColumnValue(Columns.Usercreated, value); }
		}
		  
		[XmlAttribute("Datecreated")]
		[Bindable(true)]
		public DateTime? Datecreated 
		{
			get { return GetColumnValue<DateTime?>(Columns.Datecreated); }
			set { SetColumnValue(Columns.Datecreated, value); }
		}
		  
		[XmlAttribute("Status")]
		[Bindable(true)]
		public int? Status 
		{
			get { return GetColumnValue<int?>(Columns.Status); }
			set { SetColumnValue(Columns.Status, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varUserid,string varGroupname,int? varAcid,int? varUsercreated,DateTime? varDatecreated,int? varStatus)
		{
			Group item = new Group();
			
			item.Userid = varUserid;
			
			item.Groupname = varGroupname;
			
			item.Acid = varAcid;
			
			item.Usercreated = varUsercreated;
			
			item.Datecreated = varDatecreated;
			
			item.Status = varStatus;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int? varUserid,string varGroupname,int? varAcid,int? varUsercreated,DateTime? varDatecreated,int? varStatus)
		{
			Group item = new Group();
			
				item.Id = varId;
			
				item.Userid = varUserid;
			
				item.Groupname = varGroupname;
			
				item.Acid = varAcid;
			
				item.Usercreated = varUsercreated;
			
				item.Datecreated = varDatecreated;
			
				item.Status = varStatus;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn UseridColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn GroupnameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn AcidColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn UsercreatedColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DatecreatedColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn StatusColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Userid = @"userid";
			 public static string Groupname = @"groupname";
			 public static string Acid = @"acid";
			 public static string Usercreated = @"usercreated";
			 public static string Datecreated = @"datecreated";
			 public static string Status = @"status";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
