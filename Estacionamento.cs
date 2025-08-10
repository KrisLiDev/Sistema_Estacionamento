namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private readonly decimal precoInicial;
        private readonly decimal precoPorHora;
        private readonly List<string> veiculos = new();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.Write("Digite a placa do veículo para estacionar: ");
            string placa = Console.ReadLine()?.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Operação cancelada.");
                return;
            }

            if (veiculos.Contains(placa))
            {
                Console.WriteLine("Este veículo já está estacionado.");
                return;
            }

            veiculos.Add(placa);
            Console.WriteLine($"Veículo {placa} registrado com sucesso.");
        }

        public void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo para remover: ");
            string placa = Console.ReadLine()?.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Operação cancelada.");
                return;
            }

            if (!veiculos.Contains(placa))
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui.");
                return;
            }

            Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
            if (!int.TryParse(Console.ReadLine(), out int horas) || horas < 0)
            {
                Console.WriteLine("Valor inválido para horas. Operação cancelada.");
                return;
            }

            decimal valorTotal = precoInicial + (precoPorHora * horas);
            veiculos.Remove(placa);

            Console.WriteLine($"O veículo {placa} foi removido. Preço total: R$ {valorTotal:F2}");
        }

        public void ListarVeiculos()
        {
            if (!veiculos.Any())
            {
                Console.WriteLine("Não há veículos estacionados.");
                return;
            }

            Console.WriteLine("Veículos estacionados:");
            foreach (string placa in veiculos)
            {
                Console.WriteLine($"- {placa}");
            }
        }
    }
}
