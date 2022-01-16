using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace APIOracle.WebApplication.Models.Libro
{
        public class LibroModel
        {
            private String UriApi;
            MediaTypeWithQualityHeaderValue mediaheader;
        public LibroModel()
        {
            this.UriApi = "https://localhost:7223/"; // Local API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<LibroEntity>> GetLibro()
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Libro";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<LibroEntity> LList = await respuesta.Content.ReadAsAsync<List<LibroEntity>>();
                    return LList;
                }
                else { return null; }
            }
        }


        public async Task<LibroEntity> GetLibroByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Libro/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    LibroEntity a = await respuesta.Content.ReadAsAsync<LibroEntity>();
                    return a;
                }
                else { return null; }
            }
        }


        public async Task<bool> AddLibro(LibroEntity l)
        {

            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Libro";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.PostAsJsonAsync(peticion, l);
                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else { return false; }
            }


        }

        public async Task EditLibro(LibroEntity l)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Libro";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PutAsJsonAsync(peticion, l);
            }
        }

        public async Task DeleteLibro(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Libro/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.DeleteAsync(peticion);
            }
        }
    }
}