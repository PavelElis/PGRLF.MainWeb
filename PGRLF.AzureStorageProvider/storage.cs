using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using PGRLF.AzureStorageProvider.TableEntities;

namespace PGRLF.AzureStorageProvider
{
    public class Storage
    {
        private readonly CloudStorageAccount _storageAccount;
        private readonly CloudTableClient _tableClient;

        public Storage()
            : this(
                ConfigurationManager.ConnectionStrings[
                    "PGRLF.AzureStorageProvider.Properties.Settings.m000PGRLFStorageAccountConnectionString"]
                    .ConnectionString)
        {
        }

        public Storage(string connectionString)
        {
            _storageAccount = CloudStorageAccount.Parse(connectionString);
            _tableClient = _storageAccount.CreateCloudTableClient();

            CloudTable adminTable = _tableClient.GetTableReference("admin");
            adminTable.CreateIfNotExists();
            var adminQuery = new TableQuery<Admin>();
            var items = adminTable.ExecuteQuery(adminQuery);
            if (!items.Any())
            {
                var defaultAdmin = new Admin
                {
                    UserName = "admin",
                    Password = "Heslo123",
                    PartitionKey = "partition",
                    RowKey = Guid.NewGuid().ToString()
                };
                adminTable.Execute(TableOperation.Insert(defaultAdmin));
            }
            var formTable = _tableClient.GetTableReference("form");
            formTable.CreateIfNotExists();
        }

        #region security

        public string AdminUser
        {
            get
            {
                var adminTable = _tableClient.GetTableReference("admin");
                var adminQuery = new TableQuery<Admin>();
                var items = adminTable.ExecuteQuery(adminQuery);
                return items.First().UserName;
            }
        }

        public string AdminPassword
        {
            get
            {
                var adminTable = _tableClient.GetTableReference("admin");
                var adminQuery = new TableQuery<Admin>();
                var items = adminTable.ExecuteQuery(adminQuery);
                return items.First().Password;
            }
            set
            {
                var adminTable = _tableClient.GetTableReference("admin");
                var adminQuery = new TableQuery<Admin>();
                var item = adminTable.ExecuteQuery(adminQuery).First();
                item.Password = value;
                adminTable.Execute(TableOperation.Replace(item));
            }
        }

        #endregion

        #region Forms

        public List<Form> GetAllForms()
        {
            var formTable = _tableClient.GetTableReference("form");
            var formQuery = new TableQuery<Form>();
            var items = formTable.ExecuteQuery(formQuery);
            return items.ToList();
        }

        public void InsertOrUpdateForm(Form form)
        {
            form.PartitionKey = "forms";
            if (form.Id == Guid.Empty)
            {
                form.Id = Guid.NewGuid();
            }
            form.RowKey = form.Id.ToString();
            //form.RowKey = form.TechName;
            var formTable = _tableClient.GetTableReference("form");
            formTable.Execute(TableOperation.InsertOrReplace(form));
        }

        public Form GetForm(Guid formId)
        {
            var formTable = _tableClient.GetTableReference("form");

            var item = formTable.Execute(TableOperation.Retrieve<Form>("forms", formId.ToString())).Result as Form;
            return item;
        }

        public Form GetForm(string formTechName)
        {
            CloudTable table = _tableClient.GetTableReference("form");
            TableQuery<Form> query = new TableQuery<Form>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "forms"));
            Form form = null;
            foreach (Form entity in table.ExecuteQuery(query))
            {
                if (entity.TechName.Equals(formTechName))
                {
                    form = entity;
                }
            }
            return form;
        }

        public void DeleteForm(Guid formId)
        {
            var formTable = _tableClient.GetTableReference("form");

            var item = formTable.Execute(TableOperation.Retrieve<Form>("forms", formId.ToString())).Result as Form;
            formTable.Execute(TableOperation.Delete(item));
        }

        #endregion
    }
}