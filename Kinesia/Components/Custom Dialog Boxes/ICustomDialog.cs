using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Components.Custom_Dialog_Boxes
{
    public interface ICustomDialog
    {
        string Title { get; set; }
        string Description { get; set; }
        PictureBox DialogIcon { get; set; }
    }
}
