namespace Vehiculos.Domain
{
    public interface IVehicle
    {
        void SpeedUp();
        void Brake();
        int GetSpeed();
    }
}
