'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { AgendaGridAdapter } from '@/app/GerAdv_TS/Agenda/Adapter/AgendaGridAdapter';
import AgendaGridContainer from '@/app/GerAdv_TS/Agenda/Components/AgendaGridContainer';
const AgendaPage: React.FC = () => {
  const AgendaGrid = new AgendaGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Agenda' />
    <AgendaGridContainer grid={AgendaGrid} />
  </PageLayout>
);
};
export default AgendaPage;