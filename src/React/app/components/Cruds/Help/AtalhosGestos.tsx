'use client';

import React from 'react';
import { Section, ExplainBlock, GestureRow } from './HelpParts';

export default function AtalhosGestos() {
  return (
    <Section title="Atalhos e Gestos">
      <ExplainBlock>
        <GestureRow gesture="Toque no card" action="Abre o detalhe completo da consulta." />
        <GestureRow gesture="Deslize ← esquerda" action="Ações rápidas: editar, excluir ou reenviar e-mail." />
        <GestureRow gesture="Deslize → direita" action="Marca a consulta como concluída." />
        <GestureRow gesture="Toque longo" action="Seleciona múltiplos cards para ações em lote." />
        <GestureRow gesture="Pull-to-refresh" action="Puxa a lista para baixo para atualizar os dados." />
      </ExplainBlock>
    </Section>
  );
}
