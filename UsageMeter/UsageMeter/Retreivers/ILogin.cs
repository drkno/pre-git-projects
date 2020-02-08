using System.Windows.Forms;

namespace UsageMeter.Retreivers
{
    public interface ILogin
    {
        bool DetailsWereProvided { get; }
        DialogResult ShowDialog();
        bool LoginRequired { get; }
    }
}
