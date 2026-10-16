# 🏎️ Karting Microgame Custom

Projeto do desafio **DIO – Trilha Unity**: customização do **Karting Microgame** (Unity).

> Este repositório contém as minhas modificações sobre o template oficial.
> Veja o passo a passo em [`Docs/SETUP.md`](Docs/SETUP.md).

## O que eu alterei

| Recurso | Script | Descrição |
|---|---|---|
| Pad de turbo | `SpeedBoostPad.cs` | Dá um impulso ao kart que passa por cima |
| Moedas | `CoinPickup.cs` | Coletável que gira, flutua e soma pontos |
| Respawn | `KartRespawn.cs` | Recoloca o kart se cair do mapa ou ao apertar **R** |
| Pontuação | `ScoreManager.cs` | Singleton com evento de mudança de pontos |
| Cronômetro | `RaceTimer.cs` | Tempo da corrida e recorde salvo (PlayerPrefs) |
| HUD | `HudDisplay.cs` | Mostra pontos, tempo e recorde na tela |

## Estrutura

```
Assets/_Custom/Scripts/
├── Gameplay/   SpeedBoostPad, CoinPickup, KartRespawn
├── Managers/   ScoreManager, RaceTimer
└── UI/         HudDisplay
```

## Como rodar

1. Crie um projeto pelo Unity Hub com o template **Karting Microgame**
2. Copie a pasta `Assets/_Custom` deste repositório para o `Assets` do projeto
3. Siga o [`Docs/SETUP.md`](Docs/SETUP.md) para montar a cena
4. Aperte **Play**

## Controles

- Setas / WASD: dirigir
- **R**: voltar para a última posição segura

## Demonstração

![Gameplay](Docs/gameplay.gif)

## Aprendizados

- Estrutura de projeto Unity versionado com Git
- Triggers, Rigidbody e eventos em C#
- Padrão Singleton
- Persistência simples com PlayerPrefs

## Autor

Seu Nome · [LinkedIn](https://linkedin.com/in/seu-usuario) · [GitHub](https://github.com/seu-usuario)
