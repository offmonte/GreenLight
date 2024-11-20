# GreenLight

*Sistema Inteligente de Ilumina��o Sustent�vel*

O GreenLight � uma solu��o inovadora e sustent�vel projetada para otimizar o uso de ilumina��o em grandes �reas, como ind�strias, complexos empresariais e outros ambientes de grande escala. Utilizando sensores de luminosidade (LDR), o sistema garante que as l�mpadas sejam ativadas apenas quando necess�rio, promovendo economia de energia e sustentabilidade.

O grande diferencial do GreenLight � a integra��o com um aplicativo inteligente, que permite aos usu�rios monitorar o consumo de energia em tempo real e o hist�rico mensal. Al�m disso, o aplicativo oferece a funcionalidade de desligamento manual das l�mpadas, essencial para manuten��o ou ajustes em �reas espec�ficas. Por�m, o sistema n�o permite que as l�mpadas sejam ligadas manualmente se houver luz suficiente, eliminando desperd�cios causados por erros humanos.

### Principais Benef�cios

� **Economia de Energia:**

Reduz o consumo desnecess�rio, desligando automaticamente as l�mpadas em condi��es de alta luminosidade natural.

� **Controle Inteligente:**

Monitoramento em tempo real e hist�rico de consumo mensal atrav�s de um aplicativo integrado.
Op��o de desligamento manual para ajustes em situa��es espec�ficas, com bloqueio para evitar liga��es inadequadas.

� **Sustentabilidade:**

Promove pr�ticas empresariais sustent�veis, reduzindo o impacto ambiental e a emiss�o de carbono.

� **Redu��o de Custos Operacionais:**

Minimiza gastos com energia el�trica e manuten��o.

� **Escalabilidade e Flexibilidade:**

Adapt�vel a sistemas de ilumina��o existentes ou novos, adequado para ambientes de qualquer porte.

### Cen�rios de Uso

Ind�strias e Galp�es: Controle eficiente da ilumina��o em grandes �reas operacionais.
Complexos Empresariais: Ilumina��o automatizada para escrit�rios, corredores e estacionamentos.
Centros Comerciais e �reas P�blicas: Aplica��es em estacionamentos, pra�as e parques, ajustando a luz conforme a necessidade.

### Por que o GreenLight?

Diferente de sistemas tradicionais ou sensores de movimento, o GreenLight utiliza sensores LDR para medir a luminosidade ambiente com precis�o. Essa abordagem elimina desperd�cios de energia e oferece controle inteligente e seguro, garantindo que erros humanos n�o impactem o desempenho do sistema.

## CRUD da API

Para garantir o correto funcionamento do CRUD e dos relacionamentos entre as entidades, siga a ordem de cria��o dos registros (POST) de acordo com as depend�ncias:

### Ordem de Postagem
1. **Usuario** (necess�rio para criar Lampada)
2. **Lampada** (necess�rio para criar Registro)
3. **Registro** (�ltima entidade, pois depende de todas as anteriores)

---

## Exemplos de JSONs para POST

### 1. Usuario
```json
{
  "id": 1,
  "nome": "Jo�o Silva",
  "email": "joao.silva@email.com",
  "senha": "senha123",
  "lampadas": []
}
```

```json
{
  "id": 2,
  "nome": "Maria Oliveira",
  "email": "maria.oliveira@email.com",
  "senha": "senha456",
  "lampadas": []
}
```

### 2. Lampada

```json
{
  "id": 1,
  "apelido": "L�mpada Oficina",
  "nomeDispositivo": "SmartLamp123",
  "modo": true,
  "usuarioId": 1,
  "usuario": {
    "id": 1,
    "nome": "Jo�o Silva",
    "email": "joao.silva@email.com",
    "senha": "senha123",
    "lampadas": [
      "L�mpada Oficina"
    ]
  }
}
```

```json
{
  "id": 2,
  "apelido": "L�mpada Escrit�rio",
  "nomeDispositivo": "SmartLamp456",
  "modo": false,
  "usuarioId": 2,
  "usuario": {
    "id": 2,
    "nome": "Maria Oliveira",
    "email": "maria.oliveira@email.com",
    "senha": "senha456",
    "lampadas": [
      "L�mpada Escrit�rio"
    ]
  }
}
```

### 3. Registro
```json
{
  "id": 1,
  "lampadaId": 1,
  "lampada": {
    "id": 1,
    "apelido": "L�mpada Oficina",
    "nomeDispositivo": "SmartLamp123",
    "modo": true,
    "usuarioId": 1,
    "usuario": {
      "id": 1,
      "nome": "Jo�o Silva",
      "email": "joao.silva@email.com",
      "senha": "senha123",
      "lampadas": [
        "L�mpada Oficina"
      ]
    }
  },
  "consumoWh": 50,
  "dataConsumo": "2024-11-20T18:30:00Z",
  "diferencaMes": 10
}
```

```json
{
  "id": 2,
  "lampadaId": 2,
  "lampada": {
    "id": 2,
    "apelido": "L�mpada Escrit�rio",
    "nomeDispositivo": "SmartLamp456",
    "modo": false,
    "usuarioId": 2,
    "usuario": {
      "id": 2,
      "nome": "Maria Oliveira",
      "email": "maria.oliveira@email.com",
      "senha": "senha456",
      "lampadas": [
        "L�mpada Escrit�rio"
      ]
    }
  },
  "consumoWh": 30,
  "dataConsumo": "2024-11-20T20:45:00Z",
  "diferencaMes": 5
}
```


## Integrantes

Lucas Monte Verde - RM:551604 - 2TDSA

Ricardo Brito - RM:98370 - 2TDSA

Gabriel Mendes Cirillo -RM:98214 - 2TDSA

Pedro Sena - RM:98021 - 2TDSA

Mirelly Azevedo - RM:98672 - 2TDSPF