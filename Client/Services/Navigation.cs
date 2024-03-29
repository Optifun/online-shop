﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Client.Services
{
public class Navigation : IDisposable
    {
        private const int MinHistorySize = 256;
        private const int AdditionalHistorySize = 64;
        private readonly NavigationManager _navigationManager;
        private readonly List<string> _history;
        private readonly IJSRuntime _jsRuntime;

        public Navigation(NavigationManager navigationManager, IJSRuntime jsRuntime)
        {
            _navigationManager = navigationManager;
            _jsRuntime = jsRuntime;
            _history = new List<string>(MinHistorySize + AdditionalHistorySize);
            _history.Add(_navigationManager.Uri);
            _navigationManager.LocationChanged += OnLocationChanged;
        }

        /// <summary>
        /// Navigates to the specified url.
        /// </summary>
        /// <param name="url">The destination url (relative or absolute).</param>
        /// <param name="force">Allow to force navigation</param>
        public void NavigateTo(string url, bool force = false) => 
            _navigationManager.NavigateTo(url, force);

        public string GetLocation() => 
            _navigationManager.Uri;

        /// <summary>
        /// Returns true if it is possible to navigate to the previous url.
        /// </summary>
        public bool CanNavigateBack => _history.Count >= 2;

        /// <summary>
        /// Navigates to the previous url if possible or does nothing if it is not.
        /// </summary>
        public void NavigateBack()
        {
            if (!CanNavigateBack) return;
            var backPageUrl = _history[^2];
            _history.RemoveRange(_history.Count - 2, 2);
            _navigationManager.NavigateTo(backPageUrl);
        }

        public async Task OpenNewTab(string url) =>
            await _jsRuntime.InvokeAsync<string>("open", $"{_navigationManager.BaseUri}/{url}", "_blank");

        // .. All other navigation methods.

        private void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            EnsureSize();
            _history.Add(e.Location);
        }

        private void EnsureSize()
        {
            if (_history.Count < MinHistorySize + AdditionalHistorySize) return;
            _history.RemoveRange(0, _history.Count - MinHistorySize);
        }

        public void Dispose()
        {
            _navigationManager.LocationChanged -= OnLocationChanged;
        }
    }
}