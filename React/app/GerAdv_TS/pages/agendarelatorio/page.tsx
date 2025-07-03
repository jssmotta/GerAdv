'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { AgendaRelatorioGridAdapter } from '@/app/GerAdv_TS/AgendaRelatorio/Adapter/AgendaRelatorioGridAdapter';
import AgendaRelatorioGridContainer from '@/app/GerAdv_TS/AgendaRelatorio/Components/AgendaRelatorioGridContainer';
const AgendaRelatorioPage: React.FC = () => {
  const AgendaRelatorioGrid = new AgendaRelatorioGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Agenda Relatorio' />
    <AgendaRelatorioGridContainer grid={AgendaRelatorioGrid} />
  </PageLayout>
);
};
export default AgendaRelatorioPage;