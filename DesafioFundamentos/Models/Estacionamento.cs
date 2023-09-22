using DesafioFundamentos.Validators.Veiculos;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private readonly decimal precoInicial = 0;
        private readonly decimal precoPorHora = 0;
        private List<string> veiculos = new();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string licensePlate = Console.ReadLine();

            if (!VeiculoValidator.IsValidLicencePlate(licensePlate))
            {
                Console.WriteLine("Digite uma placa de veículo válida");
                return;
            }

            veiculos.Add(licensePlate);
            Console.WriteLine(string.Concat(licensePlate, " Estacionado com sucesso."));
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Informe a quantidade de horas que o veículo permaneceu estacionado");
                bool usuarioInformouUmValorNumerico = int.TryParse(Console.ReadLine(), out int horas);

                if (usuarioInformouUmValorNumerico)
                {
                    decimal valorTotal = this.precoInicial + this.precoPorHora * horas;

                    // Remove o veículo do estacionamento
                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}"); 
                }
                else
                {
                    Console.WriteLine("Quantidade de horas precisa ser um valor inteiro!");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in this.veiculos)
                {
                    Console.WriteLine(string.Concat(veiculo, "\n"));
                };
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
