﻿using OnlineShop.Core.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OnlineShop.Client.Services.State
{
    public class ProductState
    {
        private readonly HttpClient _client;
        private Lazy<List<ProductCard>> _cache;

        public ProductState(HttpClient client)
        {
            _client = client;
            _cache = new Lazy<List<ProductCard>>();
        }

        public async Task<List<ProductCard>> FetchCards()
        {
            if (_cache.IsValueCreated)
                return _cache.Value;

            var products = await _client.GetFromJsonAsync<List<ProductCard>>("/api/product") ?? new List<ProductCard>();
            _cache = new Lazy<List<ProductCard>>(products);
            return products;
        }

        public async Task<ProductCard> FetchCard(long id)
        {
            var product = await _client.GetFromJsonAsync<ProductCard>($"/api/product/{id}");
            return product;
        }

        public async Task<ProductCard?> UpdateProduct(long id, ProductCard product)
        {
            InvalidateCache();
            var result = await _client.PutAsJsonAsync($"/api/product/{id}", product);
            return await result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<ProductCard>();
        }

        public async Task<ProductCard?> CreateProduct(ProductCard product)
        {
            InvalidateCache();
            var result = await _client.PostAsJsonAsync($"/api/product", product);
            return await result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<ProductCard>();
        }

        public async Task<bool> DeleteProduct(long id)
        {
            InvalidateCache();
            var result = await _client.DeleteAsync($"/api/product/{id}");
            return result.IsSuccessStatusCode;
        }

        private void InvalidateCache() =>
            _cache = new Lazy<List<ProductCard>>();
    }
}