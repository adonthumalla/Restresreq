﻿using APIAutomationSetup.Models;
using APIAutomationSetup.Models_DTO;
using Newtonsoft.Json;
using Restresreq.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomationSetup
{
    public class RequestResponseTest
    {
        private UserHelper userHelper;

        public RequestResponseTest()
        {
            userHelper = new UserHelper();
        }

        public UserHelper UserHelper { get; private set; }

        public Users getUsers()
        {
            var client = userHelper.SetUrl("api/users?page=2");
            var request = userHelper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = userHelper.GetResponse(client, request);
            var users = userHelper.GetContent<Users>(response);
            return users;
        }

        public CreateUserRes CreateNewUser(string payload)
        {
            var client = userHelper.SetUrl("api/users");
            var request = userHelper.CreatePostRequest(payload);
            var response = userHelper.GetResponse(client, request);
            var createuser = userHelper.GetContent<CreateUserRes>(response);
            return createuser;
        }

        public Users getAllUsers()
        {
            var client = userHelper.SetUrl("api/users?page=2");
            var request = userHelper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = userHelper.GetResponse(client, request);
            var users = userHelper.GetContent<Users>(response);
            return users;
        }

        public UpdateUserRes CreatePutRequest(string payload)
        {
            var client = userHelper.SetUrl("api/users/2");
            var request = userHelper.CreatePutRequest(payload);
            var response = userHelper.GetResponse(client, request);
            var updateuser = userHelper.GetContent<UpdateUserRes>(response);
            return updateuser;

        }

        public int CreateDeleteRequest()
        {
            var client = userHelper.SetUrl("api/users/2");
            var request = userHelper.CreateDeleteRequest();
            var response = userHelper.GetResponse(client, request);
            var statusCode = userHelper.GetStatusCode(response);
            return statusCode;

        }

        /*public RegisterSuccessful CreateRegisterRequest()
        {
            var client = userHelper.SetUrl("api/register");
            var request = userHelper.CreateRegisterRequest();
            var response = userHelper.GetResponse(client, request);
            var registeruser = userHelper.GetContent<RegisterSuccessful>(response);
            return registeruser;

        }*/
    }
}

