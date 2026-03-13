'use client';

import React from 'react';
import { Section, ExplainBlock } from './HelpParts';

export default function FiltrosBusca() {
  return (
    <Section title="Como Usar Filtros e Busca">
      <ExplainBlock>
        <p className="hc-infoText">
          Toque no ícone de <strong>filtro</strong> para abrir o painel lateral. Combine múltiplos critérios: período, nome do paciente, status do e-mail.
        </p>
        <p className="hc-infoText">
          A <strong>busca por voz</strong> reconhece nomes e datas em linguagem natural. Exemplo: diga "Maria Aparecida fevereiro" e o sistema filtra automaticamente.
        </p>
        <p className="hc-infoText">
          Para busca textual, use o ícone <strong>Busca</strong> na barra inferior.
        </p>
      </ExplainBlock>
    </Section>
  );
}
