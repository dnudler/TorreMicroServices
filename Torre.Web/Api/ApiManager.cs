using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Torre.Web.Configurations;
using Torre.Web.Models;

namespace Torre.Web.Api
{
    public class ApiManager
    {
        private readonly TorreConfig _config;
        public ApiManager(TorreConfig config)
        {
            _config = config;
        }
        #region User Section
        public ICollection<User> GetUsers()
        {
            string apiUrl = $"{_config.UserApiUrl}all";
            JArray jsonString = GetJSONString<JArray>(apiUrl);
            var users = jsonString?.ToObject<ICollection<User>>();
            return users;
        }

        public User GetUserById(int id)
        {
            string apiUrl = $"{_config.UserApiUrl}Get/{id}";
            JObject jsonString = GetJSONString<JObject>(apiUrl);
            var users = jsonString?.ToObject<User>();
            return users;
        }

        public User UpdateUser(User u)
        {
            string apiUrl = $"{_config.UserApiUrl}Update/{u.Id}";
            JObject jsonString = PutJSONString<JObject>(apiUrl, u);
            var users = jsonString?.ToObject<User>();
            return users;
        }

        public bool DeleteUser(int id)
        {
            string apiUrl = $"{_config.UserApiUrl}Delete/{id}";
            bool success = DeleteJSONString<JObject>(apiUrl);
            return success;
        }

        public User AddUser(string name)
        {
            string apiUrl = $"{_config.UserApiUrl}Add";
            var bodyObj = new
            {
                Name = name
            };
            JObject jsonString = PostJSONString<JObject>(apiUrl, bodyObj);
            var users = jsonString?.ToObject<User>();
            return users;
        }
        #endregion

        #region Task Region

        public ICollection<Task> GetTasks(int userId)
        {
            string apiUrl = $"{String.Format(_config.TaskApiUrl, userId)}/Get";
            JArray jsonString = GetJSONString<JArray>(apiUrl);
            var tasks = jsonString?.ToObject<ICollection<Task>>();
            return tasks;
        }

        public Task GetTaskById(int userId, int id)
        {
            string apiUrl = $"{String.Format(_config.TaskApiUrl, userId)}/Get/{id}";
            JObject jsonString = GetJSONString<JObject>(apiUrl);
            var task = jsonString?.ToObject<Task>();
            return task;
        }

        public Task UpdateTask(int userId, Task u)
        {
            string apiUrl = $"{String.Format(_config.TaskApiUrl, userId)}/Update/{u.Id}";

            JObject jsonString = PutJSONString<JObject>(apiUrl, u);
            var task = jsonString?.ToObject<Task>();
            return task;
        }

        public bool DeleteTask(int userId, int id)
        {
            string apiUrl = $"{String.Format(_config.TaskApiUrl, userId)}/Delete/{id}";
            bool success = DeleteJSONString<JObject>(apiUrl);
            return success;
        }

        public Task AddTask(int userId, string description, int state)
        {
            string apiUrl = $"{String.Format(_config.TaskApiUrl, userId)}/Add";
            var bodyObj = new
            {
                Description = description,
                State = state,
                UserId = userId
            };
            JObject jsonString = PostJSONString<JObject>(apiUrl, bodyObj);
            var task = jsonString?.ToObject<Task>();
            return task;
        }

        #endregion

        private T PostJSONString<T>(string url, object bodyObj)
        {
            HttpResponseMessage response;
            T returnData = default(T);
            try
            {
                HttpClient webAPIClient = new HttpClient();
                
                if (!string.IsNullOrEmpty(url))
                {
                    var jsonObj = Newtonsoft.Json.JsonConvert.SerializeObject(bodyObj);
                    var task = webAPIClient.PostAsync(url, new StringContent(jsonObj, Encoding.UTF8, "application/json"));
                    task.Wait();
                    if (task.IsCompleted)
                    {
                        response = task.Result;

                        var taskRead = response.Content.ReadAsStringAsync();
                        taskRead.Wait();
                        string json = taskRead.Result;
                        var objs = JsonConvert.DeserializeObject(json);
                        returnData = (T)objs;
                    }

                }

            }
            catch (Exception e)
            {
                Console.Write("");                
            }


            return returnData;
        }

        private T PutJSONString<T>(string url, object bodyObj)
        {
            HttpResponseMessage response;
            T returnData = default(T);
            try
            {
                HttpClient webAPIClient = new HttpClient();

                if (!string.IsNullOrEmpty(url))
                {
                    var jsonObj = Newtonsoft.Json.JsonConvert.SerializeObject(bodyObj);
                    var task = webAPIClient.PutAsync(url, new StringContent(jsonObj, Encoding.UTF8, "application/json"));
                    task.Wait();
                    if (task.IsCompleted)
                    {
                        response = task.Result;

                        var taskRead = response.Content.ReadAsStringAsync();
                        taskRead.Wait();
                        string json = taskRead.Result;
                        var objs = JsonConvert.DeserializeObject(json);
                        returnData = (T)objs;
                    }

                }

            }
            catch (Exception e)
            {
                Console.Write("");
            }


            return returnData;
        }

        private T GetJSONString<T>(string url)
        {
            T returnData = default(T); ;
            HttpResponseMessage response;
            try
            {
                HttpClient webApiClient = new HttpClient();

                if (!string.IsNullOrEmpty(url))
                {
                    var task = webApiClient.GetAsync(url);
                    task.Wait();
                    if (task.IsCompleted)
                    {
                        response = task.Result;
                        response.EnsureSuccessStatusCode();
                        var taskRead = response.Content.ReadAsStringAsync();
                        taskRead.Wait();
                        string json = taskRead.Result;
                        var objs = JsonConvert.DeserializeObject(json);
                        returnData = (T)objs;
                    }

                }

            }
            catch (Exception e)
            {
                System.Console.Write("");
            }
            return returnData;
        }

        private bool DeleteJSONString<T>(string url)
        {
            bool success = true;
            HttpResponseMessage response;
            try
            {
                HttpClient webApiClient = new HttpClient();

                if (!string.IsNullOrEmpty(url))
                {
                    var task = webApiClient.DeleteAsync(url);
                    task.Wait();
                    if (task.IsCompleted)
                    {
                        response = task.Result;
                        response.EnsureSuccessStatusCode();
                        return true;
                    }

                }

            }
            catch (Exception e)
            {
                success = false;
            }
            return success;
        }
    }
}
