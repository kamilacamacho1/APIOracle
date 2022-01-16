using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace APIOracle.WebApplication.Models.Autor
{
        public class AutorModel
        {
            private String UriApi;
            MediaTypeWithQualityHeaderValue mediaheader;
        public AutorModel()
        {
            //this.UriApi = "http://localhost:50809/"; // Local API
            this.UriApi = "https://localhost:7223/"; // Azure API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<AutorEntity>> GetAutor()
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Autor";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<AutorEntity> cList = await respuesta.Content.ReadAsAsync<List<AutorEntity>>();
                    return cList;
                }
                else { return null; }
            }
        }


        public async Task<AutorEntity> GetAutorByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Autor/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    AutorEntity c = await respuesta.Content.ReadAsAsync<AutorEntity>();
                    return c;
                }
                else { return null; }
            }
        }


        public async Task AddAutor(AutorEntity c)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Autor";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PostAsJsonAsync(peticion, c);
            }
        }

        public async Task EditAutor(AutorEntity c)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Autor";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PutAsJsonAsync(peticion, c);
            }
        }

        public async Task DeleteAutor(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Autor/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.DeleteAsync(peticion);
            }
        }
    }
}