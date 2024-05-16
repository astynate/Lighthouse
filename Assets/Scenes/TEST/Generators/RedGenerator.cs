
namespace Yd.Generators
{
    public class RedGenerator : Yd.Generators.BasicGenerator
    {
        bool CheckForToolkit(){
            return true;
        }
        public override void RepairGenerator()
        {
            if(isPLayerInside && CheckForToolkit() ){
                InvokeRepair();
            }
        }
    }
}
