# GreenLight

*Sistema Inteligente de Iluminação Sustentável*

O GreenLight é uma solução inovadora e sustentável projetada para otimizar o uso de iluminação em grandes áreas, como indústrias, complexos empresariais e outros ambientes de grande escala. Utilizando sensores de luminosidade (LDR), o sistema garante que as lâmpadas sejam ativadas apenas quando necessário, promovendo economia de energia e sustentabilidade.

O grande diferencial do GreenLight é a integração com um aplicativo inteligente, que permite aos usuários monitorar o consumo de energia em tempo real e o histórico mensal. Além disso, o aplicativo oferece a funcionalidade de desligamento manual das lâmpadas, essencial para manutenção ou ajustes em áreas específicas. Porém, o sistema não permite que as lâmpadas sejam ligadas manualmente se houver luz suficiente, eliminando desperdícios causados por erros humanos.

## Principais Benefícios

• **Economia de Energia:**

Reduz o consumo desnecessário, desligando automaticamente as lâmpadas em condições de alta luminosidade natural.

• **Controle Inteligente:**

Monitoramento em tempo real e histórico de consumo mensal através de um aplicativo integrado.
Opção de desligamento manual para ajustes em situações específicas, com bloqueio para evitar ligações inadequadas.

• **Sustentabilidade:**

Promove práticas empresariais sustentáveis, reduzindo o impacto ambiental e a emissão de carbono.

• **Redução de Custos Operacionais:**

Minimiza gastos com energia elétrica e manutenção.

• **Escalabilidade e Flexibilidade:**

Adaptável a sistemas de iluminação existentes ou novos, adequado para ambientes de qualquer porte.

## Cenários de Uso

Indústrias e Galpões: Controle eficiente da iluminação em grandes áreas operacionais.
Complexos Empresariais: Iluminação automatizada para escritórios, corredores e estacionamentos.
Centros Comerciais e Áreas Públicas: Aplicações em estacionamentos, praças e parques, ajustando a luz conforme a necessidade.

## Por que o GreenLight?

Diferente de sistemas tradicionais ou sensores de movimento, o GreenLight utiliza sensores LDR para medir a luminosidade ambiente com precisão. Essa abordagem elimina desperdícios de energia e oferece controle inteligente e seguro, garantindo que erros humanos não impactem o desempenho do sistema.

## CRUD da API

Para garantir o correto funcionamento do CRUD e dos relacionamentos entre as entidades, siga a ordem de criação dos registros (POST) de acordo com as dependências:

### Ordem de Postagem
1. **Usuario** (necessário para criar Lampada)
2. **Lampada** (necessário para criar Registro)
3. **Registro** (última entidade, pois depende de todas as anteriores)

---

## Exemplos de JSONs para POST

### 1. Usuario
```json
{
  "id": 1,
  "nome": "Lucas Monte",
  "email": "lucas@monte",
  "senha": "lucasmonte123",
  "lampadas": null
}
```


```json
{
  "id": 2,
  "nome": "Pedro Sena",
  "email": "pedro@sena",
  "senha": "pedrosena456",
  "lampadas": null
}
```

### 2. Lampada

```json
{
  "id": 1,
  "apelido": "Lampada Oficina",
  "nomeDispositivo": "SmartLight1",
  "modo": false,
  "usuarioId": 1
}
```

```json
{
  "id": 2,
  "apelido": "Lampada Escritorio",
  "nomeDispositivo": "SmartLight2",
  "modo": true,
  "usuarioId": 2
}
```

### 3. Registro
```json
{
  "id": 1,
  "lampadaId": 1,
  "lampada": null,
  "consumoWh": 25,
  "dataConsumo": "2024-11-22T12:00:00.000Z",
  "diferencaMes": 5
}
```

```json
{
  "id": 2,
  "lampadaId": 2,
  "lampada": null,
  "consumoWh": 60,
  "dataConsumo": "2024-11-22T18:30:00.000Z",
  "diferencaMes": 12
}
```


## Integrantes

Lucas Monte Verde - RM:551604 - 2TDSA

Ricardo Brito - RM:98370 - 2TDSA

Gabriel Mendes Cirillo -RM:98214 - 2TDSA

Pedro Sena - RM:98021 - 2TDSA

Mirelly Azevedo - RM:98672 - 2TDSPF
