'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { OperadorGruposAgendaGridAdapter } from '@/app/GerAdv_TS/OperadorGruposAgenda/Adapter/OperadorGruposAgendaGridAdapter';
import OperadorGruposAgendaGridContainer from '@/app/GerAdv_TS/OperadorGruposAgenda/Components/OperadorGruposAgendaGridContainer';
const OperadorGruposAgendaPage: React.FC = () => {
  const OperadorGruposAgendaGrid = new OperadorGruposAgendaGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Operador Grupos Agenda' />
    <OperadorGruposAgendaGridContainer grid={OperadorGruposAgendaGrid} />
  </PageLayout>
);
};
export default OperadorGruposAgendaPage;