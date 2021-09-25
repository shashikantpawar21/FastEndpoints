﻿using FastEndpoints;
using Web.Auth;

namespace Customers.List.Recent
{
    public class Endpoint : BasicEndpoint
    {
        public Endpoint()
        {
            Verbs(Http.GET);
            Routes("/customers/list/recent");
            Policies("AdminOnly");
            Roles(Role.Admin, Role.Staff);
            Permissions(Allow.Customers_Retrieve_Recent, Allow.Inventory_Create_Item);
        }

        protected override Task ExecuteAsync(EmptyRequest er, CancellationToken ct)
        {
            return SendAsync(new Response
            {
                Customers = new[] {
                    new KeyValuePair<string,int>("ryan gunner", 123),
                    new KeyValuePair<string,int>("debby ryan", 124),
                    new KeyValuePair<string,int>("ryan reynolds",321)
                }
            });
        }
    }
}
