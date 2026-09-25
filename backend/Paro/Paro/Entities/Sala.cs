namespace Paro.Entities;

public class Sala
{
    public int Id { get; set; }
    public int IdRodada { get; set; }
    public int Codigo { get; set; }
    public StatusEnum Status { get; set; } = StatusEnum.NaoIniciada;
    public int QuantidadeRodadas { get; set; }
    public List<Jogador>? Jogadores { get; set; }
    public bool Ativa
    {
        get
        {
            if (Status == StatusEnum.Finalizada)
            {
                return false;
            }
            return true;
        }
    }

    public enum StatusEnum
    {
        NaoIniciada,
        EmAndamento,
        Finalizada
    }
}