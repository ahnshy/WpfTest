﻿using Prism;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PrismStep5.ViewModels
{
    /// <summary>
    /// IActiveAware 인터페이스를 추가합니다.
    /// </summary>
    public class Test1ViewModel : BindableBase, INavigationAware, IActiveAware
    {
        public string Header { get; set; }
        /// <summary>
        /// 액티브 체인지 이벤트 - IActiveAware
        /// </summary>
        public event EventHandler IsActiveChanged;
        private bool _isActive;
        /// <summary>
        /// IsActive 활성화 여부 프로퍼티 - IActiveAware
        /// </summary>
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value, () => Messages.Add($"{GetType().Name} IsActive : {IsActive}")); }
        }

        private IList<string> _messages = new ObservableCollection<string>();
        /// <summary>
        /// 메시지 목록
        /// </summary>
        public IList<string> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }

        public Test1ViewModel()
        {
            Header = GetType().Name;
            Messages.Add(Header);
        }

        /// <summary>
        /// 네비게이트 To
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Messages.Add($"{GetType().Name} OnNavigatedTo - {navigationContext.NavigationService.Journal.CurrentEntry}");
        }
        /// <summary>
        /// 네비게이트 가능 여부
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        /// <summary>
        /// 네비게이트 From
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Messages.Add($"{GetType().Name} OnNavigatedFrom");
        }
    }
}
