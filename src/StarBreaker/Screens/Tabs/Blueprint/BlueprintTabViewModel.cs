using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;
using Avalonia.Controls.Selection;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarBreaker.DataCore;
using StarBreaker.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StarBreaker.Screens;

public sealed partial class BlueprintTabViewModel : PageViewModelBase
{
    public override string Name => "Blueprint";
    public override string Icon => "MapFilled";
}