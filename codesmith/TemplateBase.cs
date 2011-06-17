using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Windows.Forms.Design;
using CodeSmith.CustomProperties;
using CodeSmith.Engine;
using SchemaExplorer;

namespace CodeSmith.Csla
{
    public class TemplateBase : CodeSmith.Engine.CodeTemplate 
    {
        [Category("1. General"),
		    Optional]
        public string CustomerName { get; set;}
		           
        [Category("1. General")]
        public string ProjectName { get; set;}
		           
        [Browsable(false)]
        public string NamespaceName 
        {
            get
            {
                if (string.IsNullOrEmpty(this.CustomerName))
                {
                    return this.ProjectName;
                }
                
                return string.Format("{0}.{1}", this.CustomerName, this.ProjectName);
            }
        }

        private TableSchema _sourceTable = null;
        [Category("3. Data")]
        public TableSchema SourceTable
        {
            get 
            { 
                return _sourceTable; 
            }
            set 
            { 
                if (_sourceTable != value)
                {
                    _sourceTable = value;
                    this.OnSourceTableChanged();
                }
            }
        }
		           
        [Category("2. Class")]
        public string ClassName { get; set;}
		           
        [Category("2. Class")]
        public string ClassPluralName { get; set;}
     
        [Optional]
		[DefaultValue("{0}")]
        [Category("2. Class")]
        public string ToStringFormat { get; set;}

        [Optional]
        [Category("2. Class")]
        public StringCollection ToStringFormatMembers {get; set;}
      
        private void OnSourceTableChanged()
        {
            this.CustomerName = "";
            this.ProjectName = "Epiworx";
            
            if (this.SourceTable != null)
            {

                this.ClassName = this.SourceTable.Name;
                this.ClassPluralName = StringUtil.ToPlural(this.ClassName);
            }
        }
		
		public string ToCriteriaDataType(ColumnSchema column)
		{
			return this.ToCriteriaDataType(column, false);
		}
		
		public string ToCriteriaDataType(ColumnSchema column, bool nullable)
		{
			var result = string.Empty;
			
			switch (column.DataType)
			{
				case DbType.Guid: 
					if (nullable)
						result = "Guid?";
					else
						result = "Guid";
					break;
				case DbType.AnsiString: 
				case DbType.AnsiStringFixedLength: 
				case DbType.String: 
				case DbType.StringFixedLength: 
					result = "string";
					break;
				case DbType.Boolean: 
					if (nullable)
						result = "bool?";
					else
						result = "bool";
					break;
				case DbType.Date:
				case DbType.DateTime:
					result = "DateRangeCriteria";
					break;
				case DbType.Currency: 
				case DbType.Decimal: 
				case DbType.Double: 
					if (nullable)
						result = "decimal?";
					else
						result = "decimal";
					break;
				case DbType.Int16: 
				case DbType.Int32: 
				case DbType.Int64: 
				case DbType.Single: 
					if (nullable)
						result = "int?";
					else
						result = "int";
					break;
				default: 
					result = "string";
					break;
			}
	
			return result;
		}
		
		public string ToDataType(ColumnSchema column)
		{
			return this.ToDataType(column, false);
		}
		
		public string ToDataType(ColumnSchema column, bool nullable)
		{
			var result = string.Empty;
			
			switch (column.DataType)
			{
				case DbType.Guid: 
					if (nullable)
						result = "Guid?";
					else
						result = "Guid";
					break;
				case DbType.AnsiString: 
				case DbType.AnsiStringFixedLength: 
				case DbType.String: 
				case DbType.StringFixedLength: 
					result = "string";
					break;
				case DbType.Boolean: 
					if (nullable)
						result = "bool?";
					else
						result = "bool";
					break;
				case DbType.Date:
				case DbType.DateTime:
					if (nullable)
						result = "DateTime?";
					else
						result = "DateTime";
					break;
				case DbType.Currency: 
				case DbType.Decimal: 
				case DbType.Double: 
					if (nullable)
						result = "decimal?";
					else
						result = "decimal";
					break;
				case DbType.Int16: 
				case DbType.Int32: 
				case DbType.Int64: 
				case DbType.Single: 
					if (nullable)
						result = "int?";
					else
						result = "int";
					break;
				default: 
					result = "string";
					break;
			}
	
			return result;
		}
			
		public string ToDefaultValue(ColumnSchema column)
		{
			var result = string.Empty;
			
			switch (column.DataType)
			{
				case DbType.Guid: 
					result = Guid.Empty.ToString();
					break;
				case DbType.AnsiString: 
				case DbType.AnsiStringFixedLength: 
				case DbType.String: 
				case DbType.StringFixedLength: 
					result = "string.Empty";
					break;
				case DbType.Boolean: 
					result = "false";
					break;
				case DbType.Date:
				case DbType.DateTime:
                    result = "DateTime.MaxValue";
					break;
				case DbType.Currency: 
				case DbType.Decimal: 
				case DbType.Double:
                    result = "0";
					break;
				case DbType.Int16: 
				case DbType.Int32: 
				case DbType.Int64: 
				case DbType.Single: 
                    result = "0";
					break;
				default: 
					result = "string.Empty";
					break;
			}
	
			return result;
		}
	
		public bool HasColumn(string columnName)
		{
            return this.SourceTable.Columns.Any(row => row.Name == columnName);
		}
			
		public bool IsColumnFormatStringMember(ColumnSchema column)
		{
            if (this.ToStringFormatMembers == null)
            {
                return false;
            }
            
            return this.ToStringFormatMembers.Contains(column.Name);
		}
			
		public bool IsLastColumnFormatStringMember(ColumnSchema column)
		{
            if (this.ToStringFormatMembers == null)
            {
                return false;
            }
            
            return this.ToStringFormatMembers.ToArray().Last() == column.Name;
		}
        
        public bool IsNotLastColumnFormatStringMember(ColumnSchema column)
        {
            return !this.IsLastColumnFormatStringMember(column);
        }

		public bool IsColumn(ColumnSchema column, params string[] columnName)
		{
            return columnName.Contains(column.Name);
		}
		
		public bool IsNotColumn(ColumnSchema column, params string[] columnName)
		{
            return !columnName.Contains(column.Name);
		}
		
		public bool IsFirstColumn(ColumnSchema column)
		{
            return this.SourceTable.Columns.First().Name == column.Name;
		}
        
        public bool IsNotFirstColumn(ColumnSchema column)
        {
            return !this.IsFirstColumn(column);
        }
		
		public bool IsLastColumn(ColumnSchema column)
		{
            return this.SourceTable.Columns.Last().Name == column.Name;
		}
        
        public bool IsNotLastColumn(ColumnSchema column)
        {
            return !this.IsLastColumn(column);
        }
	}
}