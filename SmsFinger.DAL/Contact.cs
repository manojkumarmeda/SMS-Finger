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
	/// Strongly-typed collection for the Contact class.
	/// </summary>
    [Serializable]
	public partial class ContactCollection : ActiveList<Contact, ContactCollection>
	{	   
		public ContactCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ContactCollection</returns>
		public ContactCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Contact o = this[i];
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
	/// This is an ActiveRecord class which wraps the contacts table.
	/// </summary>
	[Serializable]
	public partial class Contact : ActiveRecord<Contact>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Contact()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Contact(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Contact(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Contact(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("contacts", TableType.Table, DataService.GetInstance("SMSFingerProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"";
				//columns
				
				TableSchema.TableColumn colvarContactid = new TableSchema.TableColumn(schema);
				colvarContactid.ColumnName = "contactid";
				colvarContactid.DataType = DbType.Int32;
				colvarContactid.MaxLength = 0;
				colvarContactid.AutoIncrement = true;
				colvarContactid.IsNullable = false;
				colvarContactid.IsPrimaryKey = true;
				colvarContactid.IsForeignKey = false;
				colvarContactid.IsReadOnly = false;
				colvarContactid.DefaultSetting = @"";
				colvarContactid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContactid);
				
				TableSchema.TableColumn colvarContactname = new TableSchema.TableColumn(schema);
				colvarContactname.ColumnName = "contactname";
				colvarContactname.DataType = DbType.String;
				colvarContactname.MaxLength = 100;
				colvarContactname.AutoIncrement = false;
				colvarContactname.IsNullable = true;
				colvarContactname.IsPrimaryKey = false;
				colvarContactname.IsForeignKey = false;
				colvarContactname.IsReadOnly = false;
				colvarContactname.DefaultSetting = @"";
				colvarContactname.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContactname);
				
				TableSchema.TableColumn colvarMobileno = new TableSchema.TableColumn(schema);
				colvarMobileno.ColumnName = "mobileno";
				colvarMobileno.DataType = DbType.Binary;
				colvarMobileno.MaxLength = 15;
				colvarMobileno.AutoIncrement = false;
				colvarMobileno.IsNullable = true;
				colvarMobileno.IsPrimaryKey = false;
				colvarMobileno.IsForeignKey = false;
				colvarMobileno.IsReadOnly = false;
				colvarMobileno.DefaultSetting = @"";
				colvarMobileno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMobileno);
				
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
				
				TableSchema.TableColumn colvarGroupid = new TableSchema.TableColumn(schema);
				colvarGroupid.ColumnName = "groupid";
				colvarGroupid.DataType = DbType.Int32;
				colvarGroupid.MaxLength = 0;
				colvarGroupid.AutoIncrement = false;
				colvarGroupid.IsNullable = true;
				colvarGroupid.IsPrimaryKey = false;
				colvarGroupid.IsForeignKey = false;
				colvarGroupid.IsReadOnly = false;
				colvarGroupid.DefaultSetting = @"";
				colvarGroupid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGroupid);
				
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
				DataService.Providers["SMSFingerProvider"].AddSchema("contacts",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Contactid")]
		[Bindable(true)]
		public int Contactid 
		{
			get { return GetColumnValue<int>(Columns.Contactid); }
			set { SetColumnValue(Columns.Contactid, value); }
		}
		  
		[XmlAttribute("Contactname")]
		[Bindable(true)]
		public string Contactname 
		{
			get { return GetColumnValue<string>(Columns.Contactname); }
			set { SetColumnValue(Columns.Contactname, value); }
		}
		  
		[XmlAttribute("Mobileno")]
		[Bindable(true)]
		public byte[] Mobileno 
		{
			get { return GetColumnValue<byte[]>(Columns.Mobileno); }
			set { SetColumnValue(Columns.Mobileno, value); }
		}
		  
		[XmlAttribute("Acid")]
		[Bindable(true)]
		public int? Acid 
		{
			get { return GetColumnValue<int?>(Columns.Acid); }
			set { SetColumnValue(Columns.Acid, value); }
		}
		  
		[XmlAttribute("Groupid")]
		[Bindable(true)]
		public int? Groupid 
		{
			get { return GetColumnValue<int?>(Columns.Groupid); }
			set { SetColumnValue(Columns.Groupid, value); }
		}
		  
		[XmlAttribute("Datecreated")]
		[Bindable(true)]
		public DateTime? Datecreated 
		{
			get { return GetColumnValue<DateTime?>(Columns.Datecreated); }
			set { SetColumnValue(Columns.Datecreated, value); }
		}
		  
		[XmlAttribute("Usercreated")]
		[Bindable(true)]
		public int? Usercreated 
		{
			get { return GetColumnValue<int?>(Columns.Usercreated); }
			set { SetColumnValue(Columns.Usercreated, value); }
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
		public static void Insert(string varContactname,byte[] varMobileno,int? varAcid,int? varGroupid,DateTime? varDatecreated,int? varUsercreated,int? varStatus)
		{
			Contact item = new Contact();
			
			item.Contactname = varContactname;
			
			item.Mobileno = varMobileno;
			
			item.Acid = varAcid;
			
			item.Groupid = varGroupid;
			
			item.Datecreated = varDatecreated;
			
			item.Usercreated = varUsercreated;
			
			item.Status = varStatus;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varContactid,string varContactname,byte[] varMobileno,int? varAcid,int? varGroupid,DateTime? varDatecreated,int? varUsercreated,int? varStatus)
		{
			Contact item = new Contact();
			
				item.Contactid = varContactid;
			
				item.Contactname = varContactname;
			
				item.Mobileno = varMobileno;
			
				item.Acid = varAcid;
			
				item.Groupid = varGroupid;
			
				item.Datecreated = varDatecreated;
			
				item.Usercreated = varUsercreated;
			
				item.Status = varStatus;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ContactidColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ContactnameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn MobilenoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn AcidColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn GroupidColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DatecreatedColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn UsercreatedColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn StatusColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Contactid = @"contactid";
			 public static string Contactname = @"contactname";
			 public static string Mobileno = @"mobileno";
			 public static string Acid = @"acid";
			 public static string Groupid = @"groupid";
			 public static string Datecreated = @"datecreated";
			 public static string Usercreated = @"usercreated";
			 public static string Status = @"status";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
