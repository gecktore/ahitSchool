﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AhitSchool.components
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class uchebEntities : DbContext
    {
        public uchebEntities()
            : base("name=uchebEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<akademiki> akademiki { get; set; }
        public virtual DbSet<Animal_gareev> Animal_gareev { get; set; }
        public virtual DbSet<Control_gareev> Control_gareev { get; set; }
        public virtual DbSet<Countries_gareev> Countries_gareev { get; set; }
        public virtual DbSet<country> country { get; set; }
        public virtual DbSet<Flowers_gareev> Flowers_gareev { get; set; }
        public virtual DbSet<learner> learner { get; set; }
        public virtual DbSet<spec> spec { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Licei> Licei { get; set; }
        public virtual DbSet<Discipline> Discipline { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Specialty> Specialty { get; set; }
        public virtual DbSet<Lecturer> Lecturer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
    
        [DbFunction("uchebEntities", "func_10")]
        public virtual IQueryable<func_10_Result> func_10()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<func_10_Result>("[uchebEntities].[func_10]()");
        }
    
        [DbFunction("uchebEntities", "func_8")]
        public virtual IQueryable<func_8_Result> func_8(Nullable<int> n)
        {
            var nParameter = n.HasValue ?
                new ObjectParameter("n", n) :
                new ObjectParameter("n", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<func_8_Result>("[uchebEntities].[func_8](@n)", nParameter);
        }
    
        [DbFunction("uchebEntities", "func_9")]
        public virtual IQueryable<func_9_Result> func_9(Nullable<double> a, Nullable<double> b)
        {
            var aParameter = a.HasValue ?
                new ObjectParameter("a", a) :
                new ObjectParameter("a", typeof(double));
    
            var bParameter = b.HasValue ?
                new ObjectParameter("b", b) :
                new ObjectParameter("b", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<func_9_Result>("[uchebEntities].[func_9](@a, @b)", aParameter, bParameter);
        }
    
        public virtual int SelectColumnsFromTable(string columns, string tableName)
        {
            var columnsParameter = columns != null ?
                new ObjectParameter("columns", columns) :
                new ObjectParameter("columns", typeof(string));
    
            var tableNameParameter = tableName != null ?
                new ObjectParameter("tableName", tableName) :
                new ObjectParameter("tableName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SelectColumnsFromTable", columnsParameter, tableNameParameter);
        }
    
        public virtual int SelectProcedur(string columns, string tableName, string checkColumn, string comparisonOperator, Nullable<int> comparisonValue)
        {
            var columnsParameter = columns != null ?
                new ObjectParameter("Columns", columns) :
                new ObjectParameter("Columns", typeof(string));
    
            var tableNameParameter = tableName != null ?
                new ObjectParameter("TableName", tableName) :
                new ObjectParameter("TableName", typeof(string));
    
            var checkColumnParameter = checkColumn != null ?
                new ObjectParameter("CheckColumn", checkColumn) :
                new ObjectParameter("CheckColumn", typeof(string));
    
            var comparisonOperatorParameter = comparisonOperator != null ?
                new ObjectParameter("ComparisonOperator", comparisonOperator) :
                new ObjectParameter("ComparisonOperator", typeof(string));
    
            var comparisonValueParameter = comparisonValue.HasValue ?
                new ObjectParameter("ComparisonValue", comparisonValue) :
                new ObjectParameter("ComparisonValue", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SelectProcedur", columnsParameter, tableNameParameter, checkColumnParameter, comparisonOperatorParameter, comparisonValueParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
