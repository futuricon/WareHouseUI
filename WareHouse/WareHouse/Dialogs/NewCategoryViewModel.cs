using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WareHouse.Models.DbModels;
using WareHouse.Models.Repositories;

namespace WareHouse.Dialogs
{
	class NewCategoryViewModel :DialogViewModelBase
	{
		ICategoryRepository categoryRepository = null;
		#region Fields
		private ObservableCollection<Category> categoryCollection;
		IList<int> addedPositionIndex =new List<int>();
		#endregion
		#region Properties
		public ObservableCollection<Category> CategoryCollection { get => categoryCollection; set { categoryCollection = value; RaisePropertyChanged(); } }	
		#endregion

		#region Commands
		public DelegateCommand AddToCollectionCommand { get; private set; }
		public DelegateCommand<Category> DeleteCategoryCommand { get; private set; }
		#endregion


		public NewCategoryViewModel()
		{
			AddToCollectionCommand = new DelegateCommand(InsertNewItemToCollection);
			DeleteCategoryCommand = new DelegateCommand<Category>(DeleteCategory);
		}

		private void DeleteCategory(Category o)
		{
			try
			{
				categoryRepository.Delete(o.Id);
				CategoryCollection.Remove(o);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Не удалось удалить категорию " + ex.Message);
			}
		}

		public override void OnDialogOpened(IDialogParameters parameters)
		{
			categoryRepository = parameters.GetValue<ICategoryRepository>("repo");
			CategoryCollection = parameters.GetValue<ObservableCollection<Category>>("collection");
			if (CategoryCollection == null)
			{
				CategoryCollection = new ObservableCollection<Category>(categoryRepository.GetAll());
			}

			CategoryCollection.CollectionChanged += CategoryCollection_CollectionChanged;
		}

		private void CategoryCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
					CategoryCollection.LastOrDefault().CollectionPosition = CategoryCollection.Count - 1;
					break;					
				default:
					break;
			}
		}

		private void InsertNewItemToCollection()
		{
			CategoryCollection.Add(new Category());	
		}	

		protected override void CloseDialogOnCancel(IDialogParameters parameters)
		{
			Result = ButtonResult.OK;
			if (parameters == null) parameters = new DialogParameters();
			parameters.Add("collection", new ObservableCollection<Category>(CategoryCollection));

		//	Task.Run(async () =>
		//	{
				try
				{
					foreach (var c in CategoryCollection)
					{
						if (c.Action == Models.Infrastructure.CollectionAction.NoAction) continue;
						if (c.Action == Models.Infrastructure.CollectionAction.Add)
						{
							 categoryRepository.Create(c);
						}
						if (c.Action == Models.Infrastructure.CollectionAction.Update)
						{
							 categoryRepository.Update(c);
						}
					}

					
				}
				catch (Exception ex)
				{
					MessageBox.Show("Не удалось добавить категорию или категории " + ex.Message);
					parameters = null;

				}
			//	});
			CloseDialog(parameters);

		}

		protected override void KeyUpEventHandler(KeyEventArgs key)
		{
			if (key.Key == Key.Escape)
			{
				CloseDialogOnCancel(null);
			}
		}
	}
}
