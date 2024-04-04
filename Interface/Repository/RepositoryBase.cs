using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure.Repository;
using Infrastructure.Entity;

using System.Globalization;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Interface.Data;

namespace Interface.Repository
{
    public class RepositoryBase<T, t> : IRepositoryBase<T, t> where T : EntityBase<t>
    {
        //private ProjectDBContext _context;
        private newAddedDBContext _context;
        // private DbSet<T> entities;
        string errorMessage = string.Empty;
        //public RepositoryBase(ProjectDBContext context)
        public RepositoryBase(newAddedDBContext context)
        {
            this._context = context;
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return _context.Set<T>().AsNoTracking();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IQueryable<T> GetAllAsync()
        {
            try
            {
                return _context.Set<T>().AsNoTracking();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public  IQueryable<T> GetAllQueryable()
        {
            try
            {
                return  _context.Set<T>().AsNoTracking();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<T> SqlQuery(string query)
        {
            try
            {
                FormattableString f = $"{query}";
                return _context.Set<T>().FromSql(f).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<T> FromSql(FormattableString query)
        {
            try
            {
                return _context.Set<T>().FromSql(query).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    return false;
                    throw new ArgumentNullException("entity");
                }
                //  var fullName = HttpContext.Current.Request.RequestContext.HttpContext.User.FullName();
                entity.modifiedInfo = DateTime.Now/*.SystemTime()*/.ToString("yyyy/MM/dd hh:mm:ss:tt");
                //  entity.modifiedInfo += (HttpContext.Current.Request.RequestContext.HttpContext.User.IsInRole("Administrator")) ? "" : " By :" + fullName;
                _context.Set<T>().Add(entity);
                var Result = this._context.SaveChanges();
                //try // Last Activity
                //{
                //    var json = new[]
                //       {
                //        new {
                //                TableID =  entity.ID,
                //                TableName = entity.GetType().Name.Remove(entity.GetType().Name.IndexOf("Ent")),

                //                FullName = fullName,
                //                UserID = HttpContext.Current.Request.RequestContext.HttpContext.User.UserID(),
                //                Type = "Add",
                //                DateTime = DateTime.Now.SystemTime().ToString("yyyy/MM/dd hh:mm:tt"),
                //        },};

                //    var lastActivity = new LastActivityEnt();
                //    lastActivity.modifiedInfo = JsonConvert.SerializeObject(json);

                //    this._context.LastActivities.Add(lastActivity);
                //    this._context.SaveChanges();

                //}
                //catch (Exception ex) { }
                return Convert.ToBoolean(Result);
            }
            catch (Exception dbEx)
            {

                throw new Exception(errorMessage, dbEx);
            }
        }
        public async Task<bool> InsertAsync(T entity)
        {
            try
            {
                if (entity == null)
                {

                    return false;
                    throw new ArgumentNullException("entity");
                }
                //var fullName = HttpContext.Current.Request.RequestContext.HttpContext.User.FullName();
                entity.modifiedInfo = DateTime.Now/*.SystemTime()*/.ToString("yyyy/MM/dd hh:mm:ss:tt");
                // entity.modifiedInfo += (HttpContext.Current.Request.RequestContext.HttpContext.User.IsInRole("Administrator")) ? "" : " By :" + fullName;
                _context.Set<T>().Add(entity);
                var Result = await this._context.SaveChangesAsync();
                //try // Last Activity
                //{
                //    var json = new[]
                //       {
                //        new {
                //                TableID =  entity.ID,
                //                TableName = entity.GetType().Name.Remove(entity.GetType().Name.IndexOf("Ent")),

                //                FullName = fullName,
                //                UserID = HttpContext.Current.Request.RequestContext.HttpContext.User.UserID(),
                //                Type = "Add",
                //                DateTime = DateTime.Now.SystemTime().ToString("yyyy/MM/dd hh:mm:tt"),
                //        },};

                //    var lastActivity = new LastActivityEnt();
                //    lastActivity.modifiedInfo = JsonConvert.SerializeObject(json);

                //    this._context.LastActivities.Add(lastActivity);
                // await   this._context.SaveChangesAsync();

                //}
                //catch (Exception ex) { }


                return Convert.ToBoolean(Result);
            }
            catch (Exception dbEx)
            {

                throw new Exception(errorMessage, dbEx);
            }
        }

        public async Task<bool> Insert2Async(T entity)
        {
            try
            {
                if (entity == null)
                {

                    return false;
                    throw new ArgumentNullException("entity");
                }
                //var fullName = HttpContext.Current.Request.RequestContext.HttpContext.User.FullName();
                entity.modifiedInfo = DateTime.Now/*.SystemTime()*/.ToString("yyyy/MM/dd hh:mm:ss:tt");
                // entity.modifiedInfo += (HttpContext.Current.Request.RequestContext.HttpContext.User.IsInRole("Administrator")) ? "" : " By :" + fullName;
                _context.Set<T>().Add(entity);
                var Result = await this._context.SaveChangesAsync();
                //try // Last Activity
                //{
                //    var json = new[]
                //       {
                //        new {
                //                TableID =  entity.ID,
                //                TableName = entity.GetType().Name.Remove(entity.GetType().Name.IndexOf("Ent")),

                //                FullName = fullName,
                //                UserID = HttpContext.Current.Request.RequestContext.HttpContext.User.UserID(),
                //                Type = "Add",
                //                DateTime = DateTime.Now.SystemTime().ToString("yyyy/MM/dd hh:mm:tt"),
                //        },};

                //    var lastActivity = new LastActivityEnt();
                //    lastActivity.modifiedInfo = JsonConvert.SerializeObject(json);

                //    this._context.LastActivities.Add(lastActivity);
                // await   this._context.SaveChangesAsync();

                //}
                //catch (Exception ex) { }


                return Convert.ToBoolean(Result);
            }
            catch (Exception dbEx)
            {

                throw new Exception(errorMessage, dbEx);
            }
        }
        public bool Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    return false;
                    throw new ArgumentNullException("entity");
                }
               var NeWmodifiedInfo = DateTime.Now/*.SystemTime()*/.ToString("yyyy/MM/dd hh:mm:ss:tt");

                if (NeWmodifiedInfo == entity.modifiedInfo)
                    entity.modifiedInfo += "-";
                else
                    entity.modifiedInfo = NeWmodifiedInfo;
                // var fullName = HttpContext.Current.Request.RequestContext.HttpContext.User.FullName();
                // entity.modifiedInfo += (HttpContext.Current.Request.RequestContext.HttpContext.User.IsInRole("Administrator")) ? "" : " By :" + fullName;

                    //T existing = _context.Set<T>().Find(entity.ID);
                    //if (existing == null)
                    //    return false;
                    //   _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.Set<T>().Update(entity);
                var Result = this._context.SaveChanges();
                //try // Last Activity
                //{
                //    var json = new[]
                //       {
                //        new {
                //                TableID =  entity.ID,
                //                TableName = entity.GetType().Name.Remove(entity.GetType().Name.IndexOf("Ent")),

                //                FullName = fullName,
                //                UserID = HttpContext.Current.Request.RequestContext.HttpContext.User.UserID(),
                //                Type = "Edit",
                //                DateTime = DateTime.Now.SystemTime().ToString("yyyy/MM/dd hh:mm:tt"),
                //        },};
                //    var lastActivity = new LastActivityEnt();
                //    lastActivity.modifiedInfo = JsonConvert.SerializeObject(json);

                //    this._context.LastActivities.Add(lastActivity);
                //    this._context.SaveChanges();

                //}
                //catch (Exception ex) { }
                // _context.Entry(entity).State = EntityState.Modified;
                return Convert.ToBoolean(Result);


            }
            catch (Exception dbEx)
            {

                throw new Exception(errorMessage, dbEx);
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                if (entity == null)
                {
                    return false;
                    throw new ArgumentNullException("entity");
                }
                var NeWmodifiedInfo = DateTime.Now/*.SystemTime()*/.ToString("yyyy/MM/dd hh:mm:ss:tt");

                if (NeWmodifiedInfo == entity.modifiedInfo)
                    entity.modifiedInfo += "-";
                else
                    entity.modifiedInfo = NeWmodifiedInfo;
                // var fullName = HttpContext.Current.Request.RequestContext.HttpContext.User.FullName();
                // entity.modifiedInfo += (HttpContext.Current.Request.RequestContext.HttpContext.User.IsInRole("Administrator")) ? "" : " By :" + fullName;

                //T existing = _context.Set<T>().Find(entity.ID);
                //if (existing == null)
                //    return false;


                // _context.Entry(existing).CurrentValues.SetValues(entity);
                // _context.Update(entity);
                _context.Set<T>().Update(entity);
                var Result = await this._context.SaveChangesAsync();
                //try // Last Activity
                //{
                //    var json = new[]
                //       {
                //        new {
                //                TableID =  entity.ID,
                //                TableName = entity.GetType().Name.Remove(entity.GetType().Name.IndexOf("Ent")),

                //                FullName = fullName,
                //                UserID = HttpContext.Current.Request.RequestContext.HttpContext.User.UserID(),
                //                Type = "Edit",
                //                DateTime = DateTime.Now.SystemTime().ToString("yyyy/MM/dd hh:mm:tt"),
                //        },};
                //    var lastActivity = new LastActivityEnt();
                //    lastActivity.modifiedInfo = JsonConvert.SerializeObject(json);

                //    this._context.LastActivities.Add(lastActivity);
                //   await this._context.SaveChangesAsync();

                //}
                //catch (Exception ex) { }
                // _context.Entry(entity).State = EntityState.Modified;
                return Convert.ToBoolean(Result);


            }
            catch (Exception dbEx)
            {

                throw new Exception(errorMessage, dbEx);
            }
        }
        public async Task<bool> Update2Async(T entity)
        {
            try
            {
                if (entity == null)
                {
                    return false;
                    throw new ArgumentNullException("entity");
                }
                var NeWmodifiedInfo = DateTime.Now/*.SystemTime()*/.ToString("yyyy/MM/dd hh:mm:ss:tt");

                if (NeWmodifiedInfo == entity.modifiedInfo)
                    entity.modifiedInfo += "-";
                else
                    entity.modifiedInfo = NeWmodifiedInfo;
                // var fullName = HttpContext.Current.Request.RequestContext.HttpContext.User.FullName();
                // entity.modifiedInfo += (HttpContext.Current.Request.RequestContext.HttpContext.User.IsInRole("Administrator")) ? "" : " By :" + fullName;

                //T existing = _context.Set<T>().Find(entity.ID);
                //if (existing == null)
                //    return false;


                // _context.Entry(existing).CurrentValues.SetValues(entity);
                // _context.Update(entity);
                _context.Set<T>().Update(entity);
                var Result = await this._context.SaveChangesAsync();
                //try // Last Activity
                //{
                //    var json = new[]
                //       {
                //        new {
                //                TableID =  entity.ID,
                //                TableName = entity.GetType().Name.Remove(entity.GetType().Name.IndexOf("Ent")),

                //                FullName = fullName,
                //                UserID = HttpContext.Current.Request.RequestContext.HttpContext.User.UserID(),
                //                Type = "Edit",
                //                DateTime = DateTime.Now.SystemTime().ToString("yyyy/MM/dd hh:mm:tt"),
                //        },};
                //    var lastActivity = new LastActivityEnt();
                //    lastActivity.modifiedInfo = JsonConvert.SerializeObject(json);

                //    this._context.LastActivities.Add(lastActivity);
                //   await this._context.SaveChangesAsync();

                //}
                //catch (Exception ex) { }
                // _context.Entry(entity).State = EntityState.Modified;
                return Convert.ToBoolean(Result);


            }
            catch (Exception dbEx)
            {

                throw new Exception(errorMessage, dbEx);
            }
        }

        public bool Insert2(T entity)
        {
            try
            {
                if (entity == null)
                {
                    return false;
                    throw new ArgumentNullException("entity");
                }
                _context.Set<T>().Add(entity);
                return Convert.ToBoolean(this._context.SaveChanges());

            }
            catch (Exception dbEx)
            {

                throw new Exception(errorMessage, dbEx);
            }
        }

        public bool Update2(T entity)
        {
            try
            {
                if (entity == null)
                {
                    return false;
                    throw new ArgumentNullException("entity");
                }

                T existing = _context.Set<T>().Find(entity.ID);

                if (existing == null)
                    return false;
                // _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.Set<T>().Update(entity);
                // _context.Entry(entity).State = EntityState.Modified;
                return Convert.ToBoolean(this._context.SaveChanges());


            }
            catch (Exception dbEx)
            {

                throw new Exception(errorMessage, dbEx);
            }
        }


        public bool Delete(t id)
        {
            try
            {
                if (id == null)
                {
                    return false;
                    throw new ArgumentNullException("entity");
                }
                var entity = _context.Set<T>().Find(id);
                _context.Set<T>().Remove(entity);
                var Result = this._context.SaveChanges();
                // try // Last Activity
                // {
                //     var fullName = HttpContext.Current.Request.RequestContext.HttpContext.User.FullName();
                //     var json = new[]
                //        {
                //         new {
                //                 TableID =  entity.ID,
                //                 TableName = entity.GetType().Name.Remove(entity.GetType().Name.IndexOf("Ent")),

                //                 FullName = fullName,
                //                 UserID = HttpContext.Current.Request.RequestContext.HttpContext.User.UserID(),
                //                 Type = "Delete",
                //                 DateTime = DateTime.Now.SystemTime().ToString("yyyy/MM/dd hh:mm:tt"),
                //         },};
                //     var lastActivity = new LastActivityEnt();
                //     lastActivity.modifiedInfo = JsonConvert.SerializeObject(json);

                //     this._context.LastActivities.Add(lastActivity);
                //this._context.SaveChanges();
                // }
                // catch (Exception ex) { }
                return Convert.ToBoolean(Result);
            }
            catch (Exception dbEx)
            {


                throw new Exception(errorMessage, dbEx);
            }
        }
        public async Task<bool> DeleteAsync(t id)
        {
            try
            {
                if (id == null)
                {
                    return false;
                    throw new ArgumentNullException("entity");
                }
                var entity = _context.Set<T>().Find(id);
                _context.Set<T>().Remove(entity);
                var Result = await this._context.SaveChangesAsync();
                //try // Last Activity
                //{
                //    var fullName = HttpContext.Current.Request.RequestContext.HttpContext.User.FullName();
                //    var json = new[]
                //       {
                //        new {
                //                TableID =  entity.ID,
                //                TableName = entity.GetType().Name.Remove(entity.GetType().Name.IndexOf("Ent")),

                //                FullName = fullName,
                //                UserID = HttpContext.Current.Request.RequestContext.HttpContext.User.UserID(),
                //                Type = "Delete",
                //                DateTime = DateTime.Now.SystemTime().ToString("yyyy/MM/dd hh:mm:tt"),
                //        },};
                //    var lastActivity = new LastActivityEnt();
                //    lastActivity.modifiedInfo = JsonConvert.SerializeObject(json);

                //    this._context.LastActivities.Add(lastActivity);
                //await    this._context.SaveChangesAsync();
                //}
                //catch (Exception ex) { }
                return Convert.ToBoolean(Result);
            }
            catch (Exception dbEx)
            {


                throw new Exception(errorMessage, dbEx);
            }
        }

        public bool Delete2(t id)
        {
            try
            {
                if (id == null)
                {
                    return false;
                    throw new ArgumentNullException("entity");
                }
                var entity = _context.Set<T>().Find(id);
                _context.Set<T>().Remove(entity);
                var Result = this._context.SaveChanges();

                return Convert.ToBoolean(Result);
            }
            catch (Exception dbEx)
            {


                throw new Exception(errorMessage, dbEx);
            }
        }


        public virtual IQueryable<T> Table
        {
            get
            {
                return _context.Set<T>();
            }
        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._context != null)
                {
                    this._context.Dispose();
                    // this._context = null;
                }
            }
        }
        //این متد برای تخریب کردن کلاس استفاده میشود و کلاس را آزاد میکند
        ~RepositoryBase()
        {
            Dispose(false);
        }
    }
}