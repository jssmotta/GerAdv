'use client';

import React from 'react';
import { Section, HelpRow } from './HelpParts';
import { HomeIcon, PlusIcon, SearchIcon, CalendarIcon, ExitIcon } from './HelpIcons';

export default function NavegacaoInferior() {
  return (
    <Section title="Navegação Inferior">
      <HelpRow icon={<HomeIcon />} label="Home" desc="Retorna à tela inicial do sistema." />
      <HelpRow icon={<PlusIcon />} label="Novo" desc="Atalho rápido para criar um novo registro." />
      <HelpRow icon={<SearchIcon />} label="Busca" desc="Abre a busca textual global com sugestões inteligentes." />
      <HelpRow icon={<CalendarIcon />} label="Consultas" desc="Você está aqui. Exibe a listagem de consultas." />
      <HelpRow icon={<ExitIcon />} label="Sair" desc="Encerra a sessão de forma segura." />
    </Section>
  );
}
