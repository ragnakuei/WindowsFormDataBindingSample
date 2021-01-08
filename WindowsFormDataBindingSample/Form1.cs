﻿using System;
using System.Windows.Forms;

namespace WindowsFormDataBindingSample
{
    public partial class Form1 : Form
    {
        private readonly DataService      _dataService;
        private readonly BindingSource    _dtosBindinSource;
        private readonly BindingNavigator _biningNavigator;

        #region 單向 Binding

        public Form1(DataService dataService)
        {
            _dataService                     =  dataService;
            _dtosBindinSource                =  new BindingSource();
            _dtosBindinSource.CurrentChanged += DtosBindingSourceCurrentChanged;

            InitializeComponent();

            _biningNavigator      = new BindingNavigator(true);
            _biningNavigator.Dock = DockStyle.Top;
            this.Controls.Add(_biningNavigator);
        }

        // 這只能做單向 Binding
        private void DtosBindingSourceCurrentChanged(object sender, EventArgs e)
        {
            if (sender is BindingSource { Current: DataDto dto })
            {
                tbxDtoId.Text   = dto.Id.ToString();
                tbxDtoName.Text = dto.Name;
                tbxDtoAge.Text  = dto.Age.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dtos = _dataService.GetDtos();

            _dtosBindinSource.DataSource   = dtos;
            _biningNavigator.BindingSource = _dtosBindinSource;

            dgv.DataSource = _dtosBindinSource;
        }

        #endregion

        #region 雙向 Binding

        // public Form1(DataService dataService)
        // {
        //     _dataService                     =  dataService;
        //     _dtosBindinSource                =  new BindingSource();
        //
        //     InitializeComponent();
        //
        //     _biningNavigator      = new BindingNavigator(true);
        //     _biningNavigator.Dock = DockStyle.Top;
        //     this.Controls.Add(_biningNavigator);
        // }
        //
        // private void Form1_Load(object sender, EventArgs e)
        // {
        //     var dtos = _dataService.GetDtos();
        //
        //     _dtosBindinSource.DataSource   = dtos;
        //     _biningNavigator.BindingSource = _dtosBindinSource;
        //
        //     dgv.DataSource = _dtosBindinSource;
        //
        //     tbxDtoId.DataBindings.Add(nameof(TextBox.Text),
        //                               _dtosBindinSource,
        //                               nameof(DataDto.Id),
        //                               false,
        //                               DataSourceUpdateMode.OnPropertyChanged);
        //     tbxDtoName.DataBindings.Add(nameof(TextBox.Text),
        //                                 _dtosBindinSource,
        //                                 nameof(DataDto.Name),
        //                                 false,
        //                                 DataSourceUpdateMode.OnPropertyChanged);
        //     tbxDtoAge.DataBindings.Add(nameof(TextBox.Text),
        //                                _dtosBindinSource,
        //                                nameof(DataDto.Age),
        //                                false,
        //                                DataSourceUpdateMode.OnPropertyChanged);
        // }

        #endregion
    }
}
