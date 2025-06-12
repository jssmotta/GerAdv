'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { AgendaRepetirGridAdapter } from '@/app/GerAdv_TS/AgendaRepetir/Adapter/AgendaRepetirGridAdapter';
import AgendaRepetirGridContainer from '@/app/GerAdv_TS/AgendaRepetir/Components/AgendaRepetirGridContainer';
const AgendaRepetirPage: React.FC = () => {
  const AgendaRepetirGrid = new AgendaRepetirGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Agenda Repetir' />
    <AgendaRepetirGridContainer grid={AgendaRepetirGrid} />
  </PageLayout>
);
};
export default AgendaRepetirPage;