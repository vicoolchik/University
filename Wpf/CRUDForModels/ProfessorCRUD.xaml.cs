using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpf.CRUDForModels
{
    /// <summary>
    /// Interaction logic for ProfessorCRUD.xaml
    /// </summary>
    public partial class ProfessorCRUD : Window
    {
        public ProfessorCRUD()
        {
            InitializeComponent();
            GetCategory();

            AddNewCategoryGrid.DataContext = NewCtegory;
        }

        static IMapper Mapper = SetupMapper();
        ProfessorDTO NewCtegory = new ProfessorDTO();
        ProfessorDTO selectedCategory = new ProfessorDTO();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(CategoryDal).Assembly)
                );
            return config.CreateMapper();
        }

        private void GetCategory()
        {
            var dal = new CategoryDal(Mapper);

            var categoriesList = dal.GetAllCategories();
            CategoryDG.ItemsSource = categoriesList;
        }

        private void AddCategory(object s, RoutedEventArgs e)
        {
            var dal = new CategoryDal(Mapper);

            NewCtegory = dal.CreateCategory(NewCtegory);

            GetCategory();
            NewCtegory = new CategoryDTO();
            AddNewCategoryGrid.DataContext = NewCtegory;
        }

        private void DeleteCategory(object s, RoutedEventArgs e)
        {
            var categoryToBeDeleted = (s as FrameworkElement).DataContext as CategoryDTO;

            var dal = new CategoryDal(Mapper);
            dal.DeleteCategory(categoryToBeDeleted);
            GetCategory();
        }

        private void UpdateCategoryForEdit(object s, RoutedEventArgs e)
        {
            selectedCategory = (s as FrameworkElement).DataContext as CategoryDTO;
            UpdateCategoryGrid.DataContext = selectedCategory;
        }

        private void UpdateCategory(object s, RoutedEventArgs e)
        {
            var dal = new CategoryDal(Mapper);
            dal.EditCategory(selectedCategory);
            GetCategory();
        }
    }
}
