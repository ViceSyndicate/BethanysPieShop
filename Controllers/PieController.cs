﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

         public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            // These classes will be injected automatically from the Dependency Injection System
            // Because we registered them in Startup.ConfigureServices()
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            // delcare object
            PiesListViewModel piesListViewModel = new PiesListViewModel();
            // set object
            piesListViewModel.Pies = _pieRepository.AllPies;

            piesListViewModel.CurrentCategory = "Cheese cakes";
            return View(_pieRepository.AllPies);
        }
    }
}