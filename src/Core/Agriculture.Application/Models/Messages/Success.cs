using System;
using System.Collections.Generic;
using System.Text;

namespace Agriculture.Application.Models.Messages
{
    public static class Success<TEntity> where TEntity : class
    {
        public static string Retrieved = $"{typeof(TEntity).Name} retrived successfully.";

        public static string Created = $"{typeof(TEntity).Name} created successfully.";
        public static string Updated = $"{typeof(TEntity).Name} updated successfully.";

        public static string Deleted = $"{typeof(TEntity).Name} deleted successfully.";
        public static string Restored = $"{typeof(TEntity).Name} restored successfully.";

        public static string Uploaded = $"{typeof(TEntity).Name} uploaded successfully.";
        public static string Added = $"{typeof(TEntity).Name} added successfully.";
    }
}
