﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Effects;
using System.Windows.Threading;
using Zhai.Famil.Common.Mvvm;
using Zhai.Famil.Common.Mvvm.Command;
using Zhai.Famil.Common.Threads;
using Zhai.Famil.Controls;
using MessageBox = Zhai.Famil.Dialogs.MessageBox;
using ConfirmBox = Zhai.Famil.Dialogs.ConfirmBox;

namespace Zhai.PictureView
{
    internal partial class PictureWindowViewModel : ViewModelBase
    {
        private Folder folder;
        public Folder Folder
        {
            get => folder;
            set
            {
                if (Set(() => Folder, ref folder, value))
                {
                    SetCurrentFolder();
                }
            }
        }

        private bool? isShowPictureListView;
        public bool? IsShowPictureListView
        {
            get => isShowPictureListView;
            set => Set(() => IsShowPictureListView, ref isShowPictureListView, value);
        }

        private bool isShowPictureEffectsView = false;
        public bool IsShowPictureEffectsView
        {
            get => isShowPictureEffectsView;
            set => Set(() => IsShowPictureEffectsView, ref isShowPictureEffectsView, value);
        }

        private Picture currentPicture;
        public Picture CurrentPicture
        {
            get => currentPicture;
            set
            {
                if (value != null)
                {
                    if (Set(() => CurrentPicture, ref currentPicture, value))
                    {
                        CurrentPictureChanged?.Invoke(this, value);

                        //if (value != null && value.ThumbState == PictureState.Failed)
                        //{
                        //    ThreadPool.QueueUserWorkItem(_ => value.DrawThumb());
                        //}

                        base.RaisePropertyChanged(nameof(IsCurrentPictureIsVideo));
                    }
                }
            }
        }

        private int currentPictureIndex;
        public int CurrentPictureIndex
        {
            get => currentPictureIndex;
            set
            {
                if (Set(() => CurrentPictureIndex, ref currentPictureIndex, value))
                {
                    DisplayedPictureIndex = value + 1;
                }
            }
        }

        private int displayedPictureIndex = 1;
        public int DisplayedPictureIndex
        {
            get => displayedPictureIndex;
            set => Set(() => DisplayedPictureIndex, ref displayedPictureIndex, value);
        }

        private bool isPictureMoving = false;
        public bool IsPictureMoving
        {
            get => isPictureMoving;
            set => Set(() => IsPictureMoving, ref isPictureMoving, value);
        }

        private double rotateAngle = 0.0;
        public double RotateAngle
        {
            get => rotateAngle;
            set => Set(() => RotateAngle, ref rotateAngle, value);
        }

        private double scale = 0.0;
        public double Scale
        {
            get => scale;
            set
            {
                if (Set(() => Scale, ref scale, value))
                {
                    ScaleChanged?.Invoke(this, value);
                }
            }
        }

        private bool isPictureCarouselPlaing = false;
        public bool IsPictureCarouselPlaing
        {
            get => isPictureCarouselPlaing;
            set
            {
                if (Set(() => IsPictureCarouselPlaing, ref isPictureCarouselPlaing, value))
                {
                    if (Folder.Any())
                    {
                        if (value)
                            PictureCarousel.Instance.Play();
                        else
                            PictureCarousel.Instance.Stop();
                    }
                }
            }
        }

        private bool isShowGallery = false;
        public bool IsShowGallery
        {
            get => isShowGallery;
            set => Set(() => IsShowGallery, ref isShowGallery, value);
        }

        private bool isShowFolderBorthersView = false;
        public bool IsShowFolderBorthersView
        {
            get => isShowFolderBorthersView;
            set => Set(() => IsShowFolderBorthersView, ref isShowFolderBorthersView, value);
        }

        private string folderBorthersSearchText;
        public string FolderBorthersSearchText
        {
            get => folderBorthersSearchText;
            set
            {
                if (Set(() => FolderBorthersSearchText, ref folderBorthersSearchText, value))
                {
                    SearchFolderBorthers(value);
                }
            }
        }

        private ConcurrentObservableCollection<DirectoryInfo> folderBorthers = new ConcurrentObservableCollection<DirectoryInfo>();
        public ConcurrentObservableCollection<DirectoryInfo> FolderBorthers
        {
            get => folderBorthers;
            set => Set(() => FolderBorthers, ref folderBorthers, value);
        }

        private DirectoryInfo currentFolder;
        public DirectoryInfo CurrentFolder
        {
            get => currentFolder;
            set
            {
                if (Set(() => CurrentFolder, ref currentFolder, value))
                {
                    CurrentFolderChanged.Invoke(this, value);
                }
            }
        }

        private PictureEffect currentPictureEffect;
        public PictureEffect CurrentPictureEffect
        {
            get => currentPictureEffect;
            set => Set(() => CurrentPictureEffect, ref currentPictureEffect, value);
        }


        public bool IsPictureCountMoreThanOne => Folder?.Count > 1;

        public bool IsCanPicturesNavigated => CurrentPicture != null && Folder != null && (Folder.Count > 1 || Folder.Borthers.Count > 1);

        public bool IsCurrentPictureIsVideo => CurrentPicture != null && CurrentPicture.IsVideo;

        public ObservableCollection<PictureEffect> Effects { get; }


        public PictureWindowViewModel()
        {
            var effects = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.FullName.Contains("Zhai.PictureView.ShaderEffects"))
                .Select(t => new PictureEffect(t.Name, System.Activator.CreateInstance(t) as ShaderEffect));

            Effects = new ObservableCollection<PictureEffect>(effects);

            Effects.Insert(0, new PictureEffect("Original", null));
        }


        #region Methods

        public async Task OpenPictureAsync(DirectoryInfo dir, string filename = null, List<DirectoryInfo> borthers = null)
        {
            var newFolder = new Folder(dir, borthers);

            if (newFolder.IsAccessed)
            {
                var oldFolder = Folder;

                Folder = newFolder;
                Folder.BorthersLoaded += Folder_BorthersLoaded;

                await Folder.LoadAsync();

                base.RaisePropertyChanged(nameof(IsPictureCountMoreThanOne));

                CurrentPicture = (filename == null ? Folder : Folder.Where(t => t.PicturePath == filename)).FirstOrDefault();

                if (oldFolder != null)
                {
                    ThreadPool.QueueUserWorkItem(_ => ApplicationDispatcher.InvokeOnUIThread(() => oldFolder.Cleanup()));
                }

                if (IsShowPictureListView == null)
                {
                    await Task.Delay(1000);

                    IsShowPictureListView = Folder != null && Folder.Count > 1;
                }
            }
            else
            {
                MessageBox.Show(App.Current.MainWindow as WindowBase, ($"软件对路径：“{dir.FullName}”没有访问权限！"));
            }
        }

        public Task OpenPictureAsync(string filename)
            => OpenPictureAsync(Directory.GetParent(filename), filename);

        private void Folder_BorthersLoaded(object sender, List<DirectoryInfo> borthers)
        {
            Folder.BorthersLoaded -= Folder_BorthersLoaded;

            if (borthers != null && borthers.Any())
            {
                base.RaisePropertyChanged(nameof(IsCanPicturesNavigated));

                ThreadPool.QueueUserWorkItem(_ =>
                {
                    FolderBorthers.Clear();

                    foreach (var item in borthers)
                    {
                        FolderBorthers.Add(item);
                    }
                });
            }
        }

        private void SetCurrentFolder()
        {
            CurrentFolder = FolderBorthers.Where(t => t.FullName == Folder.Current.FullName).FirstOrDefault();
        }

        public async void SearchFolderBorthers(string keyword)
        {
            if (Folder != null && Folder.Borthers != null && Folder.Borthers.Any())
            {
                await Task.Run(() =>
                {
                    FolderBorthers.Clear();

                    var list = string.IsNullOrWhiteSpace(keyword) ? Folder.Borthers : Folder.Borthers.Where(t => t.Name.IndexOf(keyword) != -1);

                    foreach (var item in list)
                    {
                        FolderBorthers.Add(item);
                    }
                });

                SetCurrentFolder();
            }
        }

        #endregion

        #region Commands

        public RelayCommand ExecuteTogglePictureEffectsViewCommand => new Lazy<RelayCommand>(() => new RelayCommand(() =>
        {
            IsShowPictureEffectsView = !IsShowPictureEffectsView;

        }, () => CurrentPicture != null && CurrentPicture.IsLoaded)).Value;

        public RelayCommand ExecuteCopyCurrentPictureSourceCommand => new Lazy<RelayCommand>(() => new RelayCommand(() =>
        {
            System.Windows.Clipboard.SetImage(CurrentPicture.PictureSource);

        }, () => CurrentPicture != null && CurrentPicture.IsLoaded)).Value;

        public RelayCommand ExecuteSaveImageCommand => new Lazy<RelayCommand>(() => new RelayCommand(async () =>
        {
            if (Famil.Win32.CommonDialog.SaveFileDialog(Folder.Current.FullName, "", "保存...", "", CurrentPicture.Extension, default, out string filename))
            {
                var isSuccess = await CurrentPicture.SaveAsync(filename);

                if (isSuccess)
                {
                    SendNotificationMessage("保存成功！");
                }
                else
                {
                    SendNotificationMessage("保存失败！");
                }
            }

        }, () => CurrentPicture != null && CurrentPicture.IsLoaded)).Value;

        public RelayCommand ExecuteSaveAsImageCommand => new Lazy<RelayCommand>(() => new RelayCommand(() =>
        {
            var window = new SaveAsWindow(CurrentPicture);

            window.Owner = App.Current.MainWindow;

            window.ShowDialog();

        }, () => CurrentPicture != null && CurrentPicture.IsLoaded)).Value;

        public RelayCommand ExecuteCopyCurrentPicturePathCommand => new Lazy<RelayCommand>(() => new RelayCommand(() =>
        {
            System.Windows.Clipboard.SetText(CurrentPicture.PicturePath);

        })).Value;

        public RelayCommand ExecuteOpenTheFolderCommand => new Lazy<RelayCommand>(() => new RelayCommand(() =>
        {
            var info = new System.Diagnostics.ProcessStartInfo("Explorer.exe")
            {
                Arguments = $"/select,{CurrentPicture.PicturePath}"
            };
            System.Diagnostics.Process.Start(info);

        }, () => CurrentPicture != null)).Value;

        #endregion

        public event EventHandler<Picture> CurrentPictureChanged;

        public event EventHandler<DirectoryInfo> CurrentFolderChanged;

        public event EventHandler<Double> ScaleChanged;

        public override void Cleanup()
        {
            base.Cleanup();

            Folder.Cleanup();
        }
    }
}
