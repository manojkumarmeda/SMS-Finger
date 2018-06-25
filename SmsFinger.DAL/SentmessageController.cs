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
    /// Controller class for sentmessages
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SentmessageController
    {
        // Preload our schema..
        Sentmessage thisSchemaLoad = new Sentmessage();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public SentmessageCollection FetchAll()
        {
            SentmessageCollection coll = new SentmessageCollection();
            Query qry = new Query(Sentmessage.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SentmessageCollection FetchByID(object Msgid)
        {
            SentmessageCollection coll = new SentmessageCollection().Where("msgid", Msgid).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SentmessageCollection FetchByQuery(Query qry)
        {
            SentmessageCollection coll = new SentmessageCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Msgid)
        {
            return (Sentmessage.Delete(Msgid) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Msgid)
        {
            return (Sentmessage.Destroy(Msgid) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Mobileno,string Messagebody,int? Msgtype,DateTime? Datecreated,int? Usercreated,int? Acid,string Msgstatus)
	    {
		    Sentmessage item = new Sentmessage();
		    
            item.Mobileno = Mobileno;
            
            item.Messagebody = Messagebody;
            
            item.Msgtype = Msgtype;
            
            item.Datecreated = Datecreated;
            
            item.Usercreated = Usercreated;
            
            item.Acid = Acid;
            
            item.Msgstatus = Msgstatus;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Msgid,string Mobileno,string Messagebody,int? Msgtype,DateTime? Datecreated,int? Usercreated,int? Acid,string Msgstatus)
	    {
		    Sentmessage item = new Sentmessage();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Msgid = Msgid;
				
			item.Mobileno = Mobileno;
				
			item.Messagebody = Messagebody;
				
			item.Msgtype = Msgtype;
				
			item.Datecreated = Datecreated;
				
			item.Usercreated = Usercreated;
				
			item.Acid = Acid;
				
			item.Msgstatus = Msgstatus;
				
	        item.Save(UserName);
	    }
    }
}
