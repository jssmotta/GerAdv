'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { EventoPrazoAgendaGridAdapter } from '@/app/GerAdv_TS/EventoPrazoAgenda/Adapter/EventoPrazoAgendaGridAdapter';
import EventoPrazoAgendaGridContainer from '@/app/GerAdv_TS/EventoPrazoAgenda/Components/EventoPrazoAgendaGridContainer';
const EventoPrazoAgendaPage: React.FC = () => {
  const EventoPrazoAgendaGrid = new EventoPrazoAgendaGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Evento Prazo Agenda' />
    <EventoPrazoAgendaGridContainer grid={EventoPrazoAgendaGrid} />
  </PageLayout>
);
};
export default EventoPrazoAgendaPage;